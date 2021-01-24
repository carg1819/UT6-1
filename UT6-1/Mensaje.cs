using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT6_1
{
    class Mensaje : INotifyPropertyChanged
    {
        private string _nombre;
        private string _texto;



        public string Nombre
        {
            get { return this._nombre; }
            set
            {
                if (this._nombre != value)
                {
                    this._nombre = value;
                    this.NotifyPropertyChanged("Nombre");
                }
            }
        }
        public string Texto
        {
            get { return this._texto; }
            set
            {
                if (this._texto != value)
                {
                    this._texto = value;
                    this.NotifyPropertyChanged("Mensaje");
                }
            }
        }

        public Mensaje(string nombre, string texto)
        {
            Nombre = nombre;
            Texto = texto;
        }

        public Mensaje()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
