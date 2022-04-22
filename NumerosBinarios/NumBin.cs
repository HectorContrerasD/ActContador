using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NumerosBinarios
{
    public class NumBin : INotifyPropertyChanged
    {
        int numero;
        bool jugar;
        
        public ICommand GenerarnumCommand { get; set; }
        public ICommand VerificarCommand { get; set; }

        public NumBin()
        {
            GenerarnumCommand = new RelayCommand(GenerarNum);
            VerificarCommand = new RelayCommand(Verificar);
        }
        public int Valor { get; set; }
        public string Mensaje { get; set; }

        public string Binario
        {
            get { return Convert.ToString(numero, 2); }
        }
        public bool Jugar => jugar;
        public event PropertyChangedEventHandler PropertyChanged;
        public void GenerarNum()
        {
            Valor = 0;
            Random r = new();
            numero = r.Next(1, 255);
            jugar = true;
            Mensaje = "El juego ha comenzado";
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
        public void Verificar()
        {
            if (jugar)
            {
                if (Valor < 0)
                {
                    Mensaje = "El número no pude ser negativo";
                }
                else
                {
                    if (Valor == numero)
                    {
                        jugar = false;
                        Mensaje = "El número es correcto";
                    }
                    else
                    {
                        Mensaje = "El número es incorrecto";                       
                    }
                }
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
}
