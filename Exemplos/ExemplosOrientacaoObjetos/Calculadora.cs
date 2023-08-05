using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemplosOrientacaoObjetos
{
    public class Calculadora
    {
       public int Somar(int numero1, int numero2)
        {
            if (numero1 < 0)
            {
                throw new Exception("Número 1 não deve conter números negativos");
            }

            if(numero2 > 1000)
            {
                throw new Exception("Número 2 não deve ser maior que 1000");
            }

            return numero1 + numero2;
        }
    }
}
