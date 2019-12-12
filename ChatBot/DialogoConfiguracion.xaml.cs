using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace ChatBot
{
    /// <summary>
    /// Lógica de interacción para DialogoConfiguracion.xaml
    /// </summary>
    public partial class DialogoConfiguracion : Window
    {
        public string ColorFondo { get; set; }
        public string ColorUsuario { get; set; }
        public string ColorBot { get; set; }
        public DialogoConfiguracion()
        {
            InitializeComponent();
            FondoComboBox.ItemsSource = typeof(Colors).GetProperties();
            UsuarioComboBox.ItemsSource = typeof(Colors).GetProperties();
            RobotComboBox.ItemsSource = typeof(Colors).GetProperties();
        }
       

        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            ColorFondo = FondoComboBox.SelectedItem.ToString();
            ColorUsuario = UsuarioComboBox.SelectedItem.ToString();
            ColorBot = RobotComboBox.SelectedItem.ToString();
        }
    }
}
