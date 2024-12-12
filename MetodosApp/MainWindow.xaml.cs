using MetodosApp.Models;
using MetodosApp.Pages;
using MetodosApp.Services;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MetodosApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Button> buttons;

        public MainWindow()
        {
            InitializeComponent();

            buttons = new List<Button>()
            {
                btn_Biseccion,
                btn_ReglaFalsa,
                btn_Secante,
                btn_Newton,
                btn_GaussJordan,
                btn_Interpolacion,
                btn_RegressionLineal
            };
        }

        private void btn_Options_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = (Button)sender;

                foreach (var a in buttons)
                {
                    a.Background = new SolidColorBrush(Colors.Transparent);

                    a.BorderBrush = new SolidColorBrush(Colors.Transparent);

                    if (a.Name == btn.Name)
                    {
                        btn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#033649"));
                        btn.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#033649"));
                    }
                }

                //Llamando al panel para mostrarlo
                switch (btn.Name)
                {
                    case "btn_Biseccion": { panel_General.NavigationService.Navigate(new PanelMath(btn.Name.ToString())); }; break;
                    case "btn_ReglaFalsa": { panel_General.NavigationService.Navigate(new PanelMath(btn.Name.ToString())); }; break;
                    case "btn_Secante": { panel_General.NavigationService.Navigate(new PanelMath(btn.Name.ToString())); }; break;
                    case "btn_Newton": { panel_General.NavigationService.Navigate(new PanelMath(btn.Name.ToString())); }; break;
                    case "btn_GaussJordan": { panel_General.NavigationService.Navigate(new GaussJordan()); }; break;
                    case "btn_Interpolacion": { panel_General.NavigationService.Navigate(new Interpolacion()); }; break;
                    case "btn_RegressionLineal": { panel_General.NavigationService.Navigate(new Pages.RegressionLineal()); }; break;
                    default:
                        {
                            MessageBox.Show("Esa Opcion No existe");
                        };break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
    }
}