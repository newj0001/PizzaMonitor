using PizzaMonitor.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PizzaMonitor.View
{
    class PizzaViewModel : INotifyPropertyChanged
    {
        PizzaModel pizza = new PizzaModel();

        public Image Billede
        {
            get
            {

                return pizza.image = DataAccessLayer.GetPizza();
                
            }
            set
            {
                pizza.image = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
