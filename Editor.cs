using System;
using System.Text;
using System.Threading;

namespace EditorHTML
{
    public static class Editor
    {
        public static void Exibir()
        {
            Console.Clear();
            Console.WriteLine("Modo Editor");

            // Linha de separação
            for (var i = 0; i <= 40; i++)
                Console.Write("-");

            Console.SetCursorPosition(1, 3);
            Escrever();
        }

        public static StringBuilder Conteudo { get; private set; } = new(); // Tipo StringBuilder público

        public static void Escrever()
        {
            do
            {
                Conteudo.Append(Console.ReadLine());
                Conteudo.Append(Environment.NewLine);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            Iniciar(Conteudo);
        }

        public static void Iniciar(StringBuilder arquivo)
        {
            // Linha de separação
            for (var i = 0; i <= 40; i++)
                Console.Write("-");

            Console.WriteLine("Deseja salvar o arquivo? (S - Sim, N - Não)");

            string resposta = Console.ReadLine() ?? "".ToLower();

            if (!string.IsNullOrWhiteSpace(resposta))
            {
                switch (resposta)
                {
                    case "s": Menu.Mostrar(); break;
                    case "n": Menu.Mostrar(); break;
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Por favor, digite S ou N");
                            Thread.Sleep(2000);
                            Exibir();
                            break;
                        }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Por favor, digite alguma opção");
                Thread.Sleep(2000);
                Exibir();
            }
        }
    }
}