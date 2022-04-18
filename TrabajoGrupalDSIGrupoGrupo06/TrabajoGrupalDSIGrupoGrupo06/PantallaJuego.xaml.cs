using System;
using System.Collections.Generic;
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
    public sealed partial class PantallaJuego : Page
    {
        string mina1Name_, mina2Name_, mina3Name_;
        string campamento1Name_, campamento2Name_, campamento3Name_;
        public PantallaJuego()
        {
            campamento1Name_ = campamento2Name_ = campamento3Name_ = "ms-appx:///Assets/cuartel_nivel1.png";
            mina1Name_ = mina2Name_ = mina3Name_ = "ms-appx:///Assets/mina_nivel1.png";
            this.InitializeComponent();
        }

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
                    }
                    break;
            }

        }
    }
}
