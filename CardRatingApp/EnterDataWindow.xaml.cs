using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace CardRatingApp;

public partial class EnterDataWindow : Window {
	
	public ObservableCollection<string> Users {get; set;}

	private ObservableCollection<string> Cards {get; set;}
	
	public EnterDataWindow() {
		InitializeComponent();

		Users = new ObservableCollection<string>();

		using (StreamReader userReader = new("users.txt")) {
			string line ;
			while ((line = userReader.ReadLine()) != null) {
				Users.Add(line);
			}
		}

		DataContext = this;

		Cards = new ObservableCollection<string>();

		using (StreamReader cardReader = new("cards.txt")) {
			string line;
			while ((line = cardReader.ReadLine()) != null) {
				Cards.Add(line);
			}
		}

		Card0.Content = Cards[0];
		Card1.Content = Cards[1];
		Card2.Content = Cards[2];
		Card3.Content = Cards[3];
		Card4.Content = Cards[4];
		Card5.Content = Cards[5];
		Card6.Content = Cards[6];
		Card7.Content = Cards[7];
		Card8.Content = Cards[8];
		Card9.Content = Cards[9];
		
	}

	private void DoneButton_Click(object sender, RoutedEventArgs e) {
		string user = CurrentUser.Text;
		using (StreamWriter writer = new StreamWriter(user + ".txt")) {
			
		}
	}
}