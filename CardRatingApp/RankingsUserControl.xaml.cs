using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace CardRatingApp;

public partial class RankingsUserControl : UserControl {
	public RankingsUserControl() {
		InitializeComponent();
		UpdateRankings();
	}

	private void BackButton_Click(object sender, RoutedEventArgs e) {
		((MainWindow) Application.Current.MainWindow).NavigateTo(new MainUserControl());
	}

	private void CopyToClipboardButton_Click(object sender, RoutedEventArgs e) {
		//TODO: add functionality
	}

	private void HallOfFameButton_Click(object sender, RoutedEventArgs e) {
		//TODO: add functionality
	}

	private void UpdateRankings() {

		UserList users = new UserList();
		users.FillFromFile();

		List<string> cards = new List<string>();

		using (StreamReader cardReader = new("cards.txt")) {
			string line;
			while ((line = cardReader.ReadLine()) != null) {
				cards.Add(line);
			}
		}

		Card1.Content = cards[0];
		Card2.Content = cards[1];
		Card3.Content = cards[2];
		Card4.Content = cards[3];
		Card5.Content = cards[4];
		Card6.Content = cards[5];
		Card7.Content = cards[6];
		Card8.Content = cards[7];
		Card9.Content = cards[8];
		Card10.Content = cards[9];

		List<double> ratingList1 = new List<double>();
		List<double> ratingList2 = new List<double>();
		List<double> ratingList3 = new List<double>();
		List<double> ratingList4 = new List<double>();
		List<double> ratingList5 = new List<double>();
		List<double> ratingList6 = new List<double>();
		List<double> ratingList7 = new List<double>();
		List<double> ratingList8 = new List<double>();
		List<double> ratingList9 = new List<double>();
		List<double> ratingList10 = new List<double>();

		foreach (User u in users.GetUsers()) {
			ratingList1.Add(u.GetNormalizedAveragedRatings()[0]);
			ratingList2.Add(u.GetNormalizedAveragedRatings()[1]);
			ratingList3.Add(u.GetNormalizedAveragedRatings()[2]);
			ratingList4.Add(u.GetNormalizedAveragedRatings()[3]);
			ratingList5.Add(u.GetNormalizedAveragedRatings()[4]);
			ratingList6.Add(u.GetNormalizedAveragedRatings()[5]);
			ratingList7.Add(u.GetNormalizedAveragedRatings()[6]);
			ratingList8.Add(u.GetNormalizedAveragedRatings()[7]);
			ratingList9.Add(u.GetNormalizedAveragedRatings()[8]);
			ratingList10.Add(u.GetNormalizedAveragedRatings()[9]);
		}

		Rating1.Content = Util.Recontextualize(ratingList1.Average());
		Rating2.Content = Util.Recontextualize(ratingList2.Average());
		Rating3.Content = Util.Recontextualize(ratingList3.Average());
		Rating4.Content = Util.Recontextualize(ratingList4.Average());
		Rating5.Content = Util.Recontextualize(ratingList5.Average());
		Rating6.Content = Util.Recontextualize(ratingList6.Average());
		Rating7.Content = Util.Recontextualize(ratingList7.Average());
		Rating8.Content = Util.Recontextualize(ratingList8.Average());
		Rating9.Content = Util.Recontextualize(ratingList9.Average());
		Rating10.Content = Util.Recontextualize(ratingList10.Average());

		List<double> ratings = new List<double>{ratingList1.Average(), ratingList2.Average(), ratingList3.Average(), ratingList4.Average(), ratingList5.Average(), ratingList6.Average(), ratingList7.Average(), ratingList8.Average(), ratingList9.Average(), ratingList10.Average()};

		List<Pair<double, string>> paired = ratings.Zip(cards, (d, s) => new Pair<double, string>(d, s)).OrderBy(x => -x.First).ToList();

		ratings = paired.Select(x => x.First).ToList();
		cards = paired.Select(x => x.Second).ToList();
		
		Rating1.Content = Util.Recontextualize(ratings[0]);
		Rating2.Content = Util.Recontextualize(ratings[1]);
		Rating3.Content = Util.Recontextualize(ratings[2]);
		Rating4.Content = Util.Recontextualize(ratings[3]);
		Rating5.Content = Util.Recontextualize(ratings[4]);
		Rating6.Content = Util.Recontextualize(ratings[5]);
		Rating7.Content = Util.Recontextualize(ratings[6]);
		Rating8.Content = Util.Recontextualize(ratings[7]);
		Rating9.Content = Util.Recontextualize(ratings[8]);
		Rating10.Content = Util.Recontextualize(ratings[9]);
		
		Card1.Content = CardTranslations.GetTranslation(cards[0]);
		Card2.Content = CardTranslations.GetTranslation(cards[1]);
		Card3.Content = CardTranslations.GetTranslation(cards[2]);
		Card4.Content = CardTranslations.GetTranslation(cards[3]);
		Card5.Content = CardTranslations.GetTranslation(cards[4]);
		Card6.Content = CardTranslations.GetTranslation(cards[5]);
		Card7.Content = CardTranslations.GetTranslation(cards[6]);
		Card8.Content = CardTranslations.GetTranslation(cards[7]);
		Card9.Content = CardTranslations.GetTranslation(cards[8]);
		Card10.Content = CardTranslations.GetTranslation(cards[9]);
		
	}
	
}