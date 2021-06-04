using CheckersGame.Models;
using CheckersGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CheckersGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new BoardViewModel(true);
        }

        private void OpenGameButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new BoardViewModel(false);
        }

        private void StatisticsButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new StatisticsViewModel();
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new AboutViewModel();
        }
    }
}
