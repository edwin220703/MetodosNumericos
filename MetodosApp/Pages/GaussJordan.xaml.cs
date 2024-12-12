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
    /// Lógica de interacción para GaussJordan.xaml
    /// </summary>
    public partial class GaussJordan : Page
    {
        private int n;
        private List<TextBox> m;
        private double[,] MatrizOrganizada;

        public GaussJordan()
        {
            InitializeComponent();
            m = new List<TextBox>();
        }

        private void Btn_Creation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.n = Convert.ToInt16(Tb_N.Text);
                CreateTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void CreateTable()
        {

            Dispatcher.Invoke(new Action(() =>
            {
                SP_Body.Children.Clear();
                SP_Body.MaxWidth = (n * 100) + (n * 10) + 200;

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n + 1; j++)
                    {
                        SP_Body.Children.Add(new TextBox()
                        {
                            Width = 100,
                            Height = 30
                        });

                        if (j == n - 1)
                        {
                            SP_Body.Children.Add(new Label()
                            {
                                Content = $"X{j + 1} =",
                                FontSize = 10
                            });
                        }
                        else if (j < n)
                        {
                            SP_Body.Children.Add(new Label()
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

        private void Btn_Calculate_Click(object sender, RoutedEventArgs e)
        {
            m = SP_Body.Children.OfType<TextBox>().ToList();

            //Organizar los datos
            MatrizOrganizada = new double[n, n + 1];

            int i = 0, j = 0;

            foreach (var l in m)
            {
                MatrizOrganizada[i, j] = Convert.ToDouble(l.Text);
                j++;

                if (j == n + 1)
                {
                    i++;
                    j = 0;
                }
            }

            ExecuterServices();
        }

        public void ExecuterServices()
        {
            GaussJordanServices gaussJordanServices = new GaussJordanServices(MatrizOrganizada, n);

            var GaussFinal = gaussJordanServices.GetMatriz();

            //Añadiendo el Resultado
            WP_Data.Children.Clear();
            WP_Data.MaxWidth = (n * 100) + (n * 10) + 200;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                    WP_Data.Children.Add(new TextBox()
                    {
                        Text = GaussFinal[i, j].ToString(),
                        IsReadOnly = true,
                        Width = 100,
                        Height = 30
                    });


                    if (j == n - 1)
                    {
                        WP_Data.Children.Add(new Label()
                        {
                            Content = $"X{j + 1} =",
                            FontSize = 10
                        });
                    }
                    else if (j < n)
                    {
                        WP_Data.Children.Add(new Label()
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

        }

    }
}
