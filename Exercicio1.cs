
using System;
using System.Collections.Generic;
using System.IO;

namespace SistemaBandas
{
    
    struct Banda
    {
        public string nome;
        public string genero;
        public int integrantes;
        public int ranking;
    }

    class Program
    {
        
        static void addBanda(List<Banda> listaBandas)
        {
            Banda novaBanda = new Banda();

            Console.WriteLine("Cadastrar Bandas");

            Console.Write(" Nome da banda: ");
            novaBanda.nome = Console.ReadLine() ?? "";

            Console.Write("Gênero : ");
            novaBanda.genero = Console.ReadLine() ?? "";

            Console.Write(" Integrantes: ");

            while (!int.TryParse(Console.ReadLine(), out novaBanda.integrantes))
            {
                Console.Write("Digite um número válido: ");
            }

            Console.Write("ranking: ");

            while (!int.TryParse(Console.ReadLine(), out novaBanda.ranking))
            {
                Console.Write("Digite um número válido: ");
            }

            listaBandas.Add(novaBanda);

            Console.WriteLine("Banda cadastrada com sucesso!");
        }

        
        static void mostrarBandas(List<Banda> listaBandas)
        {
            if (listaBandas.Count == 0)
            {
                Console.WriteLine("\nNenhuma banda cadastrada.");
                return;
            }

            foreach (Banda b in listaBandas)
            {
                Console.WriteLine("Nome: " + b.nome);
                Console.WriteLine("Gênero: " + b.genero);
                Console.WriteLine("Integrantes: " + b.integrantes);
                Console.WriteLine("Ranking: " + b.ranking);

            }
        }

        
        static void salvarBandas(List<Banda> listaBandas)
        {
            using (StreamWriter sw = new StreamWriter("bandas.txt"))
            {
                foreach (Banda b in listaBandas)
                {
                    sw.WriteLine(
                        b.nome + ";" +
                        b.genero + ";" +
                        b.integrantes + ";" +
                        b.ranking
                    );
                }
            }

            Console.WriteLine("Dados salvos com sucesso!");
        }

       
        static void carregarBandas(List<Banda> listaBandas)
        {
            if (File.Exists("bandas.txt"))
            {
                listaBandas.Clear();

                using (StreamReader sr = new StreamReader("bandas.txt"))
                {
                    string? linha;

                    while ((linha = sr.ReadLine()) != null)
                    {
                        string[] partes = linha.Split(';');

                        if (partes.Length == 4 &&
                            int.TryParse(partes[2], out int integrantes) &&
                            int.TryParse(partes[3], out int ranking))
                        {
                            Banda b = new Banda();

                            b.nome = partes[0];
                            b.genero = partes[1];
                            b.integrantes = integrantes;
                            b.ranking = ranking;

                            listaBandas.Add(b);
                        }
                    }
                }

                Console.WriteLine("Dados carregados com sucesso!");
            }
            else
            {
                Console.WriteLine("Arquivo de bandas não encontrado.");
            }
        }

        
        static void buscarRanking(List<Banda> listaBandas)
        {
            Console.Write("\nDigite a posição : ");

            if (!int.TryParse(Console.ReadLine(), out int ranking))
            {
                Console.WriteLine("Ranking inválido!");
                return;
            }

            bool encontrou = false;

            foreach (Banda b in listaBandas)
            {
                if (b.ranking == ranking)
                {
                    Console.WriteLine("Nome: " + b.nome);
                    Console.WriteLine("Gênero: " + b.genero);
                    Console.WriteLine("Integrantes: " + b.integrantes);
                    Console.WriteLine("Ranking: " + b.ranking);

                    encontrou = true;
                }
            }

            if (!encontrou)
            {
                Console.WriteLine("\nNenhuma banda encontrada .");
            }
        }

        
        static void buscarGenero(List<Banda> listaBandas)
        {
            Console.Write("\nDigite o gênero musical: ");
            string genero = Console.ReadLine() ?? "";

            bool encontrou = false;

            foreach (Banda b in listaBandas)
            {
                if (b.genero.Equals(
                    genero,
                    StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Nome: " + b.nome);
                    Console.WriteLine("Gênero: " + b.genero);
                    Console.WriteLine("Integrantes: " + b.integrantes);
                    Console.WriteLine("Ranking: " + b.ranking);

                    encontrou = true;
                }
            }

            if (!encontrou)
            {
                Console.WriteLine("\nNenhuma banda encontrada .");
            }
        }

       
        static void buscarNome(List<Banda> listaBandas)
        {
            Console.Write("\nDigite o nome da banda: ");
            string nome = Console.ReadLine() ?? "";

            bool encontrou = false;

            foreach (Banda b in listaBandas)
            {
                if (b.nome.Equals(
                    nome,
                    StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("\nBanda encontrada!");
                    Console.WriteLine("Nome: " + b.nome);
                    Console.WriteLine("Gênero: " + b.genero);
                    Console.WriteLine("Integrantes: " + b.integrantes);
                    Console.WriteLine("Ranking: " + b.ranking);

                    encontrou = true;
                    break;
                }
            }

            if (!encontrou)
            {
                Console.WriteLine("\nBanda não encontrada.");
            }
        }

        
        static void excluirBanda(List<Banda> listaBandas)
        {
            Console.Write("\nDigite o nome da banda que deseja excluir: ");
            string nome = Console.ReadLine() ?? "";

            int indice = listaBandas.FindIndex(b =>
                b.nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

            if (indice >= 0)
            {
                listaBandas.RemoveAt(indice);

                Console.WriteLine("Banda excluída com sucesso!");
            }
            else
            {
                Console.WriteLine("Banda não encontrada.");
            }
        }

       
        static void alterarBanda(List<Banda> listaBandas)
        {
            Console.Write("\nDigite o nome da banda que deseja alterar: ");
            string nome = Console.ReadLine() ?? "";

            int indice = listaBandas.FindIndex(b =>
                b.nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

            if (indice >= 0)
            {
                Banda novaBanda = new Banda();

                Console.WriteLine("Digite novamente os dados da banda:");

                Console.Write("Nome: ");
                novaBanda.nome = Console.ReadLine() ?? "";

                Console.Write("Gênero : ");
                novaBanda.genero = Console.ReadLine() ?? "";

                Console.Write("Integrantes: ");

                while (!int.TryParse(Console.ReadLine(), out novaBanda.integrantes))
                {
                    Console.Write("Digite um número válido: ");
                }

                Console.Write("Posição no ranking: ");

                while (!int.TryParse(Console.ReadLine(), out novaBanda.ranking))
                {
                    Console.Write("Digite um número válido: ");
                }

                listaBandas[indice] = novaBanda;

                Console.WriteLine("\nBanda alterada com sucesso!");
            }
            else
            {
                Console.WriteLine("Banda não encontrada.");
            }
        }

        
        static int menu()
        {
            Console.WriteLine("Menu ");
            Console.WriteLine("1 - Cadastrar banda");
            Console.WriteLine("2 - Mostrar bandas cadastradas");
            Console.WriteLine("3 - Buscar pelo ranking");
            Console.WriteLine("4 - Buscar pelo gênero");
            Console.WriteLine("5 - Buscar pelo nome");
            Console.WriteLine("6 - Excluir banda");
            Console.WriteLine("7 - Alterar banda");
            Console.WriteLine("8 - Salvar dados");
            Console.WriteLine("9 - Carregar dados");
            Console.WriteLine("0 - Sair");

            Console.Write("\nEscolha uma opção: ");

            if (int.TryParse(Console.ReadLine(), out int opcao))
            {
                return opcao;
            }

            return -1;
        }

       
        static void Main()
        {
            List<Banda> listaBandas = new List<Banda>();

            int opcao;

            do
            {
                opcao = menu();

                switch (opcao)
                {
                    case 1:
                        addBanda(listaBandas);
                        break;

                    case 2:
                        mostrarBandas(listaBandas);
                        break;

                    case 3:
                        buscarRanking(listaBandas);
                        break;

                    case 4:
                        buscarGenero(listaBandas);
                        break;

                    case 5:
                        buscarNome(listaBandas);
                        break;

                    case 6:
                        excluirBanda(listaBandas);
                        break;

                    case 7:
                        alterarBanda(listaBandas);
                        break;

                    case 8:
                        salvarBandas(listaBandas);
                        break;

                    case 9:
                        carregarBandas(listaBandas);
                        break;

                    case 0:
                        Console.WriteLine("\nSaindo do programa...");
                        salvarBandas(listaBandas);
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                if (opcao != 0)
                {
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }

            } while (opcao != 0);
        }
    }
}
