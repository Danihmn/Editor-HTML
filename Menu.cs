using System;
using System.Text;
using System.Threading;

namespace EditorHTML
{
    public static class Menu
    {
        public static void Mostrar()
        {
            Console.Clear();
            DesenharTela();
            DesenharOpcoes();

            Console.SetCursorPosition(10, 10);

            // Mantendo o usuário dentro da aplicação
            if (!short.TryParse(Console.ReadLine(), out short opcao))
            {
                Console.Clear();
                Console.Write("Você deve escolher um valor");
                Thread.Sleep(2000);
                Environment.Exit(0);
                Console.Clear();
            }
            else
            {
                ManipularMenu(opcao);
            }
        }

        // Desenhar uma tela, cada função desenhará uma parte da tela
        public static void DesenharTela()
        {
            static void TracoInicial()
            {
                Console.Write("+");
                for (int i = 0; i <= 40; i++)
                    Console.Write("-");

                Console.Write("+");
                Console.Write(Environment.NewLine);
            }

            static void Linhas()
            {
                for (int lines = 0; lines <= 10; lines++)
                {
                    Console.Write("|");

                    for (int i = 0; i <= 40; i++)
                        Console.Write(" ");

                    Console.Write("|");
                    Console.Write("\n");
                }
            }

            static void TracoFinal()
            {
                Console.Write("+");
                for (int i = 0; i <= 40; i++)
                    Console.Write("-");

                Console.Write("+");
                Console.Write("\n");
            }

            // Chama os métodos que desenham as partes da tela
            TracoInicial();
            Linhas();
            TracoFinal();
        }

        // Método que irá manipular as opções do menu
        public static void ManipularMenu(short opcao)
        {
            switch (opcao)
            {
                case 1: Editor.Exibir(); break;
                case 2: Visualizador.Mostrar(Editor.Conteudo.ToString()); break;
                case 0:
                    {
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    }
                default: Mostrar(); break;
            }
        }

        public static void DesenharOpcoes()
        {
            // Muda a posição do cursos para dentro da tela desenhada
            Console.SetCursorPosition(3, 1);
            Console.WriteLine("Editor HTML");
            Console.SetCursorPosition(1, 2);

            for (var i = 0; i <= 40; i++)
                Console.Write("=");

            // Escrevendo as opções
            Console.SetCursorPosition(3, 4);
            Console.WriteLine("Selecione uma opção abaixo");
            Console.SetCursorPosition(3, 6);
            Console.WriteLine("1 - Novo arquivo");
            Console.SetCursorPosition(3, 7);
            Console.WriteLine("2 - Abrir");
            Console.SetCursorPosition(3, 8);
            Console.WriteLine("0 - Sair");
            Console.SetCursorPosition(3, 10);
            Console.Write("Opção: ");
        }
    }
}