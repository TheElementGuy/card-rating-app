using System.Windows;

namespace CardRatingApp;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
	public MainWindow() {
		InitializeComponent();
	}

	private void EnterData_Click(object sender, RoutedEventArgs e) {
		EnterDataWindow nextWindow = new EnterDataWindow();
		
		nextWindow.Show();
		
		this.Close();
	}
}