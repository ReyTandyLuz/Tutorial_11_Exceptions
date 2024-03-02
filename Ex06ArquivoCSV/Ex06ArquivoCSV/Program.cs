/*Crie uma classe chamada ManipuladorCSV que contenha um método chamado LerArquivo para ler dados de
um arquivo CSV. Lance exceções apropriadas se o ficheiro não existir (FileNotFoundException) ou se ocorrer
um erro durante a leitura.*/

using Ex06ArquivoCSV.Entities;

string caminhoFcheiro, conteudoFicheiro;

do
{
    Console.Clear();
    Console.WriteLine("\nExercicio 06 - Tutorial 11");

    caminhoFcheiro = String("\nQual é o caminho do ficheiro?: ");

    try
    {
        conteudoFicheiro = ManipuladorCSV.LerArquivo(caminhoFcheiro);
        Console.WriteLine("\n" + conteudoFicheiro);
    }
    catch(Exception ex)
    {
        Console.WriteLine("\n" + ex.Message);
    }

} while (DesejaContinuar());

string String(string enunciado)
{
    string? texto;

    while (true)
    {
        Console.Write(enunciado);
        texto = Console.ReadLine();

        if (!string.IsNullOrEmpty(texto))
            return texto.Trim();

        Console.WriteLine("\n\tValor invalido!!!!!! Tente novamente");
    }
}

bool DesejaContinuar()
{
    string? texto;

    while (true)
    {
        Console.Write("\nDeseja lêr outro ficheiro? Sim/Não?: ");
        texto = Console.ReadLine();

        if (!string.IsNullOrEmpty(texto))
        {
            if (texto.ToLower() == "sim")
                return true;

            if (texto.ToLower() == "não" || texto.ToLower() == "nao")
                return false;
        }

        Console.WriteLine("\nOpção inválida!!!!! É SIM/NÃO!!!");
    }
}