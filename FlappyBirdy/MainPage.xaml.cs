namespace FlappyBirdy;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
	}

 private void irjogar(object sender, EventArgs args)
	{
		Application.Current.MainPage = new GamePage();
}
}