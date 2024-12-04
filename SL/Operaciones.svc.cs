using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Operaciones" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Operaciones.svc or Operaciones.svc.cs at the Solution Explorer and start debugging.
    public class Operaciones : IOperaciones
    {
        public void DoWork()
        {
        }
        public int Suma(int n1, int n2)
        {
            return n1 + n2;
        }
        public int Resta(int n1, int n2)
        {
            return n1 - n2;
        }
        public  int Division(int n1, int n2)
        {
            return n1 / n2;
        }
        public int Multiplicacion(int n1, int n2)
        {
            return n1 * n2;
        }
    }
}
