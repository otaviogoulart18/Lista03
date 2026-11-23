
using System;
using System.Collections.Generic;

namespace Biblioteca
{
    struct Livro
    {
        public string titulo;
        public string autor;
        public int ano;
        public string prateleira;
    }

    class Exercicio3
    {
        static void addLivro(List<Livro> lista)
        {
            Livro novoLivro = new Livro();

            Console.Write("Digite o título : ");
            novoLivro.titulo = Console.ReadLine() ?? "";

            Console.Write("Digite o autor : ");
            novoLivro.autor = Console.ReadLine() ?? "";

            Console.Write("Digite o ano : ");
            novoLivro.ano = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite a prateleira  ");
            novoLivro.prateleira = Console.ReadLine() ?? "";

            lista.Add(novoLivro);

            Console.WriteLine("Livro cadastrado com sucesso!");
        }

        static void buscarLivro(List<Livro> lista)
        {
            Console.Write("Digite o título do livro : ");
            string titulo = Console.ReadLine() ?? "";

            bool encontrado = false;

            foreach (Livro livro in lista)
            {
                if (livro.titulo.Equals(titulo,
                    StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Livro encontrado!");
                    Console.WriteLine("Título: " + livro.titulo);
                    Console.WriteLine("Prateleira: " + livro.prateleira);

                    encontrado = true;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }

        static void Listarlivros(List<Livro> lista)
        {
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum livro cadastrado.");
                return;
            }

            foreach (Livro livro in lista)
            {
                Console.WriteLine("Título: " + livro.titulo);
                Console.WriteLine("Autor: " + livro.autor);
                Console.WriteLine("Ano: " + livro.ano);
                Console.WriteLine("Prateleira: " + livro.prateleira);
            }
        }

        static void buscarAno(List<Livro> lista)
        {
            Console.Write("Digite um ano: ");
            int ano = Convert.ToInt32(Console.ReadLine());

            bool encontrado = false;

            foreach (Livro livro in lista)
            {
                if (livro.ano > ano)
                {
                    Console.WriteLine("Título: " + livro.titulo);
                    Console.WriteLine("Autor: " + livro.autor);
                    Console.WriteLine("Ano: " + livro.ano);
                    Console.WriteLine("Prateleira: " + livro.prateleira);

                    encontrado = true;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("Nenhum livro mais novo que o ano informado.");
            }
        }

        static int menu()
        {
            Console.WriteLine("Biblioteca");
            Console.WriteLine("1 - Cadastrar livro");
            Console.WriteLine("2 - Buscar livro pelo título");
            Console.WriteLine("3 - Mostrar todos os livros");
            Console.WriteLine("4 - Buscar lançamentos de livros ");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");

            if (int.TryParse(Console.ReadLine(), out int opcao))
            {
                return opcao;
            }

            return -1;
        }

        static void Main(string[] args)
        {
            List<Livro> listaLivros = new List<Livro>();

            int opcao;

            do
            {
                opcao = menu();

                Console.Clear();

                switch (opcao)
                {
                    case 1:
                        addLivro(listaLivros);
                        break;

                    case 2:
                        buscarLivro(listaLivros);
                        break;

                    case 3:
                        mostrarLivros(listaLivros);
                        break;

                    case 4:
                        buscarAno(listaLivros);
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
}
