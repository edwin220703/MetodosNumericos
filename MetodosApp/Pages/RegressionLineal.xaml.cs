using MetodosApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Lógica de interacción para RegressionLineal.xaml
    /// </summary>
    public partial class RegressionLineal : Page
    {
        RegressionLinealServices services;

        public RegressionLineal()
        {
            InitializeComponent();
            services = new RegressionLinealServices();
        }

        private void BTN_Agregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                services.AgregarModelo(Convert.ToDouble(TB_X.Text), Convert.ToDouble(TB_Y.Text));
                UpdateData();
                ResultLCC();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Solo Valores Numericos");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateData()
        {
            DG_Tabla.ItemsSource = services.models.ToList();
        }

        public void ResultLCC()
        {
            LB_ResultadoLineal.Content = services.MetodoLineal().ToString();
            LB_ResultadoCuadratica.Content = services.MetodoCuatratica().ToString();
            LB_ResultadoCubica.Content = services.MetodoCubico().ToString();
        }

        public void GaussJordanLineal()
        {
            double[,] matriz = services.GetMatrizLineal();

            Dispatcher.Invoke(new Action(() =>
            {
                int n = 2;
                WP_Lineal.Children.Clear();
                WP_Lineal.MaxWidth = (n * 100) + (n * 10) + 200;

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n + 1; j++)
                    {
                        WP_Lineal.Children.Add(new TextBox()
                        {
                            Text = matriz[i, j].ToString(),
                            Width = 100,
                            Height = 30,
                            IsReadOnly = true,
                        });

                        if (j == n - 1)
                        {
                            WP_Lineal.Children.Add(new Label()
                            {
                                Content = $"X{j + 1} =",
                                FontSize = 10
                            });
                        }
                        else if (j < n)
                        {
                            WP_Lineal.Children.Add(new Label()
                            {
                                Content = $"X{j + 1}",
                                FontSize = 10
                            });
                        }
                        else
                        {

                        }
                    }
                }
            }));
        }

        public void GaussJordanCuadratico()
        {
            double[,] matriz = services.GetMatrizCuadratica();

            Dispatcher.Invoke(new Action(() =>
            {
                int n = 3;
                WP_Cuadratica.Children.Clear();
                WP_Cuadratica.MaxWidth = (n * 100) + (n * 10) + 200;

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n + 1; j++)
                    {
                        WP_Cuadratica.Children.Add(new TextBox()
                        {
                            Text = matriz[i, j].ToString(),
                            Width = 100,
                            Height = 30,
                            IsReadOnly = true,
                        });

                        if (j == n - 1)
                        {
                            WP_Cuadratica.Children.Add(new Label()
                            {
                                Content = $"X{j + 1} =",
                                FontSize = 10
                            });
                        }
                        else if (j < n)
                        {
                            WP_Cuadratica.Children.Add(new Label()
                            {
                                Content = $"X{j + 1}",
                                FontSize = 10
                            });
                        }
                        else
                        {

                        }
                    }
                }
            }));
        }

        public void GaussJordarCubico()
        {
            double[,] matriz = services.GetMatrizCubico();

            Dispatcher.Invoke(new Action(() =>
            {
                int n = 4;
                WP_Cubica.Children.Clear();
                WP_Cubica.MaxWidth = (n * 100) + (n * 10) + 200;

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n + 1; j++)
                    {
                        WP_Cubica.Children.Add(new TextBox()
                        {
                            Text = matriz[i, j].ToString(),
                            Width = 100,
                            Height = 30,
                            IsReadOnly = true
                        });

                        if (j == n - 1)
                        {
                            WP_Cubica.Children.Add(new Label()
                            {
                                Content = $"X{j + 1} =",
                                FontSize = 10
                            });
                        }
                        else if (j < n)
                        {
                            WP_Cubica.Children.Add(new Label()
                            {
                                Content = $"X{j + 1}",
                                FontSize = 10
                            });
                        }
                        else
                        {

                        }
                    }
                }
            }));
        }

        private void BTN_GaussCalcular_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Esta Seguro De Calcular Por El Metodo Gauss Jordan?", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                GaussJordanLineal();
                GaussJordanCuadratico();
                GaussJordarCubico();
            }


        }
    }
}
