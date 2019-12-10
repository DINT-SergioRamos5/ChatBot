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

namespace ChatBot
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            ChatItemsControl = new ItemsControl();
            InitializeComponent();
        }

        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ChatItemsControl.Items.Clear();
        }

        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (ChatItemsControl.Items.Count != 0)
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string ruta = "";
            Microsoft.Win32.SaveFileDialog dialogo = new Microsoft.Win32.SaveFileDialog();

            dialogo.Filter = "Archivos de texto|*.txt";
            dialogo.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (dialogo.ShowDialog() == true )
            {
                ruta = dialogo.FileName;
            }

        }

        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (ChatItemsControl.Items.Count != 0)
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }

        private void ConfigCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DialogoConfiguracion configuracion = new DialogoConfiguracion();
            configuracion.Owner = this;
            configuracion.Title = "Configuracion";

            configuracion.ShowDialog();
        }
    }
}
