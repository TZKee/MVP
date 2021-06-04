using CheckerGame.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CheckerGame.Data
{
    public class Moves
    {
        List<int> LegalMoves;
        List<JumpMove> jumpMoves;
        BoardEncryptMatrix.BoardEncryptCodes[,] board;
        BoardEncryptMatrix boardData;
        int currentX;
        int currentY;
        struct JumpMove
        {
            public int currentPosX { get; set; }
            public int currentPosY { get; set; }
            public int previousIndex { get; set; }
            public int lastCapturedPosX { get; set; }
            public int lastCapturedPosY { get; set; }
        }

        public Moves(BoardEncryptMatrix board, int currentX, int currentY)
        {
            this.board = board.GetBoardData();
            this.boardData = board;
            this.currentX = currentX;
            this.currentY = currentY;
        }

        private void SimpleMoves()
        {
            int i = currentY;
            int j = currentX;
            if (board[i, j] == BoardEncryptMatrix.BoardEncryptCodes.DBP || board[i, j] == BoardEncryptMatrix.BoardEncryptCodes.DWK || board[i, j] == BoardEncryptMatrix.BoardEncryptCodes.DBK)
            {
                if (i - 1 != -1)
                {
                    if (j - 1 != -1)
                    {
                        if (board[i - 1, j - 1] == BoardEncryptMatrix.BoardEncryptCodes.D)
                            LegalMoves.Add((i - 1) * 8 + j - 1);
                    }
                    if (j + 1 != 8)
                    {
                        if (board[i - 1, j + 1] == BoardEncryptMatrix.BoardEncryptCodes.D)
                            LegalMoves.Add((i - 1) * 8 + j + 1);
                    }
                }
            }
            if (board[i, j] == BoardEncryptMatrix.BoardEncryptCodes.DWP || board[i, j] == BoardEncryptMatrix.BoardEncryptCodes.DWK || board[i, j] == BoardEncryptMatrix.BoardEncryptCodes.DBK)
            {
                if (i + 1 != 8)
                {
                    if (j - 1 != -1)
                    {
                        if (board[i + 1, j - 1] == BoardEncryptMatrix.BoardEncryptCodes.D)
                            LegalMoves.Add((i + 1) * 8 + j - 1);
                    }
                    if (j + 1 != 8)
                    {
                        if (board[i + 1, j + 1] == BoardEncryptMatrix.BoardEncryptCodes.D)
                            LegalMoves.Add((i + 1) * 8 + j + 1);
                    }
                }
            }
        }

        private void AdvancedMoves()
        {
            int i = currentY;
            int j = currentX;
            int previousPos = -1;
            int index = -1;
            bool noNewPath;
            jumpMoves = new List<JumpMove>();
            #region DBP
            if (board[i, j] == BoardEncryptMatrix.BoardEncryptCodes.DBP)
            {
                do
                {
                    noNewPath = true;

                    if (i - 2 > -1)
                    {
                        if (j - 2 > -1)
                        {
                            if (board[i - 2, j - 2] == BoardEncryptMatrix.BoardEncryptCodes.D && (board[i - 1, j - 1] == BoardEncryptMatrix.BoardEncryptCodes.DWK || board[i - 1, j - 1] == BoardEncryptMatrix.BoardEncryptCodes.DWP))
                            {
                                JumpMove jumpMove = new JumpMove();
                                jumpMove.currentPosY = i - 2;
                                jumpMove.currentPosX = j - 2;
                                jumpMove.previousIndex = previousPos;
                                jumpMove.lastCapturedPosY = i - 1;
                                jumpMove.lastCapturedPosX = j - 1;
                                jumpMoves.Add(jumpMove);
                                noNewPath = false;
                            }
                        }
                        if (j + 2 < 8)
                        {
                            if (board[i - 2, j + 2] == BoardEncryptMatrix.BoardEncryptCodes.D && (board[i - 1, j + 1] == BoardEncryptMatrix.BoardEncryptCodes.DWK || board[i - 1, j + 1] == BoardEncryptMatrix.BoardEncryptCodes.DWP))
                            {
                                JumpMove jumpMove = new JumpMove();
                                jumpMove.currentPosY = i - 2;
                                jumpMove.currentPosX = j + 2;
                                jumpMove.previousIndex = previousPos;
                                jumpMove.lastCapturedPosY = i - 1;
                                jumpMove.lastCapturedPosX = j + 1;
                                jumpMoves.Add(jumpMove);
                                noNewPath = false;
                            }
                        }
                    }
                    if (index < jumpMoves.Count - 1)
                    {
                        index++;
                        i = jumpMoves[index].currentPosY;
                        j = jumpMoves[index].currentPosX;
                        previousPos = jumpMoves[index].previousIndex + 1;
                    }


                } while (noNewPath == false);
            }
            #endregion DBP
            #region DWK
            if (board[i, j] == BoardEncryptMatrix.BoardEncryptCodes.DWK)
            {
                do
                {
                    noNewPath = true;

                    if (i - 2 > -1)
                    {
                        if (j - 2 > -1)
                        {
                            if (board[i - 2, j - 2] == BoardEncryptMatrix.BoardEncryptCodes.D && (board[i - 1, j - 1] == BoardEncryptMatrix.BoardEncryptCodes.DBK || board[i - 1, j - 1] == BoardEncryptMatrix.BoardEncryptCodes.DBP))
                            {
                                JumpMove jumpMove = new JumpMove();
                                jumpMove.currentPosY = i - 2;
                                jumpMove.currentPosX = j - 2;
                                jumpMove.previousIndex = previousPos;
                                jumpMove.lastCapturedPosY = i - 1;
                                jumpMove.lastCapturedPosX = j - 1;
                                jumpMoves.Add(jumpMove);
                                noNewPath = false;
                            }
                        }
                        if (j + 2 < 8)
                        {
                            if (board[i - 2, j + 2] == BoardEncryptMatrix.BoardEncryptCodes.D && (board[i - 1, j + 1] == BoardEncryptMatrix.BoardEncryptCodes.DBK || board[i - 1, j + 1] == BoardEncryptMatrix.BoardEncryptCodes.DBP))
                            {
                                JumpMove jumpMove = new JumpMove();
                                jumpMove.currentPosY = i - 2;
                                jumpMove.currentPosX = j + 2;
                                jumpMove.previousIndex = previousPos;
                                jumpMove.lastCapturedPosY = i - 1;
                                jumpMove.lastCapturedPosX = j + 1;
                                jumpMoves.Add(jumpMove);
                                noNewPath = false;
                            }
                        }
                    }
                    if (i + 2 < 8)
                    {
                        if (j - 2 > -1)
                        {
                            if (board[i + 2, j - 2] == BoardEncryptMatrix.BoardEncryptCodes.D && (board[i + 1, j - 1] == BoardEncryptMatrix.BoardEncryptCodes.DBK || board[i + 1, j - 1] == BoardEncryptMatrix.BoardEncryptCodes.DBP))
                            {
                                JumpMove jumpMove = new JumpMove();
                                jumpMove.currentPosY = i + 2;
                                jumpMove.currentPosX = j - 2;
                                jumpMove.previousIndex = previousPos;
                                jumpMove.lastCapturedPosY = i + 1;
                                jumpMove.lastCapturedPosX = j - 1;
                                jumpMoves.Add(jumpMove);
                                noNewPath = false;
                            }
                        }
                        if (j + 2 < 8)
                        {
                            if (board[i + 2, j + 2] == BoardEncryptMatrix.BoardEncryptCodes.D && (board[i + 1, j + 1] == BoardEncryptMatrix.BoardEncryptCodes.DBK || board[i + 1, j + 1] == BoardEncryptMatrix.BoardEncryptCodes.DBP))
                            {
                                JumpMove jumpMove = new JumpMove();
                                jumpMove.currentPosY = i + 2;
                                jumpMove.currentPosX = j + 2;
                                jumpMove.previousIndex = previousPos;
                                jumpMove.lastCapturedPosY = i + 1;
                                jumpMove.lastCapturedPosX = j + 1;
                                jumpMoves.Add(jumpMove);
                                noNewPath = false;
                            }
                        }
                    }
                    if (index < jumpMoves.Count - 1)
                    {
                        index++;
                        i = jumpMoves[index].currentPosY;
                        j = jumpMoves[index].currentPosX;
                        previousPos = jumpMoves[index].previousIndex + 1;
                    }


                } while (noNewPath == false);
            }
            #endregion DWK
            #region DWP
            if (board[i, j] == BoardEncryptMatrix.BoardEncryptCodes.DWP)
            {
                do
                {
                    noNewPath = true;

                    if (i + 2 < 8)
                    {
                        if (j - 2 > -1)
                        {
                            if (board[i + 2, j - 2] == BoardEncryptMatrix.BoardEncryptCodes.D && (board[i + 1, j - 1] == BoardEncryptMatrix.BoardEncryptCodes.DBK || board[i + 1, j - 1] == BoardEncryptMatrix.BoardEncryptCodes.DBP))
                            {
                                JumpMove jumpMove = new JumpMove();
                                jumpMove.currentPosY = i + 2;
                                jumpMove.currentPosX = j - 2;
                                jumpMove.previousIndex = previousPos;
                                jumpMove.lastCapturedPosY = i + 1;
                                jumpMove.lastCapturedPosX = j - 1;
                                jumpMoves.Add(jumpMove);
                                noNewPath = false;
                            }
                        }
                        if (j + 2 < 8)
                        {
                            if (board[i + 2, j + 2] == BoardEncryptMatrix.BoardEncryptCodes.D && (board[i + 1, j + 1] == BoardEncryptMatrix.BoardEncryptCodes.DBK || board[i + 1, j + 1] == BoardEncryptMatrix.BoardEncryptCodes.DBP))
                            {
                                JumpMove jumpMove = new JumpMove();
                                jumpMove.currentPosY = i + 2;
                                jumpMove.currentPosX = j + 2;
                                jumpMove.previousIndex = previousPos;
                                jumpMove.lastCapturedPosY = i + 1;
                                jumpMove.lastCapturedPosX = j + 1;
                                jumpMoves.Add(jumpMove);
                                noNewPath = false;
                            }
                        }
                    }
                    if (index < jumpMoves.Count - 1)
                    {
                        index++;
                        i = jumpMoves[index].currentPosY;
                        j = jumpMoves[index].currentPosX;
                        previousPos = jumpMoves[index].previousIndex + 1;
                    }


                } while (noNewPath == false);
            }
            #endregion DWP
            #region DBK
            if (board[i, j] == BoardEncryptMatrix.BoardEncryptCodes.DBK)
            {
                do
                {
                    noNewPath = true;

                    if (i - 2 > -1)
                    {
                        if (j - 2 > -1)
                        {
                            if (board[i - 2, j - 2] == BoardEncryptMatrix.BoardEncryptCodes.D && (board[i - 1, j - 1] == BoardEncryptMatrix.BoardEncryptCodes.DWK || board[i - 1, j - 1] == BoardEncryptMatrix.BoardEncryptCodes.DWP))
                            {
                                JumpMove jumpMove = new JumpMove();
                                jumpMove.currentPosY = i - 2;
                                jumpMove.currentPosX = j - 2;
                                jumpMove.previousIndex = previousPos;
                                jumpMove.lastCapturedPosY = i - 1;
                                jumpMove.lastCapturedPosX = j - 1;
                                jumpMoves.Add(jumpMove);
                                noNewPath = false;
                            }
                        }
                        if (j + 2 < 8)
                        {
                            if (board[i - 2, j + 2] == BoardEncryptMatrix.BoardEncryptCodes.D && (board[i - 1, j + 1] == BoardEncryptMatrix.BoardEncryptCodes.DWK || board[i - 1, j + 1] == BoardEncryptMatrix.BoardEncryptCodes.DWP))
                            {
                                JumpMove jumpMove = new JumpMove();
                                jumpMove.currentPosY = i - 2;
                                jumpMove.currentPosX = j + 2;
                                jumpMove.previousIndex = previousPos;
                                jumpMove.lastCapturedPosY = i - 1;
                                jumpMove.lastCapturedPosX = j + 1;
                                jumpMoves.Add(jumpMove);
                                noNewPath = false;
                            }
                        }
                    }
                    if (i + 2 < 8)
                    {
                        if (j - 2 > -1)
                        {
                            if (board[i + 2, j - 2] == BoardEncryptMatrix.BoardEncryptCodes.D && (board[i + 1, j - 1] == BoardEncryptMatrix.BoardEncryptCodes.DWK || board[i + 1, j - 1] == BoardEncryptMatrix.BoardEncryptCodes.DWP))
                            {
                                JumpMove jumpMove = new JumpMove();
                                jumpMove.currentPosY = i + 2;
                                jumpMove.currentPosX = j - 2;
                                jumpMove.previousIndex = previousPos;
                                jumpMove.lastCapturedPosY = i + 1;
                                jumpMove.lastCapturedPosX = j - 1;
                                jumpMoves.Add(jumpMove);
                                noNewPath = false;
                            }
                        }
                        if (j + 2 < 8)
                        {
                            if (board[i + 2, j + 2] == BoardEncryptMatrix.BoardEncryptCodes.D && (board[i + 1, j + 1] == BoardEncryptMatrix.BoardEncryptCodes.DWK || board[i + 1, j + 1] == BoardEncryptMatrix.BoardEncryptCodes.DWP))
                            {
                                JumpMove jumpMove = new JumpMove();
                                jumpMove.currentPosY = i + 2;
                                jumpMove.currentPosX = j + 2;
                                jumpMove.previousIndex = previousPos;
                                jumpMove.lastCapturedPosY = i + 1;
                                jumpMove.lastCapturedPosX = j + 1;
                                jumpMoves.Add(jumpMove);
                                noNewPath = false;
                            }
                        }
                    }
                    if (index < jumpMoves.Count - 1)
                    {
                        index++;
                        i = jumpMoves[index].currentPosY;
                        j = jumpMoves[index].currentPosX;
                        previousPos = jumpMoves[index].previousIndex + 1;
                    }


                } while (noNewPath == false);
            }
            #endregion DBK
            if (jumpMoves.Count>0)
            foreach (JumpMove jump in jumpMoves)
            {
                LegalMoves.Add(jump.currentPosY * 8 + jump.currentPosX);
            }
        }

        public void RemoveCapturedPieces(int x1, int y1, int x2, int y2)
        {
            LegalMoves = new List<int>();
            currentX = y1;
            currentY = x1;
            int index = 100;
            AdvancedMoves();
            foreach (JumpMove jump in jumpMoves)
            {
                Console.WriteLine(jump.lastCapturedPosY + " " + jump.lastCapturedPosX);
                if (jump.currentPosX == y2 && jump.currentPosY == x2)
                {
                    boardData.AddDarkSpot(jump.lastCapturedPosY, jump.lastCapturedPosX);
                    index = jump.previousIndex;
                }
            }
            if(index!=100)
            while(index!=-1)
            {
                    foreach (JumpMove jump in jumpMoves)
                    {
                        if(jump.previousIndex==index-1)
                        {
                            boardData.AddDarkSpot(jump.lastCapturedPosY, jump.lastCapturedPosX);
                            index = jump.previousIndex;
                        }
                    }
            }
        }
        private void CheckForMoves()
        {
            LegalMoves = new List<int>();
            SimpleMoves();
            AdvancedMoves();
        }

        public int GetMovesForCurrentPiece()
        {
            CheckForMoves();
            return LegalMoves.Count();
        }

        public List<int> GetMovesList()
        {
            CheckForMoves();
            return LegalMoves;
        }
    }
}
