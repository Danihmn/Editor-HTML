using System;
using System.Text.RegularExpressions;

namespace EditorHTML
{
    public static class Visualizador
    {
        public static void Mostrar(string texto)
        {
            Console.Clear();
            Console.WriteLine("Modo Visualização");

            // Linha de separação
            for (var i = 0; i <= 40; i++)
                Console.Write("-");

            SubstituirCaracteres(texto);

            Console.ReadKey();
            Menu.Mostrar();
        }

        public static void SubstituirCaracteres(string texto)
        {
            // Expressão regular para encontrar o conteúdo dentro de <strong>...</strong>
            var strongRegex = new Regex(@"<strong>(.*?)<\/strong>", RegexOptions.IgnoreCase);

            // Percorre o texto e imprime palavra por palavra
            int lastIndex = 0;
            foreach (Match match in strongRegex.Matches(texto))
            {
                // Exibir a parte do texto antes da tag <strong>
                Console.Write(texto.Substring(lastIndex, match.Index - lastIndex));

                // Exibir a palavra dentro da tag <strong> com destaque
                Console.ForegroundColor = ConsoleColor.Yellow; // Cor para destacar
                Console.Write(match.Groups[1].Value);
                Console.ResetColor(); // Restaura a cor original

                // Atualiza a posição do índice
                lastIndex = match.Index + match.Length;
            }

            // Exibir qualquer parte restante do texto
            Console.WriteLine(texto.Substring(lastIndex));
        }
    }
}