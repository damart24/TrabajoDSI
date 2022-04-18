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
    public sealed partial class PantallaAtaque : Page
    {
        int estrellasLevel1, estrellasLevel2, estrellasLevel3, estrellasLevel4, estrellasLevel5, estrellasLevel6;
        public PantallaAtaque()
        {
            int estrellasLevel1, estrellasLevel2, estrellasLevel3, estrellasLevel4, estrellasLevel5, estrellasLevel6 = 0;
            this.InitializeComponent();
        }

        private void PanelAtaqueClose_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PantallaJuego));
        }

        private void Edificio_Click(object sender, RoutedEventArgs e)
        {
            NombreAtaque1.Visibility = Visibility.Collapsed;
            IconoLucha1.Visibility = Visibility.Collapsed;
            NombreAtaque2.Visibility = Visibility.Collapsed;
            IconoLucha2.Visibility = Visibility.Collapsed;
            NombreAtaque3.Visibility = Visibility.Collapsed;
            IconoLucha3.Visibility = Visibility.Collapsed;
            NombreAtaque4.Visibility = Visibility.Collapsed;
            IconoLucha4.Visibility = Visibility.Collapsed;
            NombreAtaque5.Visibility = Visibility.Collapsed;
            IconoLucha5.Visibility = Visibility.Collapsed;
            NombreAtaque6.Visibility = Visibility.Collapsed;
            IconoLucha6.Visibility = Visibility.Collapsed;
            Button button = (Button)sender;
            string buttonName = button.Name;
            switch (buttonName)
            {
                case "Edificio_1":
                    NombreAtaque1.Visibility = Visibility.Visible;
                    IconoLucha1.Visibility = Visibility.Visible;
                    break;
                case "Edificio_2":
                    NombreAtaque2.Visibility = Visibility.Visible;
                    IconoLucha2.Visibility = Visibility.Visible;
                    break;
                case "Edificio_3":
                    NombreAtaque3.Visibility = Visibility.Visible;
                    IconoLucha3.Visibility = Visibility.Visible;
                    break;
                case "Edificio_4":
                    NombreAtaque4.Visibility = Visibility.Visible;
                    IconoLucha4.Visibility = Visibility.Visible;
                    break;
                case "Edificio_5":
                    NombreAtaque5.Visibility = Visibility.Visible;
                    IconoLucha5.Visibility = Visibility.Visible;
                    break;
                case "Edificio_6":
                    NombreAtaque6.Visibility = Visibility.Visible;
                    IconoLucha6.Visibility = Visibility.Visible;
                    break;
            }
        }
        private void Ataque_Click(object sender, RoutedEventArgs e)
        {
            NombreAtaque1.Visibility = Visibility.Collapsed;
            IconoLucha1.Visibility = Visibility.Collapsed;
            NombreAtaque2.Visibility = Visibility.Collapsed;
            IconoLucha2.Visibility = Visibility.Collapsed;
            NombreAtaque3.Visibility = Visibility.Collapsed;
            IconoLucha3.Visibility = Visibility.Collapsed;
            NombreAtaque4.Visibility = Visibility.Collapsed;
            IconoLucha4.Visibility = Visibility.Collapsed;
            NombreAtaque5.Visibility = Visibility.Collapsed;
            IconoLucha5.Visibility = Visibility.Collapsed;
            NombreAtaque6.Visibility = Visibility.Collapsed;
            IconoLucha6.Visibility = Visibility.Collapsed;
            Button button = (Button)sender;
            string buttonName = button.Name;

           Random random = new Random();
            int numeroEstrellas = random.Next(0, 9);
            switch (buttonName)
            {
                case "IconoLucha1":
                    if(numeroEstrellas <= 2 && estrellasLevel1 < 1)
                    {
                        EstrellasNivel1.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrellas_1.png"));
                        estrellasLevel1 = 1;
                    }
                       
                    else if(numeroEstrellas <= 5 && estrellasLevel1 < 2)
                    {
                        EstrellasNivel1.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrellas_2.png"));
                        estrellasLevel1 = 2;
                    }
                    else if(estrellasLevel1 < 3)
                    {
                        EstrellasNivel1.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrellas_3.png"));
                        estrellasLevel1 = 3;
                    }
                    break;
                case "IconoLucha2":
                    if (numeroEstrellas <= 2 && estrellasLevel2 < 1)
                    {
                        EstrellasNivel2.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrellas_1.png"));
                        estrellasLevel2 = 1;
                    }

                    else if (numeroEstrellas <= 5 && estrellasLevel2 < 2)
                    {
                        EstrellasNivel2.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrellas_2.png"));
                        estrellasLevel2 = 2;
                    }
                    else if(estrellasLevel2 < 3)
                    {
                        EstrellasNivel2.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrellas_3.png"));
                        estrellasLevel2 = 3;
                    }
                    break;
                case "IconoLucha3":
                    if (numeroEstrellas <= 2 && estrellasLevel3 < 1)
                    {
                        EstrellasNivel3.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrellas_1.png"));
                        estrellasLevel3 = 1;
                    }

                    else if (numeroEstrellas <= 5 && estrellasLevel3 < 2)
                    {
                        EstrellasNivel3.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrellas_2.png"));
                        estrellasLevel3 = 2;
                    }
                    else if(estrellasLevel3 < 3)
                    {
                        EstrellasNivel3.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrellas_3.png"));
                        estrellasLevel3 = 3;
                    }
                    break;
                case "IconoLucha4":
                    if (numeroEstrellas <= 2 && estrellasLevel4 < 1)
                    {
                        EstrellasNivel4.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrellas_1.png"));
                        estrellasLevel4 = 1;
                    }

                    else if (numeroEstrellas <= 5 && estrellasLevel4 < 2)
                    {
                        EstrellasNivel4.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrellas_2.png"));
                        estrellasLevel4 = 2;
                    }
                    else if(estrellasLevel4 < 3)
                    {
                        EstrellasNivel4.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrellas_3.png"));
                        estrellasLevel4 = 3;
                    }
                    break;
                case "IconoLucha5":
                    if (numeroEstrellas <= 2 && estrellasLevel5 < 1)
                    {
                        EstrellasNivel5.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrellas_1.png"));
                        estrellasLevel5 = 1;
                    }

                    else if (numeroEstrellas <= 5 && estrellasLevel5 < 2)
                    {
                        EstrellasNivel5.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrellas_2.png"));
                        estrellasLevel5 = 2;
                    }
                    else if(estrellasLevel5 < 3)
                    {
                        EstrellasNivel5.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrellas_3.png"));
                        estrellasLevel5 = 3;
                    }
                    break;
                case "IconoLucha6":
                    if (numeroEstrellas <= 2 && estrellasLevel6 < 1)
                    {
                        EstrellasNivel6.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrellas_1.png"));
                        estrellasLevel6 = 1;
                    }

                    else if (numeroEstrellas <= 5 && estrellasLevel6 < 2)
                    {
                        EstrellasNivel6.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrellas_2.png"));
                        estrellasLevel6 = 2;
                    }
                    else if(estrellasLevel6 < 3)
                    {
                        EstrellasNivel6.Source = new BitmapImage(new Uri("ms-appx:///Assets/estrellas_3.png"));
                        estrellasLevel6 = 3;
                    }
                    break;
            }
        }
    }
}
