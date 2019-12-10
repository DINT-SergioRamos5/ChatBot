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
        public DialogoConfiguracion()
        {
            InitializeComponent();

            ObservableCollection<Colores> listaColor = new ObservableCollection<Colores>();

            var co = typeof(Colors).GetProperties();

            foreach (var a in co)
            {
                Colores colores = new Colores();
                colores.Nombre = a.Name;
                listaColor.Add(colores); 
            }

            ColoresComboBox.DataContext = listaColor;
        }
    }
}
