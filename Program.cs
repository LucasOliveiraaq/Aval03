using System;
using System.IO;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        string textoCifrado = File.ReadAllText("provinhaBarbadinha.txt");
        string textoDecifrado = decifrar(textoCifrado);
        textoDecifrado = textoDecifrado.Replace("@", "\n");

        string[] palindromos = palindromo(textoDecifrado);

        Console.WriteLine("Conteúdo do texto cifrado: \n" + textoCifrado);
        Console.WriteLine("\nPalíndromos encontrados: ");

        foreach (var item in palindromos)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("\nNúmero de caracteres do texto decifrado: " + textoDecifrado.Length);
        Console.WriteLine("\nQuantidade de palavras no texto decifrado: " + textoDecifrado.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length);
        Console.WriteLine("\nTexto decifrado em maiúsculas: \n" + textoDecifrado.ToUpper());
    }

    static string decifrar(string textoCifrado)
    {
        char[] caracteresCifrados = textoCifrado.ToCharArray();
        for (int i = 0; i < caracteresCifrados.Length; i++)
        {
            int chave = (i % 5 == 0) ? 8 : 16;
            caracteresCifrados[i] = (char)(caracteresCifrados[i] - chave);
        }
        return new string(caracteresCifrados);
    }
    static string[] palindromo(string texto)
    {
        return texto.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Where(palavra =>
            {
                char[] caracteres = palavra.ToCharArray();
                Array.Reverse(caracteres);
                return palavra.Equals(new string(caracteres), StringComparison.OrdinalIgnoreCase);
            })
            .ToArray();
    }

}
