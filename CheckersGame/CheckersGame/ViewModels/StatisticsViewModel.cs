using CheckerGame.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersGame.ViewModels
{
    public class StatisticsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public StatisticsViewModel()
        {
            StatisticsData statisticsData = new StatisticsData();
            string[] data = statisticsData.ReadStatistics();
            WinsBlack = "Black won "+data[0] + " times!";
            WinsWhite = "White won "+data[1] + " times!";
        }

        private string winsBlack;
        public string WinsBlack
        {
            get { return winsBlack; }
            set { winsBlack = value; OnPropertyChanged("WinsBlack"); }
        }

        private string winsWhite;
        public string WinsWhite
        {
            get { return winsWhite; }
            set { winsWhite = value; OnPropertyChanged("WinsWhite"); }
        }
    }
}
