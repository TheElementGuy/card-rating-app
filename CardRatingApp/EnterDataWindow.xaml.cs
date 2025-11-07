using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
		User writing = new User(user);
		if (Util.DoesFileExist(user + ".json")) {
			using (StreamReader reader = new StreamReader(user + ".json")) {
				writing.FillFromFile(reader);
			}
		}
		List<string> inputs = new List<string>{Rating0.Text, Rating1.Text, Rating2.Text, Rating3.Text, Rating4.Text, Rating5.Text, Rating6.Text, Rating7.Text, Rating8.Text, Rating9.Text};
		List<TextBox> boxes = new List<TextBox>{Rating0, Rating1, Rating2, Rating3, Rating4, Rating5, Rating6, Rating7, Rating8, Rating9};
		for (int i = 0; i < inputs.Count; i++) {
			if (inputs[i].Equals("")) {
				continue;
			} else {
				try {
					int rating = Int32.Parse(inputs[i]);
					if (rating >= 0 && rating <= 10) {
						writing.AddRating(rating, i);
					} else {
						boxes[i].Background = new SolidColorBrush(Colors.IndianRed);
						return;
					}
				} catch (FormatException exception) {
					boxes[i].Background = new SolidColorBrush(Colors.IndianRed);
					return;
				}
			}
		}
		using (StreamWriter writer = new StreamWriter(writing.Username + ".json")) {
			writing.WriteToFile(writer);
		}

		foreach (TextBox b in boxes) {
			b.Text = "";
		}

		CurrentUser.Text = "";
	}

	private void BackButton_Click(object sender, RoutedEventArgs e) {
		MainWindow home = new MainWindow();
		home.Show();
		this.Close();
	}
}