using System.Windows;
using System.Windows.Controls;

namespace CardRatingApp;

public partial class MainUserControl : UserControl {
	public MainUserControl() {
		InitializeComponent();
	}
	
	private void EnterData_Click(object sender, RoutedEventArgs e) {
		((MainWindow) Application.Current.MainWindow).NavigateTo(new EnterDataUserControl());
	}

	private void Rankings_Click(object sender, RoutedEventArgs e) {
		((MainWindow) Application.Current.MainWindow).NavigateTo(new RankingsUserControl());
	}
}