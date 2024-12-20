 <ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="FlappyBirdy.MainPage">
             Shell.NavBarIsVisible="false">

      <Grid>
         <Grid.GestureRecognizers>
          <TapGestureRecognizer Tapped="OnGridClickd"/>
         </Grid.GestureRecognizers>
         


        <Image Source="canodecima.png"
               Aspect="Fill"
               HorizontalOptions="Fill"
               VerticalOptions="Fill"/>


        <Image x:Name="passaro"
               Source="flapbirdy.png"
               HeightRequest="50"
           
               WidthRequest="90"
               HorizontalOptions="Center"
               VerticalOptions="Center"/>

        <Image x:Name="canod1"
               Source="flapbirdy.png
             
               HeightRequest="690"
               WidthRequest="90"
               HorizontalOptions="End"
               VerticalOptions="Start"/>

        <Image x:Name="canod2"
               Source="canod2.png"
               HeightRequest="660"
               WidthRequest="60"
               
               HorizontalOptions="End"
               VerticalOptions="End"/>


       <Label Text="jogar"
              TextColor="Blue"
              FontSize="45"
              x:Name="LabelLP"
              FontFamily="CollegiateBlackFLF.ttf"
              HorizontalOptions="End"
              VerticalOptions="Start"/>
      

        <Frame x:Name="frameGameOver"
           BackgroundColor="#77000000"
           HorizontalOptions="Fill"
           VerticalOptions="Fill">
      <Frame.GestureRecognizers>
        <TapGestureRecognizer Tapped="OnGameOverClicked"/>
      </Frame.GestureRecognizers>
      <VerticalStackLayout VerticalOptions="Center">
        <Label
              Text="Score: 00000"
              FontSize="30"
              Margin="0,20,20,0"
              VerticalOptions="Start"
              HorizontalOptions="Center"
              HorizontalTextAlignment="Center"/>
        <Image Source="start.png"
               Aspect="AspectFit"
               Margin="0,200,0,0"
               HeightRequest="150"
               WidthRequest="300"/>
      </VerticalStackLayout>
    </Frame>
  </Grid>