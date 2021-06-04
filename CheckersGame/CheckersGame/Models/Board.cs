using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CheckersGame.Models
{
    public enum CellColor
    {
        Dark,
        Light,
        DarkWithWhitePawnPiece,
        DarkWithBlackPawnPiece,
        DarkWithWhiteKingPiece,
        DarkWithBlackKingPiece
    }

    public class Board: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private CellColor cellColor;

        public CellColor CellColor
        {
            get { return cellColor; }
            set { cellColor = value; OnPropertyChanged("CellColor"); }
        }

        private Point cellPosition;

        public Point CellPosition
        {
            get { return cellPosition; }
            set { cellPosition = value; OnPropertyChanged("CellPosition"); }
        }

        private bool isHitTestVisible = true;

        public bool IsHitTestVisible
        {
            get { return isHitTestVisible; }
            set { isHitTestVisible = value; OnPropertyChanged("IsHitTestVisible"); }
        }

    }
}
