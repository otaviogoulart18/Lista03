
using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

namespace ControleEnergia
{
    struct Eletrodomestico
    {
        public string nome;
        public double potencia;
        public double horas;
    }

    class Exercicio2
    {
        
        static void addEletrodomestico(List<Eletrodomestico> lista)
        {
            Eletrodomestico novo = new Eletrodomestico();

            Console.Write("Nome: ");
            novo.nome = Console.ReadLine() ?? "";

            Console.Write("Potência em kW: ");
            novo.potencia = Convert.ToDouble(Console.ReadLine());

            Console.Write("Tempo médio ativo por dia : ");
            novo.horas = Convert.ToDouble(Console.ReadLine());

            lista.Add(novo);

            Console.WriteLine("Eletrodoméstico cadastrado com sucesso!");
        }

        
        static void mostrarEletrodomesticos(List<Eletrodomestico> lista)
        {
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum eletrodoméstico cadastrado.");
                return;
            }

            foreach (Eletrodomestico eletro in lista)
            {
                Console.WriteLine("Nome: " + eletro.nome);
                Console.WriteLine("Potência: " + eletro.potencia + " kW");
                Console.WriteLine("Horas por dia: " + eletro.horas);
                Console.WriteLine("Consumo diário: " +
                    (eletro.potencia * eletro.horas) + " kWh");
            }
        }

        
        static void salvarEletrodomesticos(List<Eletrodomestico> lista)
        {
            using (StreamWriter sw = new StreamWriter("eletrodomesticos.txt"))
            {
                foreach (Eletrodomestico eletro in lista)
                {
                    sw.WriteLine(
                        eletro.nome + ";" +
                        eletro.potencia.ToString(CultureInfo.InvariantCulture) + ";" +
                        eletro.horas.ToString(CultureInfo.InvariantCulture)
                    );
                }
            }

            Console.WriteLine("Dados salvos com sucesso!");
        }

        
        static void carregarEletrodomesticos(List<Eletrodomestico> lista)
        {
            if (!File.Exists("eletrodomesticos.txt"))
            {
                Console.WriteLine("Arquivo ainda não existe.");
                return;
            }

            lista.Clear();

            using (StreamReader sr = new StreamReader("eletrodomesticos.txt"))
            {
                string linha;

                while ((linha = sr.ReadLine()) != null)
                {
                    string[] dados = linha.Split(';');

                    if (dados.Length == 3 &&
                        double.TryParse(dados[1], NumberStyles.Float,
                            CultureInfo.InvariantCulture, out double potencia) &&
                        double.TryParse(dados[2], NumberStyles.Float,
                            CultureInfo.InvariantCulture, out double horas))
                    {
                        Eletrodomestico eletro = new Eletrodomestico();

                        eletro.nome = dados[0];
                        eletro.potencia = potencia;
                        eletro.horas = horas;

                        lista.Add(eletro);
                    }
                }
            }

            Console.WriteLine("Dados carregados com sucesso!");
        }

        
        static void buscarPornome(List<Eletrodomestico> lista)
        {
            Console.Write("Digite o nome do eletrodoméstico: ");
            string nome = Console.ReadLine() ?? "";

            bool encontrado = false;

            foreach (Eletrodomestico eletro in lista)
            {
                if (eletro.nome.Equals(nome,
                    StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Eletrodoméstico encontrado!");
                    Console.WriteLine("Nome: " + eletro.nome);
                    Console.WriteLine("Potência: " + eletro.potencia + " kW");
                    Console.WriteLine("Horas por dia: " + eletro.horas);
                    Console.WriteLine("Consumo diário: " +
                        (eletro.potencia * eletro.horas) + " kWh");

                    encontrado = true;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("Eletrodoméstico não encontrado.");
            }
        }

        
        static void buscarConsumo(List<Eletrodomestico> lista)
        {
            Console.Write("Digite o consumo diário mínimo em kWh: ");
            double valor = Convert.ToDouble(Console.ReadLine());

            bool encontrado = false;

            foreach (Eletrodomestico eletro in lista)
            {
                double consumo = eletro.potencia * eletro.horas;

                if (consumo > valor)
                {
                    Console.WriteLine("Nome: " + eletro.nome);
                    Console.WriteLine("Consumo diário: " + consumo + " kWh");

                    encontrado = true;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("Nenhum eletrodoméstico consome mais que esse valor.");
            }
        }

        
        static void calcularConsumo(List<Eletrodomestico> lista)
        {
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum eletrodoméstico cadastrado.");
                return;
            }

            double consumoDiario = 0;
            double consumoMensal;
            double valorKwh;
            double custoDiario;
            double custoMensal;

            foreach (Eletrodomestico eletro in lista)
            {
                consumoDiario += eletro.potencia * eletro.horas;
            }

            consumoMensal = consumoDiario * 30;

            Console.Write("Digite o valor do kWh em R$: ");
            valorKwh = Convert.ToDouble(Console.ReadLine());

            custoDiario = consumoDiario * valorKwh;
            custoMensal = consumoMensal * valorKwh;

            Console.WriteLine("Consumo ");

            Console.WriteLine("Consumo diário: " +
                consumoDiario.ToString("F2") + " kWh");

            Console.WriteLine("Consumo mensal: " +
                consumoMensal.ToString("F2") + " kWh");

            Console.WriteLine("Custo diário: R$ " +
                custoDiario.ToString("F2"));

            Console.WriteLine("Custo mensal: R$ " +
                custoMensal.ToString("F2"));
        }

        // Exibir menu
        static int menu()
        {
            Console.WriteLine("Controle de Energia");
            Console.WriteLine("1 - Cadastrar eletrodoméstico");
            Console.WriteLine("2 - Listar eletrodomésticos");
            Console.WriteLine("3 - Salvar dados");
            Console.WriteLine("4 - Buscar pelo nome");
            Console.WriteLine("5 - Buscar por consumo maior que X");
            Console.WriteLine("6 - Calcular consumo diário e mensal");
            Console.WriteLine("7 - Carregar dados do arquivo");
            Console.WriteLine("0 - Sair");
            Console.Write("\nEscolha uma opção: ");

            if (int.TryParse(Console.ReadLine(), out int opcao))
            {
                return opcao;
            }

            return -1;
        }

        static void Main(string[] args)
        {
            List<Eletrodomestico> listaEletrodomesticos =
                new List<Eletrodomestico>();

            int opcao;

            do
            {
                opcao = menu();

                Console.Clear();

                switch (opcao)
                {
                    case 1:
                        addEletrodomestico(listaEletrodomesticos);
                        break;

                    case 2:
                        mostrarEletrodomesticos(listaEletrodomesticos);
                        break;

                    case 3:
                        salvarEletrodomesticos(listaEletrodomesticos);
                        break;

                    case 4:
                        buscarNome(listaEletrodomesticos);
                        break;

                    case 5:
                        buscarConsumo(listaEletrodomesticos);
                        break;

                    case 6:
                        calcularConsumo(listaEletrodomesticos);
                        break;

                    case 7:
                        carregarEletrodomesticos(listaEletrodomesticos);
                        break;

                    case 0:
                        Console.WriteLine("Encerrando o programa...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                if (opcao != 0)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }

            } while (opcao != 0);
        }
    }
}
