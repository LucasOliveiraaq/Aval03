using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string textoCifrado = File.ReadAllText("provinhaBarbadinha.txt");
        string textoDecifrado = decifrar(textoCifrado);
        textoDecifrado = textoCifrado.Replace("@", "\n");

        string[] palindromos = palindromo(textoDecifrado);
        foreach (var item in palindromos)
        {
            switch (item)
            {
                case "gloriosa":
                    textoDecifrado = textoDecifrado.Replace(item, "gloriosa");
                    break;
                case "bondade":
                    textoDecifrado = textoDecifrado.Replace(item, "bondade");
                    break;
                case "passam":
                    textoDecifrado = textoDecifrado.Replace(item, "passam");
                    break;
            }
        }

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
        char[] caracteres = textoCifrado.ToCharArray();
        for (int i = 0; i < caracteres.Length; i++)
        {
            caracteres[i] = (char)(i % 5 == 0 ? caracteres[i] - 8 : caracteres[i] - 16);
        }
        return new string(caracteres);
    }

    static string[] palindromo(string texto)
    {
        return texto.Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Where(palavra => palavra == new string(palavra.Reverse().ToArray()))
               .ToArray();
    }
}
