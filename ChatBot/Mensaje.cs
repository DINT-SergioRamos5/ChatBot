using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot
{
    class Mensaje :INotifyPropertyChanged
    {
        private string _usuario;
        public string Usuario
        {
            get { return _usuario; }
            set
            {
                _usuario = value;
                this.NotifyPropertyChanged(Usuario);
            }
        }
        private string _mensaje;
        public string Mensaje
        {
            get { return _mensaje; }
            set
            {
                _mensaje = value;
                this.NotifyPropertyChanged(Mensaje);
            }
        }

        public Mensaje(string usuario, string mensaje)
        {
            this.usuario = usuario;
            this.mensaje = mensaje;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
