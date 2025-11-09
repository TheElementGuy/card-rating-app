using System.Windows;
using System.Windows.Controls;

namespace CardRatingApp;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {

	public MainWindow() {
		InitializeComponent();
		UcHost.Content = new MainUserControl();
	}

	public void NavigateTo(UserControl nextPage) {
		UcHost.Content = nextPage;
	}
}