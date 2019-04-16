using System;
using System.Threading;
using System.Text.RegularExpressions;
namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            while(!board.completed)
            {
                board.PrintBoard();
                System.Console.Write("\nenter move - ");
                board.Move(Console.ReadLine());
            }
            Console.ReadKey();
        }
    }
    
    public class Board
    {
        public string[,] board = new string[8,8];
        public bool completed { get; set; }
        public char currentPlayer;
        public Board()
        {
            for(int i = 0; i < 8; i++)
                for(int j = 0; j < 8; j++)
                    board[i,j]="";
            board[0,0] = board[0,7] = "E1";
            board[7,0] = board[7,7] = "E2";
            board[0,1] = board[0,6] = "H1";
            board[7,1] = board[7,6] = "H2";
            board[0,2] = board[0,5] = "C1";
            board[7,2] = board[7,5] = "C2";
            board[0,3] = "K1";
            board[0,4] = "Q1";
            board[7,4] = "K2";
            board[7,3] = "Q2";
            for(int i = 0; i < 8; i++)
            {
                board[1,i] = "S1";
                board[6,i] = "S2";
            }
            currentPlayer = '1';
            completed = false;
        }

        public void PrintBoard()
        {
            Console.Clear();
            System.Console.WriteLine("    A   B   C   D   E   F   G   H ");
            System.Console.WriteLine("  +---+---+---+---+---+---+---+---+");
            for(int i = 0; i < 8; i++)
            {
                System.Console.Write((i+1) + " |");
                for(int j = 0; j < 8; j++)
                {
                    System.Console.Write(" "); 
                    Print(board[i,j]);
                    System.Console.Write(" |");
                }
                System.Console.WriteLine("\n  +---+---+---+---+---+---+---+---+");
            }
        }
        
        public void Move(string input)
        {
            input = input.ToLower();
            if(!Regex.IsMatch(input, "[a-h][1-8][a-h][1-8]"))
            {
                System.Console.WriteLine("Invalid Input..try again");
                Thread.Sleep(500);
                return;
            }
            int x1, y1, x2, y2;
            x1 = input[1] - 49;
            y1 = input[0] - 97;
            x2 = input[3] - 49;
            y2 = input[2] - 97;
            // System.Console.WriteLine($"x1 - {x1} y1 - {y1} x2 - {x2} y2 - {y2}");
            if(!IsValidMove(x1, y1, x2, y2))
            {
                System.Console.WriteLine("Invalid Move..try again");
                Thread.Sleep(800);
                return;
            }
            currentPlayer =  currentPlayer == '1' ? '2' : '1';
            if(board[x2,y2] != "" && board[x2,y2][0] == 'K')
            {
                System.Console.WriteLine("Match Ended...\nPlayer" +
                                            (board[x1,y1][1] == '1'? "1 - Red " : "2 - Green ") + "Wins...!!!");
                completed = true;
            }
            board[x2,y2] = board[x1,y1];
            board[x1,y1] = "";
        }

        private bool IsValidMove(int x1, int y1,int x2, int y2)
        {
            if(board[x1,y1] != "" && board[x1,y1][1] != currentPlayer)
            {
                System.Console.WriteLine("its not your turn...");
                return false;
            }
            if(board[x1,y1] == "" || (board[x2,y2] != "" && board[x2,y2][1]==board[x1,y1][1]))
                return false;
            switch (board[x1,y1][0])
            {
                case 'S': return Soldier.IsValid(x1,y1,x2,y2, ref board);
                case 'K': return King.IsValid(x1,y1,x2,y2, ref board);
                case 'Q': return Queen.IsValid(x1,y1,x2,y2, ref board);
                case 'E': return Elephant.IsValid(x1,y1,x2,y2, ref board);
                case 'C': return Camel.IsValid(x1,y1,x2,y2, ref board);
                case 'H': return Horse.IsValid(x1,y1,x2,y2, ref board);
            }
            return false;
        }

        private void Print(string coin)
        {
            if(coin == "")
            {
                System.Console.Write(" ");
                return;
            }
            if(coin[1] == '1')  
            {
                Console.ForegroundColor = coin[0] == 'K' ? ConsoleColor.DarkRed : ConsoleColor.Red;
            }    
            else
            {
                Console.ForegroundColor = coin[0] == 'K' ? ConsoleColor.DarkGreen : ConsoleColor.Green;
            }
            System.Console.Write(coin[0]);
            Console.ResetColor();
        } 
    }
    
    class Camel
    {
        public static bool IsValid(int x1, int y1, int x2, int y2, ref string[,] board)
        {
            if (Math.Abs(x2 - x1) == Math.Abs(y2 - y1))
            {
                while (x1+1 < x2 && y1+1 < y2)
                {
                    if (board[++x1, ++y1] != "")
                        return false;
                }
                while (x1+1 < x2 && y1-1 > y2)
                {
                    if (board[++x1, --y1] != "")
                        return false;
                }
                while (x1-1 > x2 && y1+1 < y2)
                {
                    if (board[--x1, ++y1] != "")
                        return false;
                }
                while (x1-1 > x2 && y1-1 > y2)
                {
                    if (board[--x1, --y1] != "")
                        return false;
                }
                return true;
            }
            return false;
        }
    }
    
    class Elephant
    {
        public static bool IsValid(int x1, int y1, int x2, int y2, ref string[,] board)
        {
            while(x1 == x2 && y1+1 < y2)
            {
                if(board[x1,++y1] != "")
                    return false;
            }
            while(x1 == x2 && y1-1 > y2)
            {
                if(board[x1,--y1] != "")
                    return false;
            }
            while(x1+1 < x2 && y1 == y2)
            {
                if(board[++x1,y1] != "")
                    return false;
            }
            while(x1-1 > x2 && y1 == y2)
            {
                if(board[--x1,y1] != "")
                    return false;
            }
            return true;
        }
    }
    
    class Horse
    {
        public static bool IsValid(int x1, int y1, int x2, int y2, ref string[,] board)
        {
            if ((Math.Abs(x1 - x2) == 2 && Math.Abs(y1 - y2) == 1) || 
                (Math.Abs(x2 - x1) == 1 && Math.Abs(y2 - y1) == 2))
                return true;
            return false;
        }
    }
    
    class King
    {
        public static bool IsValid(int x1, int y1,int x2, int y2,ref string[,] board)
        {
            if(!(Math.Abs(x2-x1)<=1 && Math.Abs(y2-y1)<=1))
                return false;
            return true;
        }
    }
    
    class Queen
    {
        public static bool IsValid(int x1, int y1,int x2, int y2,ref string[,] board)
        {
            if(Camel.IsValid(x1, y1, x2, y2, ref board) || Elephant.IsValid(x1, y1, x2, y2, ref board))
                return true;
            return false;
        }
    }
    
    class Soldier
    {
        public static bool IsValid(int x1, int y1,int x2, int y2,ref string[,] board)
        {
            if(board[x1,y1][1] == '1')
            {
                if(x2-x1 == 1 && y1 == y2 && board[x2,y2] == "")
                    return true;
                else if(x2-x1 == 1 && Math.Abs(y1-y2)==1 && board[x2,y2][1] == '2')
                    return true;
                else if(x2-x1==2 && y1 == y2 && board[x2,y2] == "" && board[x2-1,y2] == "" && x1==1)
                    return true;
            }
            else if(board[x1,y1][1] == '2')
            {
                if(x1-x2 == 1 && y1 == y2 && board[x2,y2] == "")
                    return true;
                else if(x1-x2 == 1 && Math.Abs(y1-y2)==1 && board[x2,y2][1] == '1')
                    return true;
                else if(x1-x2==2 && y1 == y2 && board[x2,y2] == "" && board[x2+1,y2] == "" && x1==6)
                    return true;
            }
            return false;
        }
    }
}


