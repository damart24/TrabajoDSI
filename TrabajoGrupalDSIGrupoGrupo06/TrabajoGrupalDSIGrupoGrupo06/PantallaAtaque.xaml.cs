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
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace TrabajoGrupalDSIGrupoGrupo06
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class PantallaAtaque : Page
    {
        public PantallaAtaque()
        {
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
    }
}
