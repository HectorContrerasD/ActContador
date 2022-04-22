using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fracciones
{
    public class SumaYResta:INotifyPropertyChanged
    {
        public int Numerador1 { get; set; }
        public int Numerador2 { get; set; }
        public int Denominador1 { get; set; }
        public int Denominador2 { get; set; }
        public int NumeradorResult { get; set; }
        public int DenominadorResult { get; set; }
        public string Signo { get; set; }

        public ICommand FraccionResultCommand { get; set; }
        
        public SumaYResta()
        {
            FraccionResultCommand = new RelayCommand(FraccionResult);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void FraccionResult()
        {
            if (Denominador1 == Denominador2)
            {
                if (Signo == "+")
                {
                    NumeradorResult = Numerador1 + Numerador2;
                    DenominadorResult = Denominador1;

                }
                else
                {
                    NumeradorResult = Numerador1 - Numerador2;
                    DenominadorResult = Denominador1;

                }
            }
            else
            {
                if (Signo == "+")
                {
                    DenominadorResult = Denominador1 * Denominador2;
                    NumeradorResult = (Numerador1 * Denominador2) + (Numerador2 * Denominador1);

                }
                else
                {
                    DenominadorResult = Denominador1 * Denominador2;
                    NumeradorResult = (Numerador1 * Denominador2) - (Numerador2 * Denominador1);

                }
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
}
