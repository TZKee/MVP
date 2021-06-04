using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersGame.ViewModels
{
    public class AboutViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public AboutViewModel()
        {
            Developer = "♛Developer Name: Taca Vlad";
            Email = "♛Developer Email: vlad.taca@student.unitbv.ro";
            Group = "♛Developer Group: 10 LF 393";
            Rules = "♛ RULES ♛\n\n♛ The opponent with the darker pieces moves first.\n\n♛ Pieces may only move one diagonal space forward(towards their \nopponents pieces) in the beginning of the game. \n\n ♛ Pieces must stay on the dark squares.\n\n♛ To capture an opposing piece, jump over it by moving \ntwo diagonal spaces in the direction of the the opposing piece.\n\n♛ A piece may jump forward over an opponent's pieces in multiple\n parts of the board to capture them. \n\n♛ Keep in mind, the space on the other side of your opponent’s\n piece must be empty for you to capture it. \n\n♛ If your piece reaches the last row on your opponent's side\n, you may re-take one of your captured pieces and crown the piece that \nmade it to the Kings Row.Thereby making it a King Piece.\n\n♛ King pieces may still only move one space at a time\n during a non - capturing move. However, when \ncapturing an opponent's piece(s) it may move diagonally forward or backwards.\n\n♛ There is no limit to how many king pieces a player may have. ";
        }
        private string developer;
        public string Developer
        {
            get { return developer; }
            set { developer = value; OnPropertyChanged("Developer"); }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged("Email"); }
        }

        private string group;
        public string Group
        {
            get { return group; }
            set { group = value; OnPropertyChanged("Group"); }
        }
        private string rules;

        public string Rules
        {
            get { return rules; }
            set { rules = value; OnPropertyChanged("Rules"); }
        }

    }
}
