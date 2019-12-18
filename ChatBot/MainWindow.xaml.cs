using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
        ObservableCollection<Mensaje> lista;
        Bot chat;
        bool flag = true;
        public MainWindow()
        {
            ChatItemsControl = new ItemsControl();
            chat = new Bot();
            lista = new ObservableCollection<Mensaje>();
            EnviarTextBox = new TextBox();

            InitializeComponent();

            ChatItemsControl.DataContext = lista;
        }

        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            lista.Clear();
        }

        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (lista.Count != 0)
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string ruta = "";
            Microsoft.Win32.SaveFileDialog dialogo = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "Archivos de texto|*.txt",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };

            if (dialogo.ShowDialog() == true )
            {
                ruta = dialogo.FileName;
                File.WriteAllText(dialogo.FileName, GuardarConversacion());
            }

        }

        private string GuardarConversacion()
        {
            string texto = "";

            foreach (var obj in lista)
            {
                texto += obj.Usuario+ " " + obj.Mensajes + "\n";
            }

            return texto;
        }

        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (lista.Count != 0)
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

        private async void SubmitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Mensaje m = new Mensaje("Usuario", EnviarTextBox.Text);
            lista.Add(m);
            string mensajeUsuario = EnviarTextBox.Text;

            EnviarTextBox.Text = "";
            flag = false;
            Mensaje mr = new Mensaje("Robot", "Procesando...");
            lista.Add(mr);
            string respuesta = await chat.RespuestaBotAsync(mensajeUsuario);
            lista.Last().Mensajes = respuesta;
            flag = true;
            ScrollViewer.ScrollToEnd();
        }

        private void SubmitCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (flag == false || EnviarTextBox.Text == "")
            {
                e.CanExecute = false;
            }
            else
                e.CanExecute = true;
        }

        private async void ConexCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                await chat.RespuestaBotAsync("Buenas");
                MessageBox.Show("Conexión realizada", "AVISO", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("No hay conexion", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }            

        }
    }
}
