using System;

namespace TestProject
{
    class Tictactoe
    {
        static public int[,] board;
        static public int result = -1;
        static void Main(string[] args)
        {
            StartGame();
        
            
        }

        static public void StartGame()
        {
            board = new int[3, 3];
            Console.WriteLine("Welcome to Tic tac toe");
            ComputerTurn();
            //PlayerTurn();


        }

        static public void PlayerTurn()
        {
            ShowBoard();
            Console.WriteLine("enter a number 1-9 to pick a square");
            string square = Console.ReadLine();
            if ( square.Equals("1") && board[0,0] == 0)
            {
                board[0, 0] = 1;

            }
             else if (square.Equals("2") && board[0, 1] == 0)
            {
                board[0, 1] = 1;
            }
             else if (square.Equals("3") && board[0, 2] == 0)
            {
                board[0, 2] = 1;

            }
            else if (square.Equals("4") && board[1, 0] == 0)
            {
                board[1, 0] = 1;

            }
            else if (square.Equals("5") && board[1, 1] == 0)
            {
                board[1, 1] = 1;
            }
            else if (square.Equals("6") && board[1, 2] == 0)
            {
                board[1, 2] = 1;

            }
            else if (square.Equals("7") && board[2, 0] == 0)
            {
                board[2, 0] = 1;

            }
            else if (square.Equals("8") && board[2, 1] == 0)
            {
                board[2, 1] = 1;

            }
            else if (square.Equals("9") && board[2, 2] == 0)
            {
                board[2, 2] = 1;

            }
            else
            {
                Console.WriteLine("Invalid input, try again");
                PlayerTurn();
                return;
            }
            if (IsOver())
            {
                EndGame();
            }
            ShowBoard();
            ComputerTurn();
        }


        static public void ComputerTurn()
        {
            int bestScore = -100;
            int[] bestMove = new int[2];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    
                    if (board[i, j] == 0)
                    {
                        board[i, j] = 2;
                        int score = Minimax(board, 0, false, -1000, 1000);
                        board[i, j] = 0;
                        if (score > bestScore)
                        {
                            bestScore = score;
                            bestMove[0] = i;
                            bestMove[1] = j;
                        }
                    }

                }
            }
            board[bestMove[0], bestMove[1]] = 2;
            
            if (IsOver())
            {
                EndGame();
            } else
            {
                PlayerTurn();
            }
            
        }
        public static int GetScore(int a)
        {
            if (a == 0)
            {
                return 0;
            } else if (a == 1)
            {
                return -10;
            } else if (a == 2)
            {
                return 10;
            }
            return 0;
        }
        public static int Minimax(int[,] board, int depth, bool IsMaximizing, int alpha, int beta)
        {
            IsOver();
            if (result != -1)
            {
                int score = GetScore(result);
                return score;  
            }
            if (IsMaximizing)
            {
                int bestScore = -100;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board[i, j] == 0)
                        {
                            board[i, j] = 2;
                            int score = Minimax(board, depth + 1, false, alpha, beta);
                            board[i, j] = 0;
                            if (score > bestScore)
                            {
                                bestScore = score;
                            }
                            if (bestScore > alpha)
                            {
                                alpha = bestScore;
                            }
                            if (beta <= alpha)
                            {
                                break;
                            }
                        }

                    }
                }
                return bestScore;

            } else
            {
                int bestScore = 100;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board[i, j] == 0)
                        {
                            board[i, j] = 1;
                            int score = Minimax(board, depth + 1, true, alpha, beta);
                            board[i, j] = 0;
                            if (score < bestScore)
                            {
                                bestScore = score;
                            }
                            if (bestScore < beta)
                            {
                                beta = bestScore;
                            }
                            if (beta <= alpha)
                            {
                                break;
                            }
                        }

                    }
                    
                }
                return bestScore;
            }

        }
        static public bool IsOver()
        {
            bool isFull = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ( board[i,j] ==0)
                    {
                        isFull = false;
                    }


                }
            }

            
            // Horizontal win 
            if (board[0,0] == board[0, 1] && board[0,0] == board[0, 2] && board[0,0] != 0)
            {
                result = board[0, 0];
                return true;
            }
            if (board[1, 0] == board[1, 1] && board[1, 0] == board[1, 2] && board[1, 0] != 0)
            {
                result = board[1, 0];
                return true;
            }
            if (board[2, 0] == board[2, 1] && board[2, 0] == board[2, 2] && board[2, 0] != 0)
            {
                result = board[2, 0];
                return true;
            }
            // Vertical win
            if (board[0,0] == board[1,0] && board[0,0] == board[2,0] && board[0, 0] != 0)
            {
                result = board[0, 0];
                return true;
            }
            if (board[0, 1] == board[1, 1] && board[0, 1] == board[2, 1] && board[0, 1] != 0)
            {
                result = board[0, 1];
                return true;
            }
            if (board[0, 2] == board[1, 2] && board[0, 2] == board[2, 2] && board[0, 2] != 0)
            {
                result = board[0, 2];
                return true;
            }
            // Diagonal Win
            if( board[2,0] == board[1,1] && board[2,0] == board[0,2] && board[2, 0] != 0)
            {
                result = board[2, 0];
                return true;
            }
            if (board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2] && board[0, 0] != 0)
            {
                result = board[0, 0];
                return true;
            }
            if (isFull)
            {
                result = 0;
                return true;
               
            }
            result = -1;
            return false;

        }

        static public void ShowBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                
                Console.Write("\n");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(" | ");
                    Console.Write(board[i, j]);
                    
                }
                Console.Write(" | ");
            }
            Console.Write("\n");
        }
        static public void EndGame()
        {
            ShowBoard();
            Console.WriteLine("Game is over, press any button to quit");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}
