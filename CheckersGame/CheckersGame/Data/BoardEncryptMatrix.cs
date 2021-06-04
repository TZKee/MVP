using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CheckerGame.Data
{
    public class BoardEncryptMatrix
    {
        public enum BoardEncryptCodes
        {
            D, // dark
            W, // white
            DBP, // dark with black pawn
            DWP, // dark with white pawn
            DBK, // dark with black king
            DWK, // dark with white king
        }

        BoardEncryptCodes[,] board = new BoardEncryptCodes[8, 8];
        Point clickPoint1;
        Point clickPoint2;
        int clickIndex;

        public BoardEncryptMatrix()
        {
            clickPoint1 = new Point();
            clickPoint2 = new Point();
            clickIndex = -1;
            SetOrResetBoard(); // build board first time (new game)
        }

        private void SetOrResetBoard()
        {
            for(int index_i=0; index_i < 8; index_i++)
            {
                for(int index_j=0; index_j < 8; index_j++)
                {
                    if (index_i < 3 && (index_i + index_j) % 2 == 1)
                    {
                        board[index_i, index_j] =  BoardEncryptCodes.DWP; // dark with white pwan;
                    }
                    else if (index_i > 4 && (index_i + index_j) % 2 == 1)
                    {
                        board[index_i, index_j] = BoardEncryptCodes.DBP; // dark with dark pwan;
                    }
                    else if ((index_i + index_j) % 2 == 0)
                    {
                        board[index_i, index_j] = BoardEncryptCodes.W; // white
                    }
                    else
                    {
                        board[index_i, index_j] = BoardEncryptCodes.D; // dark
                    }
                }
            }
        }

        public bool IsFirstTimeClicked()
        {
            if (clickIndex % 2 == 0) return true;
            return false;
        }
        public BoardEncryptCodes[,] GetBoardData()
        {
            return board;
        }

        public void AddDarkSpot(int x, int y)
        {
            board[x,y] = BoardEncryptCodes.D;
        }

        public string RestoreBoardDataFromSave(string value)
        {
            string[] separators = new string[] { ",", ".", "!", "\'", " ", "\'s" };
            List<string> keys = new List<string>();
            foreach (string word in value.Split(separators, StringSplitOptions.RemoveEmptyEntries))
                keys.Add(word);
            int index = 0;
            for (int index_i = 0; index_i < 8; index_i++)
            {
                for (int index_j = 0; index_j < 8; index_j++)
                {
                    switch (keys[index])
                    {
                        case "D":
                            board[index_i, index_j] = BoardEncryptCodes.D;
                            break;
                        case "W":
                            board[index_i, index_j] = BoardEncryptCodes.W;
                            break;
                        case "DBP":
                            board[index_i, index_j] = BoardEncryptCodes.DBP;
                            break;
                        case "DWP":
                            board[index_i, index_j] = BoardEncryptCodes.DWP;
                            break;
                        case "DBK":
                            board[index_i, index_j] = BoardEncryptCodes.DBK;
                            break;
                        case "DWK":
                            board[index_i, index_j] = BoardEncryptCodes.DWK;
                            break;
                        default:
                            break;
                    }
                    index++;
                }
            }
            Console.WriteLine(keys[8]+" " + board[1, 0].ToString());
            return keys[index];
        }

        public string GetBoardDataString()
        {
            string output = String.Empty;
            for (int index_i = 0; index_i < 8; index_i++)
            {
                for (int index_j = 0; index_j < 8; index_j++)
                {
                    output += board[index_i, index_j] + " ";
                }
                output += "\n";
            }
            return output;
        }

        public void ButtonClickedEvent(Point point)
        {
            clickIndex++;
            if(clickIndex%2==1)
            {
                Moves moves = new Moves(this, (int)clickPoint1.X, (int)clickPoint1.Y);
                clickPoint2 = point;
                moves.RemoveCapturedPieces((int)clickPoint1.X, (int)clickPoint1.Y, (int)clickPoint2.X, (int)clickPoint2.Y);
                BoardEncryptCodes aux = board[(int)clickPoint1.X, (int)clickPoint1.Y];
                board[(int)clickPoint1.X, (int)clickPoint1.Y] = board[(int)clickPoint2.X, (int)clickPoint2.Y];
                board[(int)clickPoint2.X, (int)clickPoint2.Y] = aux;
                clickPoint1 = new Point();
                clickPoint2 = new Point();
            }
            else
            {
                clickPoint1 = point;
                clickPoint2 = new Point();
            }
        }   
        
        public void TransformPawnInKing(bool black, int x, int y)
        {
            if (black)
                board[x, y] = BoardEncryptCodes.DBK;
            else board[x, y] = BoardEncryptCodes.DWK;
        }
    }
}
