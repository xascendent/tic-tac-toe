using TicTacToe;

Console.WriteLine("Hello, Welcome to Y3 TICTACTOE");
Console.WriteLine("Pick your game type (1- pvp, 2- pve):");
int gameType = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Pick your game piece (1- X, 2- O):");
var gamePiece = Console.ReadLine();

string[,] gameBoard = new string[3, 3];
PlayerVsPlayer playerVsPlayer = new PlayerVsPlayer();

Console.WriteLine("_0,0_|_0,1_|_0,2_");
Console.WriteLine("_1,0_|_1,1_|_1,2_");
Console.WriteLine("_2,0_|_2,1_|_2,2_");

// game loop 
string currentPlayer = "X";
int row, col, moveResult;

while (playerVsPlayer.ActiveGame)
{
    Console.WriteLine($"Pick your row player {currentPlayer} (0-2) :");
    row = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine($"Pick your col player {currentPlayer} (0-2) :");
    col = Convert.ToInt32(Console.ReadLine());
    moveResult = playerVsPlayer.MoveResult(gameBoard, currentPlayer, row, col);

    if (moveResult == 0)
    {
        Console.WriteLine($"Move is invalid splace already taken");
    }
    if(moveResult == 1)
    {
        gameBoard[row, col] = currentPlayer;
        if (currentPlayer == "X")
        {
            currentPlayer = "O";
        }
        else
        {
            currentPlayer = "X";
        }
    }
    if (moveResult == 2)
    {
        Console.WriteLine($"X wins!");
    }
    if (moveResult == 3)
    {
        Console.WriteLine($"O wins!");
    }
    if (moveResult == 4)
    {
        Console.WriteLine($"Cat Game!");
    }
}



// See https://aka.ms/new-console-template for more information
Console.WriteLine("Game Over thank you for playing!");
