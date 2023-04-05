using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedData
{
    public enum OperationType { Add, Sub, Mult, Div };
    public class Requst
    {
        public double A { get; set; }
        public double B { get; set; }
        public OperationType Operation { get; set; }
    }
}
