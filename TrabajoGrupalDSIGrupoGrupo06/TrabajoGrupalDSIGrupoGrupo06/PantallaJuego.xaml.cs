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
        int madera = 0, metal = 0, comida = 0, piedra = 0, tropas = 0;
        string mina1Name_, mina2Name_, mina3Name_;
        string campamento1Name_, campamento2Name_, campamento3Name_;
        string casa1Name_, casa2Name_, casa3Name_;
        string castilloName;

        private DispatcherTimer _timer;//creas variable objeto contador

        public event PropertyChangedEventHandler PropertyChanged;
        public PantallaJuego()
        {
            campamento1Name_ = campamento2Name_ = campamento3Name_ = "ms-appx:///Assets/cuartel_nivel1.png";
            mina1Name_ = mina2Name_ = mina3Name_ = "ms-appx:///Assets/mina_nivel1.png";
            casa1Name_ = casa2Name_ = casa3Name_ = "ms-appx:///Assets/casa_nivel1.png";
            castilloName = "ms-appx:///Assets/castillo_nivel1.png";
            this.InitializeComponent();

            _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };

            _timer.Tick += (sender, o) =>
                //PropertyChanged?.Invoke es una abreviatura para comprobar si un evento es NULL y, si no, para invocarlo y (this, new PropertyChangedEventArgs(nameof(CurrentTime) actualiza el  evento CurrentTime con el nuevo objeto de valor actualizado _timer
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentTime)));
            //inicia el temporizador
            _timer.Start();
        }
        public string CurrentTime;

        private void FontSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {

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
            if (Campamento2StackPanel.Visibility == Visibility.Collapsed)
                Campamento2StackPanel.Visibility = Visibility.Visible;

            else if (Campamento3StackPanel.Visibility == Visibility.Collapsed)
                Campamento3StackPanel.Visibility = Visibility.Visible;
            Panel_Comprar.Visibility = Visibility.Collapsed;
        }

        private void Construccion_Mina(object sender, RoutedEventArgs e)
        {
            if (Mina2StackPanel.Visibility == Visibility.Collapsed)
                Mina2StackPanel.Visibility = Visibility.Visible;

            else if (Mina3StackPanel.Visibility == Visibility.Collapsed)
                Mina3StackPanel.Visibility = Visibility.Visible;
            Panel_Comprar.Visibility = Visibility.Collapsed;

        }
        private void Construccion_MiCasa(object sender, RoutedEventArgs e)
        {
            if (Casa2StackPanel.Visibility == Visibility.Collapsed)
                Casa2StackPanel.Visibility = Visibility.Visible;

            else if (Casa3StackPanel.Visibility == Visibility.Collapsed)
                Casa3StackPanel.Visibility = Visibility.Visible;
            Panel_Comprar.Visibility = Visibility.Collapsed;
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
            Frame.Navigate(typeof(PantallaAtaque));
        }

        private void Mina_Click(object sender, RoutedEventArgs e)
        {
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

        private void Campamento_Click(object sender, RoutedEventArgs e)
        {
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
        private void Casa_Click(object sender, RoutedEventArgs e)
        {
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
        private void Castillo_Click(object sender, RoutedEventArgs e)
        {
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
}
