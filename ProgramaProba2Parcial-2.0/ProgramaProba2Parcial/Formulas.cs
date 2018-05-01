using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaProba2Parcial
{
    class Formulas
    {
        public static ulong calcularFactorial(int n)
        {
            if (n >= 2) return (ulong)n * calcularFactorial(n - 1);
            return 1;
        }

        public ulong combinatoria(int n, int r) {
           // Console.WriteLine("Valor de la combinatoria inferior");
            //Console.WriteLine(calcularFactorial(n - r));
            return calcularFactorial(n)/calcularFactorial(r)/calcularFactorial(n-r);
        }

        public double calcularConjunta(int X, int Y, int E1, int E2, int E3, int Cantidad) {
            double conjunta = 0;
            double combE1 = 0;
            double combE2 = 0;
            double combE3 = 0;
            double combTotal = 0;
            combE1 = combinatoria(E1, X);
            combE2 = combinatoria(E2, Y);
            combE3 = combinatoria(E3, (Cantidad-(X +Y)));
            combTotal = combinatoria((E1+E2+E3),Cantidad);

            conjunta = (combE1*combE2*combE3) / combTotal;

            return conjunta;
        }
       


    }
}
