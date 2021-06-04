using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersGame.Data
{
    public static class GameData
    {
        private static int defaultStartMoves = 4;
        public static string GameInfo(string playerName, int playerPossibleMoves, bool isPieceSelected)
        {
            if (playerPossibleMoves < 0) playerPossibleMoves = defaultStartMoves;

            string message =  playerName + "'s Turn ";
            if(!isPieceSelected)
                message+="\nCan select "+playerPossibleMoves+" pieces!";
            else message += "\nCan move this piece in " + playerPossibleMoves +" places!";
            return message;
        }

        public static string GameOver(string opponentName)
        {
            return opponentName.ToUpper() + " WON! \nPress 'New Game' to play again!";
        }
    }
}
