using System;

class point29
{
    static void Main(string[] args)
    {
       
        Console.WriteLine("Ingrese el puente: ");
        string Bridge = Console.ReadLine();

        

        if (ValidateBridge(Bridge))
        {
            Console.WriteLine("Invalido");
        }
        else
        {
            Console.WriteLine("valido");
        }

    }

    public static bool ValidateBridge(string Bridge)
    {
        int n = Bridge.Length;

        if (!(Bridge.Substring(0, 1).Equals("*") && Bridge.Substring(n - 1, 1).Equals("*")))
        {
            return false;
        }

        for (int a = 1; a < n - 1; a++)
        {
            string Piece = Bridge.Substring(a, 1);

            if (!(Piece.Equals("=") || Piece.Equals("+")))
            {
                return false;
            }
        }

        int Reinforcement = 0;

        for (int a = 1; a < n / 2; a++)
        {
            string Pi = Bridge.Substring(a, 1);
            string Pd = Bridge.Substring(n - a - 1, 1);

            if (Pi.Equals(Pd))
            {
                return false;
            }

            if (Pi.Equals("+"))
            {
                Reinforcement++;
            }
            else
            {
                Reinforcement = 0;
            }

            if (Reinforcement == 3)
            {
                return false;
            }
        }

        return true;
    }
}