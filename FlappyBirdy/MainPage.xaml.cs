namespace FlappyBirdy
{
    public partial class MainPage : ContentPage
    {
        const int gravidade = 5;
        int Score = 0;
        const int aberturaMinima = 100;
        const int tempoEntreFrames = 20;
        bool estaMorto = false;
        double larguraJanela = 0;
        double AlturaJanela = 0;
        int velocidade = 10;
        const int ForcaPulo = 30;
        const int MaximoTempoPulando = 3; // frames
        bool EstaPulando = false;
        int TempoPulando = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        void AplicaGravidade()
        {
            Passaro.TranslationY += gravidade;
        }
        public async void Desenha()
        {
            while (!estaMorto)
            {
                if (EstaPulando)
                    AplicaPulo();
                else
                    AplicaGravidade();

                GerenciaCanos();

                if (VerificaColisao())
                {
                    estaMorto = true;
                    FrameGameOver.IsVisible = true; // Mostrar tela de game over
                    break;
                }

                await Task.Delay(tempoEntreFrames); // Atrasar o próximo ciclo de atualização
            }
        }

        void AplicaPulo()
        {
            Passaro.TranslationY -= ForcaPulo;
            TempoPulando++;

            if (TempoPulando >= MaximoTempoPulando)
            {
                EstaPulando = false;
                TempoPulando = 0;
            }
        }

        void OnGridClicked(object s, TappedEventArgs a)
        {
            EstaPulando = true; // O pássaro começa a pular ao clicar na tela
        }

        async void Oi(object s, TappedEventArgs e)
        {
            FrameGameOver.IsVisible = false; // Esconder tela de game over
            estaMorto = false;
            Inicializar(); // Reiniciar o jogo
            Desenha(); // Começar o jogo novamente
            LabelScore.Text = "Você passou por " + Score.ToString("D3") + " Canos!!"; // Atualizar a pontuação
        }

        void Inicializar()
        {
            imgcanocima.TranslationX = -larguraJanela;
            imgcanobaixo.TranslationX = -larguraJanela;
            Passaro.TranslationX = 0;
            Passaro.TranslationY = 0;
            Score = 0;
            GerenciaCanos(); // Reiniciar a posição dos canos
        }

        protected override void OnSizeAllocated(double w, double h)
        {
            base.OnSizeAllocated(w, h);
            larguraJanela = w;
            AlturaJanela = h;
        }

        void GerenciaCanos()
        {
            imgcanocima.TranslationX -= velocidade;
            imgcanobaixo.TranslationX -= velocidade;

            if (imgcanobaixo.TranslationX < -larguraJanela)
            {
                imgcanobaixo.TranslationX = larguraJanela; // Coloca o cano de volta à tela
                imgcanocima.TranslationX = larguraJanela;

                var alturaMax = -100;
                var alturaMin = -imgcanobaixo.HeightRequest;
                imgcanocima.TranslationY = Random.Shared.Next((int)alturaMin, (int)alturaMax);
                imgcanobaixo.TranslationY = imgcanocima.TranslationY + aberturaMinima + imgcanobaixo.HeightRequest;

                Score++;
                LabelScore.Text = "Canos: " + Score.ToString("D3");

                // Aumentar a velocidade gradualmente a cada 5 pontos
                if (Score % 5 == 0)
                    velocidade++;
            }
        }

        bool VerificaColisao()
        {
            return VerificaColisaoTeto() || VerificaColisaoChao() ||
                   VerificaColisaoCanoCima() || VerificaColisaoCanoBaixo();
        }

        bool VerificaColisaoTeto()
        {
            var minY = -AlturaJanela / 2;
            return Passaro.TranslationY <= minY;
        }

        bool VerificaColisaoChao()
        {
            var maxY = AlturaJanela / 2 - chao.HeightRequest;
            return Passaro.TranslationY >= maxY;
        }

        bool VerificaColisaoCanoCima()
        {
            // Posição X e Y do pássaro
            var posHPassaro = Passaro.TranslationX + (Passaro.WidthRequest / 2);
            var posVPassaro = Passaro.TranslationY + (Passaro.HeightRequest / 2);

            // Verifica se o pássaro colidiu com o cano de cima
            return posHPassaro >= imgcanocima.TranslationX && posHPassaro <= imgcanocima.TranslationX + imgcanocima.WidthRequest &&
                   posVPassaro <= imgcanocima.TranslationY + imgcanocima.HeightRequest;
        }

        bool VerificaColisaoCanoBaixo()
        {
            // Posição X e Y do pássaro
            var posHPassaro = Passaro.TranslationX + (Passaro.WidthRequest / 2);
            var posVPassaro = Passaro.TranslationY + (Passaro.HeightRequest / 2);

            // Verifica se o pássaro colidiu com o cano de baixo
            return posHPassaro >= imgcanobaixo.TranslationX && posHPassaro <= imgcanobaixo.TranslationX + imgcanobaixo.WidthRequest &&
                   posVPassaro >= imgcanobaixo.TranslationY;
        }
    }
}