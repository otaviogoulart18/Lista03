namespace Lista3;

public 
using System;
using System.Collections.Generic;

class Exercicio4
{
    public DateTime data;
    public string nomePessoa = "";
    public char emprestado;
}

struct Jogo
{
    public string titulo;
    public string console;
    public int ano;
    public int ranking;
    public Emprestimo emprestimo;
}

class Program
{
    static void CadastrarJogo(List<Jogo> listaJogos)
{
    Jogo novoJogo = new Jogo();

    Console.Write("Título do jogo: ");
    novoJogo.titulo = Console.ReadLine() ?? "";

    Console.Write("Console: ");
    novoJogo.console = Console.ReadLine() ?? "";

    Console.Write("Ano: ");
    novoJogo.ano = Convert.ToInt32(Console.ReadLine());

    Console.Write("Ranking: ");
    novoJogo.ranking = Convert.ToInt32(Console.ReadLine());

    novoJogo.emprestimo = new Emprestimo();
    novoJogo.emprestimo.data = DateTime.MinValue;
    novoJogo.emprestimo.nomePessoa = "";
    novoJogo.emprestimo.emprestado = 'N';

    listaJogos.Add(novoJogo);

    Console.WriteLine("Jogo cadastrado com sucesso!");
    Console.WriteLine("\n--- Dados do jogo cadastrado ---");
    Console.WriteLine("Título: " + novoJogo.titulo);
    Console.WriteLine("Console: " + novoJogo.console);
    Console.WriteLine("Ano: " + novoJogo.ano);
    Console.WriteLine("Ranking: " + novoJogo.ranking);
    Console.WriteLine("Emprestado: " + novoJogo.emprestimo.emprestado);
}

    static void BuscarTitulo(List<Jogo> listaJogos)
    {
        Console.Write("Digite o título do jogo: ");
        string titulo = Console.ReadLine() ?? "";

        bool encontrou = false;

        foreach (Jogo jogo in listaJogos)
        {
            if (jogo.titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Jogo encontrado ");
                Console.WriteLine("Título: " + jogo.titulo);
                Console.WriteLine("Console: " + jogo.console);
                Console.WriteLine("Ano: " + jogo.ano);
                Console.WriteLine("Ranking: " + jogo.ranking);
                Console.WriteLine("Emprestado: " + jogo.emprestimo.emprestado);

                if (jogo.emprestimo.emprestado == 'S')
                {
                    Console.WriteLine("Data do empréstimo: " +
                        jogo.emprestimo.data.ToString("dd/MM/yyyy"));
                    Console.WriteLine("Nome da pessoa: " +
                        jogo.emprestimo.nomePessoa);
                }

                encontrou = true;
                break;
            }
        }

        if (!encontrou)
            Console.WriteLine("Jogo não encontrado.");
    }

    

    static void EmprestarJogo(List<Jogo> listaJogos)
    {
        Console.Write("Digite o título do jogo: ");
        string titulo = Console.ReadLine() ?? "";

        bool encontrou = false;

        for (int i = 0; i < listaJogos.Count; i++)
        {
            if (listaJogos[i].titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase))
            {
                encontrou = true;

                if (listaJogos[i].emprestimo.emprestado == 'S')
                {
                    Console.WriteLine("Esse jogo já está emprestado.");
                }
                else
                {
                    Console.Write("Nome da pessoa que pegou o jogo: ");
                    listaJogos[i].emprestimo.nomePessoa = Console.ReadLine() ?? "";

                    listaJogos[i].emprestimo.data = DateTime.Now;
                    listaJogos[i].emprestimo.emprestado = 'S';

                    Console.WriteLine("Empréstimo realizado com sucesso!");
                }

                break;
            }
        }

        if (!encontrou)
            Console.WriteLine("Jogo não encontrado.");
    }

    static void DevolverJogo(List<Jogo> listaJogos)
    {
        Console.Write("Digite o título do jogo: ");
        string titulo = Console.ReadLine() ?? "";

        bool encontrou = false;

        for (int i = 0; i < listaJogos.Count; i++)
        {
            if (listaJogos[i].titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase))
            {
                encontrou = true;

                if (listaJogos[i].emprestimo.emprestado == 'S')
                {
                    listaJogos[i].emprestimo.emprestado = 'N';
                    listaJogos[i].emprestimo.nomePessoa = "";
                    listaJogos[i].emprestimo.data = DateTime.MinValue;

                    Console.WriteLine("Jogo devolvido com sucesso!");
                }
                else
                {
                    Console.WriteLine("Esse jogo não está emprestado.");
                }

                break;
            }
        }

        if (!encontrou)
            Console.WriteLine("Jogo não encontrado.");
    }

    static void MostrarEmprestados(List<Jogo> listaJogos)
    {
        bool encontrou = false;

        foreach (Jogo jogo in listaJogos)
        {
            if (jogo.emprestimo.emprestado == 'S')
            {
                
                Console.WriteLine("Título: " + jogo.titulo);
                Console.WriteLine("Console: " + jogo.console);
                Console.WriteLine("Data do empréstimo: " +
                    jogo.emprestimo.data.ToString("dd/MM/yyyy"));
                Console.WriteLine("Nome da pessoa: " +
                    jogo.emprestimo.nomePessoa);

                encontrou = true;
            }
        }

        if (!encontrou)
            Console.WriteLine("Não existem jogos emprestados.");
    }

    static int Menu()
    {
        Console.WriteLine("Catalogos de jogos ");
        Console.WriteLine("1 - Cadastrar jogo");
        Console.WriteLine("2 - Buscar jogo por título");
        Console.WriteLine("3 - Realizar empréstimo");
        Console.WriteLine("4 - Devolver jogo");
        Console.WriteLine("5 - Mostrar jogos emprestados");
        Console.WriteLine("0 - Sair");
        Console.Write("Escolha uma opção: ");

        return Convert.ToInt32(Console.ReadLine());
    }

    static void Main(string[] args)
    {
        List<Jogo> listaJogos = new List<Jogo>();

        int opcao;

        do
        {
            opcao = Menu();

            Console.Clear();

            switch (opcao)
            {
                case 1:
                    CadastrarJogo(listaJogos);
                    break;

                case 2:
                    BuscarTitulo(listaJogos);
                    break;

              
              case 3:
                    EmprestarJogo(listaJogos);
                    break;

                case 4:
                    DevolverJogo(listaJogos);
                    break;

                case 5:
                    MostrarEmprestados(listaJogos);
                    break;

                case 6:
                    MostrarJogos(listaJogos);
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
                Console.WriteLine("\nPressione qualquer tecla ");
                Console.ReadKey();
                Console.Clear();
            }

        } while (opcao != 0);
    }
}
 Exercicio4
{
    
}
