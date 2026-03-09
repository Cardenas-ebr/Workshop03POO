using System;

class Exercise36
{
    static void Main(string[] args)
    {
        Console.Write("Ingrese ubicación de los frutos: ");
        string fruits = Console.ReadLine();
        fruits = fruits.Replace(",", ""); // <-- elimina comas

        Console.Write("Ingrese posición inicial del caballo: ");
        string knight = Console.ReadLine();

        Console.Write("Ingrese los movimientos del caballo: ");
        string moves = Console.ReadLine();
        moves = moves.Replace(",", ""); // <-- elimina comas para procesar Substring

        char[,] board = new char[8, 8];

        // Llenar tablero con espacios
        for (int r = 0; r < 8; r++)
        {
            for (int c = 0; c < 8; c++)
            {
                board[r, c] = ' ';
            }
        }

        // Colocar frutos en el tablero
        int k = 0;
        while (k + 2 < fruits.Length) // +2 para evitar IndexOutOfRange
        {
            char col = fruits[k++];
            char row = fruits[k++];
            char item = fruits[k++];

            int posRow = RowIndex(row);
            int posCol = ColIndex(col);

            if (posRow >= 0 && posCol >= 0)
                board[posRow, posCol] = item;
        }

        // Posición inicial del caballo
        char kCol = knight[0];
        char kRow = knight[1];

        int posKnightRow = RowIndex(kRow);
        int posKnightCol = ColIndex(kCol);

        string harvest = "";

        if (IsInsideBoard(posKnightRow, posKnightCol) && board[posKnightRow, posKnightCol] != ' ')
        {
            harvest += board[posKnightRow, posKnightCol];
        }

        // Procesar movimientos del caballo
        int i = 0;
        while (i + 1 < moves.Length)
        {
            string movement = moves.Substring(i, 2);

            switch (movement)
            {
                case "UL":
                    posKnightRow -= 2; posKnightCol -= 1;
                    break;
                case "UR":
                    posKnightRow -= 2; posKnightCol += 1;
                    break;
                case "LU":
                    posKnightRow -= 1; posKnightCol -= 2;
                    break;
                case "LD":
                    posKnightRow += 1; posKnightCol -= 2;
                    break;
                case "RU":
                    posKnightRow -= 1; posKnightCol += 2;
                    break;
                case "RD":
                    posKnightRow += 1; posKnightCol += 2;
                    break;
                case "DL":
                    posKnightRow += 2; posKnightCol -= 1;
                    break;
                case "DR":
                    posKnightRow += 2; posKnightCol += 1;
                    break;
            }

            // Recolectar fruto si el caballo está dentro del tablero
            if (IsInsideBoard(posKnightRow, posKnightCol) && board[posKnightRow, posKnightCol] != ' ')
            {
                harvest += board[posKnightRow, posKnightCol];
            }

            i += 2; // siguiente movimiento
        }

        Console.WriteLine($"Los frutos recogidos son: {harvest}");
    }

    public static int RowIndex(char r)
    {
        switch (r)
        {
            case '8': return 0;
            case '7': return 1;
            case '6': return 2;
            case '5': return 3;
            case '4': return 4;
            case '3': return 5;
            case '2': return 6;
            case '1': return 7;
            default: return -1;
        }
    }

    public static int ColIndex(char c)
    {
        switch (c)
        {
            case 'A': return 0;
            case 'B': return 1;
            case 'C': return 2;
            case 'D': return 3;
            case 'E': return 4;
            case 'F': return 5;
            case 'G': return 6;
            case 'H': return 7;
            default: return -1;
        }
    }

    public static bool IsInsideBoard(int row, int col)
    {
        return row >= 0 && row < 8 && col >= 0 && col < 8;
    }
}
