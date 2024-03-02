/*Desenvolva um jogo simples de adivinhação onde o utilizador tenta adivinhar um número gerado
aleatoriamente. Crie exceções personalizadas (NumeroInvalidoException, TentativasEsgotadasException)
para lidar com entradas inválidas e tentativas esgotadas, respetivamente.*/

using Ex07JogoAdivinar.Entities;
using System.Globalization;

const int NUMERO_MINIMO = 1, NUMERO_MAXIMO = 10, NUMERO_TENTATIVAS = 3;

Random random = new();
int numeroGanhador, numeroActual;

do
{
    numeroGanhador = random.Next(NUMERO_MINIMO, NUMERO_MAXIMO);

    Console.Clear();
    Console.WriteLine("\nExercicio 07 - Tutorial 11");

    Jogo(numeroGanhador, NUMERO_TENTATIVAS);

} while (DesejaContinuar());

void Jogo(int numeroGanhador, int numeroTentativas)
{

    string mensaje; 

    do
    {
        try
        {
            mensaje = numeroTentativas == 1 ? $"Têm {numeroTentativas} tentativa" : $"Têm {numeroTentativas} tentativas";

            numeroActual = Int($"\nDê um número entre {NUMERO_MINIMO} e {NUMERO_MAXIMO} ({mensaje}): ");

            if (numeroActual < NUMERO_MINIMO || numeroActual > NUMERO_MAXIMO)
                throw new NumeroInvalidoException("O número introduzido não é valido");

            if (numeroActual == numeroGanhador)
            {
                Console.WriteLine("\nParabéns tens adivinado o número ganhador, Yay!");
                return;
            }

            numeroTentativas -= numeroTentativas > 1 ? 1 : throw new TentativasEsgotadasException("Opss! As tentativas estão esgotadas ._.");

        }
        catch (NumeroInvalidoException ex)
        {
            Console.WriteLine($"\nNúmero invalido: {ex.Message}");
            continue;
        }
        catch (TentativasEsgotadasException ex)
        {
            Console.WriteLine($"\nTentativas esgotadas: {ex.Message}");
            return;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nErro inesperado: {ex.Message}");
        }

    } while (true);
}

int Int(string enunciado)
{
    while (true)
    {
        Console.Write(enunciado);
        if (int.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out int result))
            return result;

        Console.WriteLine("\nNúmero inválido!!!! Tente novamente");
    }
}

bool DesejaContinuar()
{
    string? texto;

    while (true)
    {
        Console.Write("\nDeseja tentar adivinhar outro número? Sim/Não?: ");
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