using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace TrabajoGrupalDSIGrupoGrupo06
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class PantallaJuego : Page, INotifyPropertyChanged
    {
        public struct datosImportantes
        {
            
            public datosImportantes(double velPiedra, double velMadera, double velComida, double velMetal, int canMadera, int canMetal, int canComida, int canPiedra, int canTropas,
             string nameMina1, string nameMina2, string nameMina3, string nameCampamento1, 
             string nameCampamento2, string nameCampamento3, string nameCasa1, string nameCasa2, string nameCasa3, string nameCastillo)
            {
                cMetal = canMetal; cComida = canComida; cPiedra = canPiedra; cTropas = canTropas; cMadera = canMadera;
                vPiedra = velPiedra; vMadera = velMadera;  vComida = velComida; vMetal = velMetal;
                nMina1 = nameMina1; nMina2 = nameMina2; nMina3 = nameMina3;
                nCampamento1 = nameCampamento1; nCampamento2 = nameCampamento2; nCampamento3 = nameCampamento3;
                nCasa1 = nameCasa1; nCasa2 = nameCasa2; nCasa3 = nameCasa3; nCastillo = nameCastillo;
            }
            public int cMetal { get; set; }  public int cComida { get; set; } public int cPiedra { get; set; } public int cMadera { get; set; } public int cTropas { get; set; }
            public double vPiedra { get; set; }   public double vMadera { get; set; } public double vComida { get; set; } public double vMetal { get; set; }
            public string nMina1 { get; set; }
            public string nMina2 { get; set; } public string nMina3 { get; set; }   
            public string nCampamento1 { get; set; }  public string nCampamento2 { get; set; }  public string nCampamento3 { get; set; }
            public string nCasa1 { get; set; }  public string nCasa2 { get; set; }   public string nCasa3 { get; set; } public string nCastillo { get; set; }
        }
        double velocidadPiedra, velocidadMadera, velocidadComida, velocidadMetal = 1;
        int madera = 0, metal = 0, comida = 0, piedra = 0, numerodeTropas = 0;
        string mina1Name_, mina2Name_, mina3Name_;
        string campamento1Name_, campamento2Name_, campamento3Name_;
        string casa1Name_, casa2Name_, casa3Name_;
        string castilloName;

        private DispatcherTimer _timer_madera, _timer_comida, _timer_piedra, _timer_metal, _timer_tropas;//creas variable objeto contador

        public event PropertyChangedEventHandler PropertyChanged;
        public PantallaJuego()
        {
            campamento1Name_ = campamento2Name_ = campamento3Name_ = "ms-appx:///Assets/cuartel_nivel1.png";
            mina1Name_ = mina2Name_ = mina3Name_ = "ms-appx:///Assets/mina_nivel1.png";
            casa1Name_ = casa2Name_ = casa3Name_ = "ms-appx:///Assets/casa_nivel1.png";
            castilloName = "ms-appx:///Assets/castillo_nivel1.png";
            this.InitializeComponent();

            _timer_madera = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _timer_comida = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _timer_metal = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _timer_piedra = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _timer_tropas = new DispatcherTimer { Interval = TimeSpan.FromSeconds(0.1) };

            _timer_madera.Tick += (sender, o) =>
                sumarMadera();
            _timer_madera.Tick += (sender, o) =>
               PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(madera)));

            _timer_comida.Tick += (sender, o) =>
                sumarComida();
            _timer_comida.Tick += (sender, o) =>
               PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(comida)));

            _timer_metal.Tick += (sender, o) =>
                sumarMetal();
            _timer_metal.Tick += (sender, o) =>
               PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(metal)));

            _timer_piedra.Tick += (sender, o) =>
                sumarPiedra();
            _timer_piedra.Tick += (sender, o) =>
               PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(piedra)));

            _timer_tropas.Tick += (sender, o) =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(numerodeTropas)));

            _timer_madera.Start();
            _timer_comida.Start();
            _timer_metal.Start();
            _timer_piedra.Start();
            _timer_tropas.Start();
        }
        private void Options_Click(object sender, RoutedEventArgs e)
        {
            Panel_Ajustes.Visibility = Visibility.Visible;
        }
        private void OptionsClose_Click(object sender, RoutedEventArgs e)
        {
            Panel_Ajustes.Visibility = Visibility.Collapsed;
        }
        private void Tienda_Click(object sender, RoutedEventArgs e)
        {
            Panel_Comprar.Visibility = Visibility.Visible;
        }
        private void TiendaClose_Click(object sender, RoutedEventArgs e)
        {
            Panel_Comprar.Visibility = Visibility.Collapsed;
        }
        private void PanelEntrenamiento_Click(object sender, RoutedEventArgs e)
        {
            Panel_Entrenamiento.Visibility= Visibility.Visible;
        }

        private void Construccion_MiCampamento(object sender, RoutedEventArgs e)
        {
            if (madera >= 20 && piedra >= 20 && metal >= 20)
            {
                madera -= 20;
                piedra -= 20;
                metal -= 20;
                recursos_madera.Width = piedra * 182 / 100;
                recursos_piedra.Width = piedra * 182 / 100;
                recursos_hierro.Width = piedra * 182 / 100;

                if (Campamento2StackPanel.Visibility == Visibility.Collapsed)
                    Campamento2StackPanel.Visibility = Visibility.Visible;

                else if (Campamento3StackPanel.Visibility == Visibility.Collapsed)
                    Campamento3StackPanel.Visibility = Visibility.Visible;
                Panel_Comprar.Visibility = Visibility.Collapsed;
            }
        }
        private void Construccion_Mina(object sender, RoutedEventArgs e)
        {
            if (madera >= 20 && piedra >= 20 && metal >= 20)
            {
                madera -= 20;
                piedra -= 20;
                metal -= 20;
                recursos_madera.Width = piedra * 182 / 100;
                recursos_piedra.Width = piedra * 182 / 100;
                recursos_hierro.Width = piedra * 182 / 100;

                if (Mina2StackPanel.Visibility == Visibility.Collapsed)
                    Mina2StackPanel.Visibility = Visibility.Visible;

                else if (Mina3StackPanel.Visibility == Visibility.Collapsed)
                    Mina3StackPanel.Visibility = Visibility.Visible;
                Panel_Comprar.Visibility = Visibility.Collapsed;
            }
        }
        private void Construccion_MiCasa(object sender, RoutedEventArgs e)
        {
            if (madera >= 20 && piedra >= 20 && metal >= 20)
            {
                madera -= 20;
                piedra -= 20;
                metal -= 20;
                recursos_madera.Width = piedra * 182 / 100;
                recursos_piedra.Width = piedra * 182 / 100;
                recursos_hierro.Width = piedra * 182 / 100;

                if (Casa2StackPanel.Visibility == Visibility.Collapsed)
                    Casa2StackPanel.Visibility = Visibility.Visible;

                else if (Casa3StackPanel.Visibility == Visibility.Collapsed)
                    Casa3StackPanel.Visibility = Visibility.Visible;
                Panel_Comprar.Visibility = Visibility.Collapsed;
            }
        }
        private void Chat_Click(object sender, RoutedEventArgs e)
        {
            Panel_Chat.Visibility = Visibility.Visible;
        }
        private void ChatClose_Click(object sender, RoutedEventArgs e)
        {
            Panel_Chat.Visibility = Visibility.Collapsed;
        }
        private void PanelEntrenamientoClose_Click(object sender, RoutedEventArgs e)
        {
            Panel_Entrenamiento.Visibility = Visibility.Collapsed;
        }
        private void Pantalla_AtaqueNavegacion(object sender, RoutedEventArgs e)
        {
            datosImportantes dt; dt = new datosImportantes(velocidadPiedra, velocidadMadera, velocidadComida, velocidadMetal, madera, metal, comida, piedra, numerodeTropas,
             mina1Name_, mina2Name_, mina3Name_, campamento1Name_,campamento2Name_, campamento3Name_, casa1Name_, casa2Name_, casa3Name_, castilloName);
             
            Frame.Navigate(typeof(PantallaAtaque), dt);
        }
        private void Mina_Click(object sender, RoutedEventArgs e)
        {
            if (madera >= 10 && piedra >= 10 && metal >= 10)
            {
                velocidadMetal += 2; velocidadPiedra += 2;
                _timer_piedra.Interval = TimeSpan.FromSeconds(1 / velocidadPiedra);
                _timer_metal.Interval = TimeSpan.FromSeconds(1 / velocidadMetal);
                madera -= 10;
                piedra -= 10;
                metal -= 10;
                recursos_madera.Width = piedra * 182 / 100;
                recursos_piedra.Width = piedra * 182 / 100;
                recursos_hierro.Width = piedra * 182 / 100;

                Button button = (Button)sender;
                string buttonName = button.Name;
                switch (buttonName)
                {
                    case "BotonMina1":
                        if (mina1Name_ == "ms-appx:///Assets/mina_nivel1.png")
                        {
                            mina1Name_ = "ms-appx:///Assets/mina_nivel2.png";
                            Mina1.Source = new BitmapImage(new Uri("ms-appx:///Assets/mina_nivel2.png"));
                        }
                        else if (mina1Name_ == "ms-appx:///Assets/mina_nivel2.png")
                        {
                            mina1Name_ = "ms-appx:///Assets/mina_nivel3.png";
                            Mina1.Source = new BitmapImage(new Uri("ms-appx:///Assets/mina_nivel3.png"));
                            button.Visibility = Visibility.Collapsed;
                        }
                        break;
                    case "BotonMina2":
                        if (mina2Name_ == "ms-appx:///Assets/mina_nivel1.png")
                        {
                            mina2Name_ = "ms-appx:///Assets/mina_nivel2.png";
                            Mina2.Source = new BitmapImage(new Uri("ms-appx:///Assets/mina_nivel2.png"));
                        }
                        else if (mina2Name_ == "ms-appx:///Assets/mina_nivel2.png")
                        {
                            mina2Name_ = "ms-appx:///Assets/mina_nivel3.png";
                            Mina2.Source = new BitmapImage(new Uri("ms-appx:///Assets/mina_nivel3.png"));
                            button.Visibility = Visibility.Collapsed;
                        }
                        break;
                    case "BotonMina3":
                        if (mina3Name_ == "ms-appx:///Assets/mina_nivel1.png")
                        {
                            mina3Name_ = "ms-appx:///Assets/mina_nivel2.png";
                            Mina3.Source = new BitmapImage(new Uri("ms-appx:///Assets/mina_nivel2.png"));
                        }
                        else if (mina3Name_ == "ms-appx:///Assets/mina_nivel2.png")
                        {
                            mina3Name_ = "ms-appx:///Assets/mina_nivel3.png";
                            Mina3.Source = new BitmapImage(new Uri("ms-appx:///Assets/mina_nivel3.png"));
                            button.Visibility = Visibility.Collapsed;
                        }
                        break;
                }
            }
        }
        private void Campamento_Click(object sender, RoutedEventArgs e)
        {
            if(madera >= 10 && piedra >= 10 && metal >= 10)
            {
                velocidadMadera += 2; 
                _timer_madera.Interval = TimeSpan.FromSeconds(1 / velocidadMadera);
                madera -= 10;
                piedra -= 10;
                metal -= 10;
                recursos_madera.Width = piedra * 182 / 100;
                recursos_piedra.Width = piedra * 182 / 100;
                recursos_hierro.Width = piedra * 182 / 100;

                Button button = (Button)sender;
                string buttonName = button.Name;
                switch (buttonName)
                {
                    case "BotonCampamento1":
                        if (campamento1Name_ == "ms-appx:///Assets/cuartel_nivel1.png")
                        {
                            campamento1Name_ = "ms-appx:///Assets/cuartel_nivel2.png";
                            Campamento1.Source = new BitmapImage(new Uri("ms-appx:///Assets/cuartel_nivel2.png"));
                        }
                        else if (campamento1Name_ == "ms-appx:///Assets/cuartel_nivel2.png")
                        {
                            campamento1Name_ = "ms-appx:///Assets/cuartel_nivel3.png";
                            Campamento1.Source = new BitmapImage(new Uri("ms-appx:///Assets/cuartel_nivel3.png"));
                            button.Visibility = Visibility.Collapsed;
                        }
                        break;
                    case "BotonCampamento2":
                        if (campamento2Name_ == "ms-appx:///Assets/cuartel_nivel1.png")
                        {
                            campamento2Name_ = "ms-appx:///Assets/cuartel_nivel2.png";
                            Campamento2.Source = new BitmapImage(new Uri("ms-appx:///Assets/cuartel_nivel2.png"));
                        }
                        else if (campamento2Name_ == "ms-appx:///Assets/cuartel_nivel2.png")
                        {
                            campamento2Name_ = "ms-appx:///Assets/cuartel_nivel3.png";
                            Campamento2.Source = new BitmapImage(new Uri("ms-appx:///Assets/cuartel_nivel3.png"));
                            button.Visibility = Visibility.Collapsed;
                        }
                        break;
                    case "BotonCampamento3":
                        if (campamento3Name_ == "ms-appx:///Assets/cuartel_nivel1.png")
                        {
                            campamento3Name_ = "ms-appx:///Assets/cuartel_nivel2.png";
                            Campamento3.Source = new BitmapImage(new Uri("ms-appx:///Assets/cuartel_nivel2.png"));
                        }
                        else if (campamento3Name_ == "ms-appx:///Assets/cuartel_nivel2.png")
                        {
                            campamento3Name_ = "ms-appx:///Assets/cuartel_nivel3.png";
                            Campamento3.Source = new BitmapImage(new Uri("ms-appx:///Assets/cuartel_nivel3.png"));
                            button.Visibility = Visibility.Collapsed;
                        }
                        break;
                }
            }
        }
        private void Casa_Click(object sender, RoutedEventArgs e)
        {
            
            if (madera >= 10 && piedra >= 10 && metal >= 10)
            {
                velocidadComida += 2;
                _timer_comida.Interval = TimeSpan.FromSeconds(1/velocidadComida);
                madera -= 10;
                piedra -= 10;
                metal -= 10;
                recursos_madera.Width = piedra * 182 / 100;
                recursos_piedra.Width = piedra * 182 / 100;
                recursos_hierro.Width = piedra * 182 / 100;

                Button button = (Button)sender;
                string buttonName = button.Name;
                switch (buttonName)
                {
                    case "BotonCasa1":
                        if (casa1Name_ == "ms-appx:///Assets/casa_nivel1.png")
                        {
                            casa1Name_ = "ms-appx:///Assets/casa_nivel2.png";
                            Casa1.Source = new BitmapImage(new Uri("ms-appx:///Assets/casa_nivel2.png"));
                        }
                        else if (casa1Name_ == "ms-appx:///Assets/casa_nivel2.png")
                        {
                            casa1Name_ = "ms-appx:///Assets/casa_nivel3.png";
                            Casa1.Source = new BitmapImage(new Uri("ms-appx:///Assets/casa_nivel3.png"));
                            button.Visibility = Visibility.Collapsed;
                        }
                        break;
                    case "BotonCasa2":
                        if (casa2Name_ == "ms-appx:///Assets/casa_nivel1.png")
                        {
                            casa2Name_ = "ms-appx:///Assets/casa_nivel2.png";
                            Casa2.Source = new BitmapImage(new Uri("ms-appx:///Assets/casa_nivel2.png"));
                        }
                        else if (casa2Name_ == "ms-appx:///Assets/casa_nivel2.png")
                        {
                            casa2Name_ = "ms-appx:///Assets/casa_nivel3.png";
                            Casa2.Source = new BitmapImage(new Uri("ms-appx:///Assets/casa_nivel3.png"));
                            button.Visibility = Visibility.Collapsed;
                        }
                        break;
                    case "BotonCasa3":
                        if (casa3Name_ == "ms-appx:///Assets/casa_nivel1.png")
                        {
                            casa3Name_ = "ms-appx:///Assets/casa_nivel2.png";
                            Casa3.Source = new BitmapImage(new Uri("ms-appx:///Assets/casa_nivel2.png"));
                        }
                        else if (casa3Name_ == "ms-appx:///Assets/casa_nivel2.png")
                        {
                            casa3Name_ = "ms-appx:///Assets/casa_nivel3.png";
                            Casa3.Source = new BitmapImage(new Uri("ms-appx:///Assets/casa_nivel3.png"));
                            button.Visibility = Visibility.Collapsed;
                        }
                        break;
                }
            }
        }
        private void Castillo_Click(object sender, RoutedEventArgs e)
        {
            if(madera >= 10 && metal >=10 && piedra >= 10)
            {
                velocidadComida += 2; velocidadMadera += 2; velocidadMetal += 2; velocidadPiedra += 2;
                _timer_madera.Interval = TimeSpan.FromSeconds(1 / velocidadMadera);
                _timer_piedra.Interval = TimeSpan.FromSeconds(1 / velocidadPiedra);
                _timer_metal.Interval = TimeSpan.FromSeconds(1 / velocidadMetal);
                _timer_comida.Interval = TimeSpan.FromSeconds(1 / velocidadComida);
                madera -= 10;
                piedra -= 10;
                metal -= 10;
                recursos_madera.Width = piedra * 182 / 100;
                recursos_piedra.Width = piedra * 182 / 100;
                recursos_hierro.Width = piedra * 182 / 100;

                Button button = (Button)sender;
                if (castilloName == "ms-appx:///Assets/castillo_nivel1.png")
                {
                    castilloName = "ms-appx:///Assets/castillo_nivel2.png";
                    Castillo.Source = new BitmapImage(new Uri("ms-appx:///Assets/castillo_nivel2.png"));
                }
                else if (castilloName == "ms-appx:///Assets/castillo_nivel2.png")
                {
                    castilloName = "ms-appx:///Assets/castillo_nivel3.png";
                    Castillo.Source = new BitmapImage(new Uri("ms-appx:///Assets/castillo_nivel3.png"));
                    button.Visibility = Visibility.Collapsed;
                }
            }
        }
        private void sumarMadera()
        {
           
            if (madera < 100)  madera++;
            recursos_madera.Width = madera * 182 / 100;
        }
        private void sumarComida()
        {
            if (comida < 100) comida++;
            recursos_comida.Width = comida * 182 / 100;
        }
        private void sumarMetal()
        {
            if (metal < 100) metal++;
            recursos_hierro.Width = metal * 182 / 100;
        }
        private void sumarPiedra()
        {
            if (piedra < 100) piedra++;
            recursos_piedra.Width = piedra * 182 / 100;
        }
        private void Soldado_Click(object sender, RoutedEventArgs e)
        {
            if (comida >= 5 && numerodeTropas < 59)
            {
                comida -= 5;
                numerodeTropas += 2;
            }
            recursos_soldados.Width = numerodeTropas * 182 / 60;
        }

        private void Arquero_Click(object sender, RoutedEventArgs e)
        {
            if (comida >= 5 && numerodeTropas < 60)
            {
                comida -= 5;
                numerodeTropas += 1;
            }
            recursos_soldados.Width = numerodeTropas * 182 / 60;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //// If e.Parameter is a string, set the TextBlock's text with it.
            //if (e?.Parameter is datosImportantes dt)
            //{
            //    velocidadPiedra = dt.vPiedra;
            //    _timer_piedra.Interval = TimeSpan.FromSeconds(1 / velocidadPiedra);
            //    velocidadMadera = dt.vMadera;
            //    _timer_madera.Interval = TimeSpan.FromSeconds(1 / velocidadMadera);
            //    velocidadMetal = dt.vMetal;
            //    _timer_metal.Interval = TimeSpan.FromSeconds(1 / velocidadMetal);
            //    velocidadComida = dt.vComida;
            //    _timer_comida.Interval = TimeSpan.FromSeconds(1 / velocidadComida);

            //    madera = dt.cMadera;
            //}

            base.OnNavigatedTo(e);
        }
    }
}
