using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PizzaMonitor.Model
{
    class PizzaModel
    {
        public long Id { get; set; }
        public byte[] byteArray { get; set; }
        public Image image { get; set; }
    }
}
