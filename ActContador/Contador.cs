
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ActContador
{
    public class Contador: INotifyPropertyChanged
    {
        uint numero;

        public ICommand AumentarCommand { get; set; }
        public ICommand DecrementarCommand { get; set; }

        public ICommand ReiniciarCommand { get; set; }

        public Contador()
        {
            AumentarCommand = new RelayCommand(Aumentar);
            DecrementarCommand = new RelayCommand(Decrementar);
            ReiniciarCommand = new RelayCommand(Reiniciar);
        }
        public uint Numero 
        {
            get { return numero; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Aumentar()
        {
            numero++;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
        public void Decrementar()
        {
            numero--;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
        public void Reiniciar()
        {
            numero = 0;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

    }
}
