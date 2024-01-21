using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class PlayerVsPlayer
    {

        //Console.WriteLine("_1_|_2_|_3_");
        //Console.WriteLine("_4_|_5_|_6_");
        //Console.WriteLine("_7_|_8_|_9_");

        // if MoveResult is 0 then move is invalid
        // if MoveResult is 1 then move is valid
        // if MoveResult is 2 then game is over X wins
        // if MoveResult is 3 then game is over O wins
        // if MoveResult is 4 then game is over draw

        public bool ActiveGame = true;

        public int MoveResult(string[,] gameBoard, string playerToken, int rowNumber, int columnNumber)
        {            
            // test if the location is already taken
            if (gameBoard[rowNumber, columnNumber] != null)
            {                
                return 0; // invalid move
            }
            else
            {
                gameBoard[rowNumber, columnNumber] = playerToken;                
            }
            // check for win X
            if (CheckForWin(gameBoard, "X") == true) {
                ActiveGame = false;
                return 2; };
            // check for win O
            if (CheckForWin(gameBoard, "O") == true) {
                ActiveGame = false;
                return 3; } ;
            // check for draw
            if (CheckForDraw(gameBoard) == true) {
                ActiveGame = false;
                return 4; } ;
            return 1;
        }
        public bool CheckForDraw(string[,] gameBoard)
        {
            // check if all locations are taken
            for (int row = 0; row < 3; row++) { 
                for(int col = 0; col < 3; col++)
                {
                    if (gameBoard[row, col] == null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool CheckForWin(string[,] gameBoard, string playerToken)
        {            
            // see if any rows are winners for X
            if (CheckRowForWin(gameBoard, playerToken, 0) == true) { return true; }
            if (CheckRowForWin(gameBoard, playerToken, 1) == true) { return true; }
            if (CheckRowForWin(gameBoard, playerToken, 2) == true) { return true; }

            // see if any cols are winners for X
            if (CheckColForWin(gameBoard, playerToken, 0) == true) { return true; }
            if (CheckColForWin(gameBoard, playerToken, 1) == true) { return true; }
            if (CheckColForWin(gameBoard, playerToken, 2) == true) { return true; }

            // see if any crosses are winners for X
            if (CheckCrossForWin(gameBoard, playerToken, 1) == true) { return true; }
            if (CheckCrossForWin(gameBoard, playerToken, 2) == true) { return true; }

            return false;
        }

        public bool CheckRowForWin(string[,] gameBoard, string playerToken, int rowNumber)
        {   
            if (gameBoard[rowNumber, 0] == playerToken && gameBoard[rowNumber, 1] == playerToken && gameBoard[rowNumber, 2] == playerToken)
            {
                return true;
            }
            return false;
        }

        public bool CheckColForWin(string[,] gameBoard, string playerToken, int colNumber)
        {
            if (gameBoard[0, colNumber] == playerToken && gameBoard[1, colNumber] == playerToken && gameBoard[0, colNumber] == playerToken)
            {
                return true;
            }
            return false;
        }

        public bool CheckCrossForWin(string[,] gameBoard, string playerToken, int crossNumber)
        {            
            if(crossNumber == 1)
            {
                if (gameBoard[0, 0] == playerToken && gameBoard[1, 1] == playerToken && gameBoard[2, 2] == playerToken)
                {
                    return true;
                }
            }
            if (crossNumber == 2)
            {
                if (gameBoard[0, 2] == playerToken && gameBoard[1, 1] == playerToken && gameBoard[2, 0] == playerToken)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
