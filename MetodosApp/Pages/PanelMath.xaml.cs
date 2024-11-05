using MetodosApp.Models;
using MetodosApp.Services;
using MetodosApp.Services.Interfase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MetodosApp.Pages
{
    /// <summary>
    /// Lógica de interacción para PanelMath.xaml
    /// </summary>
    public partial class PanelMath : Page
    {
        private double xi { get; set; } = 0;
        private double xd { get; set; } = 0;
        private double tol { get; set; } = 0.001;
        private int n = 20;
        private string optionServices { get; set; }

        public PanelMath(string _optionServices)
        {
            InitializeComponent();

            this.optionServices = _optionServices;
            ChangedVisibilityColumns();

        }

        public void ChangedVisibilityColumns()
        {

            switch (optionServices)
            {
                case "btn_Biseccion":
                    {
                        DG_Data.Columns[3].Visibility = Visibility.Collapsed;
                        DG_Data.Columns[5].Visibility = Visibility.Collapsed;
                    }; break;
                case "btn_ReglaFalsa":
                    {
                        DG_Data.Columns[3].Visibility = Visibility.Collapsed;
                        DG_Data.Columns[5].Visibility = Visibility.Collapsed;
                    }; break;
                case "btn_Secante":
                    {
                        DG_Data.Columns[2].Visibility = Visibility.Collapsed;
                        DG_Data.Columns[5].Visibility = Visibility.Collapsed;
                        DG_Data.Columns[7].Visibility = Visibility.Collapsed;
                    }; break;
                case "btn_Newton":
                    {
                        txt_Xd.IsEnabled = false;
                        DG_Data.Columns[1].Visibility = Visibility.Collapsed;
                        DG_Data.Columns[2].Visibility = Visibility.Collapsed;
                        DG_Data.Columns[6].Visibility = Visibility.Collapsed;
                        DG_Data.Columns[7].Visibility = Visibility.Collapsed;
                        DG_Data.Columns[8].Visibility = Visibility.Collapsed;
                        
                    }; break;
                default:
                    {
                        Console.WriteLine("La opcion enviada no es correcta");
                    }; break;
            }
        }

        public bool VerificarDatos()
        {
            //RUTAS PARA VERIFICAR DATOS Decimales
            string pathDecimal = "^[+]?\\d+(\\.\\d+)?$";

            //RUTA PARA VERIFICAR DATOS INT
            string pathIntegrel = "^[1-9]\\d*$";

            Regex r = new Regex(pathDecimal);

            try
            {
                //TOLERANCIA
                if (Convert.ToDouble(txt_Tol.Text) < 0 && !r.IsMatch(txt_Tol.Text))
                {
                    MessageBox.Show("La tolerancia debe ser numero positivo", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }

                //XI y XD
                if (Convert.ToDouble(txt_Xi.Text) >= Convert.ToDouble(txt_Xd.Text) && optionServices != "btn_Newton")
                {
                    MessageBox.Show("El rango inicial (Xi) debe ser menor al rango mayor (Xd)", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }


                //ITERACION
                r = new Regex(pathIntegrel);

                if (Convert.ToDouble(txt_N.Text) < 0 && !r.IsMatch(txt_N.Text))
                {
                    MessageBox.Show("La iteracion debe ser numero positivo entero", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            return true;
        }

        private void btn_Values_Click(object sender, RoutedEventArgs e)
        {
            if (!VerificarDatos())
            {
                MessageBox.Show("Verificar los campos nuevamente");
            }

            try
            {
                xi = Convert.ToDouble(txt_Xi.Text);

                if (optionServices != "btn_Newton")
                    xd = Convert.ToDouble(txt_Xd.Text);

                tol = Convert.ToDouble(txt_Tol.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            switch (optionServices)
            {
                case "btn_Biseccion":
                    {
                        DG_Data.ItemsSource = new BiseccionServices(xi, xd, tol, n).GetAllResult();
                        ChangedVisibilityColumns();
                    }; break;
                case "btn_ReglaFalsa":
                    {
                        DG_Data.ItemsSource = new ReglaFalsaServices(xi, xd, tol, n).GetAllResult();
                    }; break;
                case "btn_Secante":
                    {
                        DG_Data.ItemsSource = new SecanteServices(xi, xd, tol, n).GetAllResult();
                    }; break;
                case "btn_Newton":
                    {
                        DG_Data.ItemsSource = new NewtonServices(xi, tol, n).GetAllResult();
                    }; break;
                default:
                    {
                        Console.WriteLine("La opcion enviada no es correcta");
                    }; break;
            }
        }
    }

}
