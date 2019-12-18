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
                this.NotifyPropertyChanged("Usuario");
            }
        }
        private string _mensajes;
        public string Mensajes
        {
            get { return _mensajes; }
            set
            {
                _mensajes = value;
                this.NotifyPropertyChanged("Mensajes");
            }
        }

        public Mensaje(string usuario, string mensaje)
        {
            this._usuario = usuario;
            this._mensajes = mensaje;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
