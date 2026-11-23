
using System;
using System.IO;

class Nascimento
{
    public int mes;
    public int ano;
}

struct Gado
{
    public int codigo;
    public double leite;
    public double alim;
    public Nascimento nasc;
    public char abate;
}

class Exercicio5
{
    static Gado[] LerDados()
    {
        Console.Write("Quantidade de cabeças: ");
        int n = Convert.ToInt32(Console.ReadLine());

        Gado[] rebanho = new Gado[n];

        for (int i = 0; i < n; i++)
        {
            Gado animal = new Gado();

            Console.WriteLine("Cadastro do animal " + (i + 1));

            Console.Write("Código: ");
            animal.codigo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Litros de leite : ");
            animal.leite = Convert.ToDouble(Console.ReadLine());

            Console.Write("Alimento consumido por semana : ");
            animal.alim = Convert.ToDouble(Console.ReadLine());

            animal.nasc = new Nascimento();

            Console.Write("Mês de nasc: ");
            animal.nasc.mes = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ano de nasc: ");
            animal.nasc.ano = Convert.ToInt32(Console.ReadLine());

            animal.abate = 'N';

            rebanho[i] = animal;
        }

        return rebanho;
    }

    static void VerificarAbate(Gado[] rebanho)
    {
        DateTime hoje = DateTime.Now;

        for (int i = 0; i < rebanho.Length; i++)
        {
            int idade = hoje.Year - rebanho[i].nasc.ano;

            if (hoje.Month < rebanho[i].nasc.mes)
            {
                idade--;
            }

            if (idade > 5 || rebanho[i].leite < 40)
            {
                rebanho[i].abate = 'S';
            }
            else
            {
                rebanho[i].abate = 'N';
            }
        }

        Console.WriteLine("Verificação de abate realizada!");
    }

    static void TotalLeite(Gado[] rebanho)
    {
        double total = 0;

        for (int i = 0; i < rebanho.Length; i++)
        {
            total += rebanho[i].leite;
        }

        Console.WriteLine("Total de leite : " + total + " litros");
    }

    static void TotalAlimento(Gado[] rebanho)
    {
        double total = 0;

        for (int i = 0; i < rebanho.Length; i++)
        {
            total += rebanho[i].alim;
        }

        Console.WriteLine("Total de alimento consumido por semana: " + total + " kg");
    }

    static void ListarAbate(Gado[] rebanho)
    {
        bool encontrou = false;

        for (int i = 0; i < rebanho.Length; i++)
        {
            if (rebanho[i].abate == 'S')
            {
              
                Console.WriteLine("Código: " + rebanho[i].codigo);
                Console.WriteLine("Leite por semana: " + rebanho[i].leite + " ltrs");
                Console.WriteLine("Alimentos " + rebanho[i].alim + " kg");
                Console.WriteLine("Mês de nasc: " + rebanho[i].nasc.mes);
                Console.WriteLine("Ano de nasc: " + rebanho[i].nasc.ano);
                Console.WriteLine("Abate: " + rebanho[i].abate);

                encontrou = true;
            }
        }

        if (!encontrou)
        {
            Console.WriteLine("Nenhum animal deve ir para o abate.");
        }
    }

    static void SalvarDados(Gado[] rebanho)
    {
        StreamWriter arquivo = new StreamWriter("gado.txt");

        arquivo.WriteLine(rebanho.Length);

        for (int i = 0; i < rebanho.Length; i++)
        {
            arquivo.WriteLine(
                rebanho[i].codigo + ";" +
                rebanho[i].leite + ";" +
                rebanho[i].alim + ";" +
                rebanho[i].nasc.mes + ";" +
                rebanho[i].nasc.ano + ";" +
                rebanho[i].abate
            );
        }

        arquivo.Close();

        Console.WriteLine("Dados salvos com sucesso!");
    }

    static Gado[] CarregarDados()
    {
        if (!File.Exists("gado.txt"))
        {
            Console.WriteLine("Arquivo não encontrado.");
            return new Gado[0];
        }

        StreamReader arquivo = new StreamReader("gado.txt");

        int n = Convert.ToInt32(arquivo.ReadLine());

        Gado[] rebanho = new Gado[n];

        for (int i = 0; i < n; i++)
        {
            string linha = arquivo.ReadLine() ?? "";
            string[] dados = linha.Split(';');

            Gado animal = new Gado();

            animal.codigo = Convert.ToInt32(dados[0]);
            animal.leite = Convert.ToDouble(dados[1]);
            animal.alim = Convert.ToDouble(dados[2]);

            animal.nasc = new Nascimento();
            animal.nasc.mes = Convert.ToInt32(dados[3]);
            animal.nasc.ano = Convert.ToInt32(dados[4]);

            animal.abate = Convert.ToChar(dados[5]);

            rebanho[i] = animal;
        }

        arquivo.Close();

        Console.WriteLine("Dados carregados com sucesso!");

        return rebanho;
    }

    static int Menu()
    {
        Console.WriteLine("Controle da Fazenda");
        Console.WriteLine("1 - Cadastrar dados do rebanho");
        Console.WriteLine("2 - Verificar animais para abate");
        Console.WriteLine("3 - Total de leite produzido");
        Console.WriteLine("4 - Total de alimento consumido");
        Console.WriteLine("5 - Listar animais para abate");
        Console.WriteLine("6 - Salvar dados");
        Console.WriteLine("7 - Carregar dados");
        Console.WriteLine("0 - Sair");
        Console.Write("Escolha uma opção: ");

        return Convert.ToInt32(Console.ReadLine());
    }

    static void Main(string[] args)
    {
        Gado[] rebanho = new Gado[0];

        int opcao;

        do
        {
            opcao = Menu();

            Console.Clear();

            switch (opcao)
            {
                case 1:
                    rebanho = LerDados();
                    break;

                case 2:
                    VerificarAbate(rebanho);
                    break;

                case 3:
                    TotalLeite(rebanho);
                    break;

                case 4:
                    TotalAlimento(rebanho);
                    break;

                case 5:
                    ListarAbate(rebanho);
                    break;

                case 6:
                    SalvarDados(rebanho);
                    break;

                case 7:
                    rebanho = CarregarDados();
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
                Console.WriteLine("Pressione qualquer tecla ");
                Console.ReadKey();
                Console.Clear();
            }

        } while (opcao != 0);
    }
}
