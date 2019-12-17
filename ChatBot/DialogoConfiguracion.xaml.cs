using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
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
 
    public partial class DialogoConfiguracion : Window
    {
        public string ColorFondo { get; set; }
        public string ColorUsuario { get; set; }
        public string ColorRobot { get; set; }

        public DialogoConfiguracion()
        {
            InitializeComponent();

            ColorFondo = Properties.Settings.Default.ColorFondo;
            ColorUsuario = Properties.Settings.Default.ColorUsuario;
            ColorRobot = Properties.Settings.Default.ColorRobot;

            FondoComboBox.ItemsSource = typeof(Colors).GetProperties();
            UsuarioComboBox.ItemsSource = typeof(Colors).GetProperties();
            RobotComboBox.ItemsSource = typeof(Colors).GetProperties();


            FondoComboBox.SelectedItem = ((PropertyInfo[])FondoComboBox.ItemsSource).ToList().Find (a => a.Name == ColorFondo) ;
            UsuarioComboBox.SelectedItem = ((PropertyInfo[])UsuarioComboBox.ItemsSource).ToList().Find(a => a.Name == ColorUsuario);
            RobotComboBox.SelectedItem = ((PropertyInfo[])RobotComboBox.ItemsSource).ToList().Find(a => a.Name == ColorRobot);

        }
       
        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {                     
            ColorFondo = ((PropertyInfo)FondoComboBox.SelectedItem).Name;
            ColorUsuario = ((PropertyInfo)UsuarioComboBox.SelectedItem).Name;
            ColorRobot = ((PropertyInfo)RobotComboBox.SelectedItem).Name;

            Properties.Settings.Default.ColorFondo = ColorFondo.ToString();
            Properties.Settings.Default.ColorUsuario = ColorUsuario.ToString();
            Properties.Settings.Default.ColorRobot = ColorRobot.ToString();
            Properties.Settings.Default.Save();

            DialogResult = true;
        }
    }
}
