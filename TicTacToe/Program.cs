using System;

namespace TicTacToe;

class Program
{
    static void Main()
    {

        var (IconPlayer1, IconPlayer2) = IconSelection();
        char[,] gameBoard = new char[3, 3];
        
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                gameBoard[i, j] = ' ';
            }
        }
        
        for (int i = 0; i < 9; i++)
        {
            drawBoard(gameBoard);

            if (i % 2 == 0)
            {
                if (IconPlayer1 == 'X')
                {
                    var (row, col) = ReadMove(gameBoard, 1);
                    gameBoard[row, col] = IconPlayer1;
                }
                else
                {
                    var (row, col) = ReadMove(gameBoard, 2);
                    gameBoard[row, col] = IconPlayer2;
                }
                
            }
            else
            {
                if (IconPlayer1 == 'O')
                {
                    var (row, col) = ReadMove(gameBoard, 1);
                    gameBoard[row, col] = IconPlayer1;
                }
                else
                {
                    var (row, col) = ReadMove(gameBoard, 2);
                    gameBoard[row, col] = IconPlayer2;
                }
            }
            
        }
        
        drawBoard(gameBoard);
    }
    
    
    static void drawBoard(char[,] board)
    {
        Console.WriteLine();
        Console.WriteLine("    1   2   3");
        
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"{i + 1}   {board[i, 0]} | {board[i, 1]} | {board[i, 2]}");

            if (i < 2)
            {
                Console.WriteLine("   ---+---+---");
            }
        }
        Console.WriteLine();
    }
    
    static (int row, int col) ReadMove(char[,] board, int numPlayer)
    {
        while (true)
        {
            Console.Write($"Ход игрока {numPlayer}. Введите строку и столбец (1-3) через пробел, например 2 3: ");
            string[] parts = (Console.ReadLine() ?? "").Split(' ',  StringSplitOptions.RemoveEmptyEntries);
            
            if (parts.Length != 2 || !int.TryParse(parts[0], out int row) || !int.TryParse(parts[1], out int col))
            {
                Console.WriteLine("Нужно ввести два числа через пробел. Попробуй ещё раз.");
                continue;
            }

            row--;
            col--;

            if (row < 0 || row > 2 || col < 0 || col > 2)
            {
                Console.WriteLine("Клетка вне поля. Числа должны быть от 1 до 3.");
                continue;
            }

            if (board[row, col] != ' ')
            {
                Console.WriteLine("Эта клетка уже занята. Сходи ещё раз");
                continue;
            }

            return (row, col);
        }
    }

    static (char player1, char player2) IconSelection()
    {
        string playerX, playerO;

        while (true)
        {
            Console.Write("Напишите номер игрока, который играет за 'X' (1 или 2): ");
            playerX = Console.ReadLine();

            if (playerX != "1" && playerX != "2")
            {
                Console.WriteLine("Неверный ввод. Должно быть число (1 или 2)!");
                continue;
            }
            
            Console.Write("Напишите номер игрока, который играет за 'O' (1 или 2): ");
            playerO = Console.ReadLine();
            
            if (playerO != "1" && playerO != "2")
            {
                Console.WriteLine("Неверный ввод. Должно быть число (1 или 2)!");
                continue;
            }

            if (playerX == playerO)
            {
                Console.WriteLine("Игроки не могут иметь одинаковые значки!");
                continue;
            }

            return playerX == "1" ? ('X', 'O') : ('O', 'X');
        }
    }
    
    
}
