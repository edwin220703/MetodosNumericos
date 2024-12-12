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
    /// Lógica de interacción para Interpolacion.xaml
    /// </summary>
    public partial class Interpolacion : Page
    {
        private List<TextBox> _textList;
        private string search;

        public Interpolacion()
        {
            InitializeComponent();
            _textList = new List<TextBox>
            {
                TB_X,
                TB_X1,
                TB_X2,
                TB_Fx,
                TB_Fx1,
                TB_Fx2
            };

        }

        private void btn_Busca_Click(object sender, RoutedEventArgs e)
        {
            double value = 0;

            try
            {
                search = _textList.Where(x => x.Text == string.Empty).Select(x => x.Name).First();

                switch (search)
                {
                    case "TB_X": {
                            double X1 = Convert.ToDouble(TB_X1.Text);
                            double X2 = Convert.ToDouble(TB_X2.Text);
                            double Fx1 = Convert.ToDouble(TB_Fx1.Text);
                            double Fx = Convert.ToDouble(TB_Fx.Text);
                            double Fx2 = Convert.ToDouble(TB_Fx2.Text);

                            value = X1 + ((Fx - Fx1) * (X2 - X1) / (Fx2 - Fx1));

                        } break;
                    case "TB_X1": {

                            double X = Convert.ToDouble(TB_X.Text);
                            double X2 = Convert.ToDouble(TB_X2.Text);
                            double Fx1 = Convert.ToDouble(TB_Fx1.Text);
                            double Fx = Convert.ToDouble(TB_Fx.Text);
                            double Fx2 = Convert.ToDouble(TB_Fx2.Text);

                            value = X - ((Fx - Fx1) * (X2 - X) / (Fx2 - Fx1));
                        }; break;
                    case "TB_X2": {

                            double X = Convert.ToDouble(TB_X.Text);
                            double X1 = Convert.ToDouble(TB_X1.Text);
                            double Fx1 = Convert.ToDouble(TB_Fx1.Text);
                            double Fx = Convert.ToDouble(TB_Fx.Text);
                            double Fx2 = Convert.ToDouble(TB_Fx2.Text);

                            value = X1 + ((Fx2-Fx1) * (X-X1) / (Fx-Fx1));
                        }; break;
                    case "TB_Fx":
                        {
                            double X = Convert.ToDouble(TB_X.Text);
                            double X1 = Convert.ToDouble(TB_X1.Text);
                            double X2 = Convert.ToDouble(TB_X2.Text);
                            double Fx1 = Convert.ToDouble(TB_Fx1.Text);
                            double Fx2 = Convert.ToDouble(TB_Fx2.Text);

                            value = Fx1 + ((Fx2 - Fx1) / (X2 - X1)) * (X - X1);
                        }; break;
                    case "TB_Fx1": {

                        }; break;
                    case "TB_Fx2": {
                            double X = Convert.ToDouble(TB_X.Text);
                            double X1 = Convert.ToDouble(TB_X1.Text);
                            double X2 = Convert.ToDouble(TB_X2.Text);
                            double Fx1 = Convert.ToDouble(TB_Fx1.Text);
                            double Fx = Convert.ToDouble(TB_Fx.Text);

                            value = Fx1 + ((Fx - Fx1) * (X2 - X1) / (X - X1));
                        }; break;
                }

                MessageBox.Show($"El valor buscado de {search} es {value}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }

        public bool VerificarDatos()
        {
            try
            {
                if (_textList.Where(x => x.Name == string.Empty).Count() > 1)
                {
                    MessageBox.Show("Solo puede dejar un campo en blanco");
                    return false;
                }

                if (Convert.ToDouble(TB_X.Text) < Convert.ToDouble(TB_X1.Text) || Convert.ToDouble(TB_X.Text) > Convert.ToDouble(TB_X2.Text) || Convert.ToDouble(TB_X1.Text) > Convert.ToDouble(TB_X2.Text))
                {
                    MessageBox.Show("Los valores estan mal colocados, verifique de nuevo");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }


            return true;
        }
    }
}
