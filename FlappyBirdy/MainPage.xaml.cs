using AVFoundation;
using MapKit;
using UIKit;

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
		Double LarguraJanela=0;
		Double AlturaJanela=0;
		int Velocidade=0;

    protected override void OnSizeAllocated(double w, double h)
    {
        base OnSizeAllocated(w,h);
		LarguraJanela=w;
		AlturaJanela=h;

		void GerenciaCanos()
		{
			imgCanoCima.TranslationX-=velocidade;
			imgCanoBaixo.TranslationX-=velocidade;
			if(IMKGeoJsonObject CanoBaixo.TranslationX<=LarguraJanela)
			{
				imgCanobaixo.Translation.TranslationX=0;
				imgCanoCima.TranslationX=0;
			}
		}
	 GerenciaCanos()
	}
	}
}
