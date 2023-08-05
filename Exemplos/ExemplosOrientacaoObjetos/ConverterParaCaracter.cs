using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemplosOrientacaoObjetos
{
    public class ConverterParaCaracter
    {
        /* Criar um método Converter que vai utilizar como base a tabela Ascii recebendo como parâmetro um número inteiro. 
         * O método deve converter o número para a letra correspondente.
         * Números anteriores a 65 devem ser recusados, assim como números superiores a 90 à 96 e números superiores à 122*/

        public string Converter(int numero)
        {
            if (numero == 65)
            {
                return "A";
            }

            if (numero == 66)
            {
                return "B";
            }

            if (numero == 67)
            {
                return "C";
            }

            if (numero == 68)
            {
                return "D";
            }

            if (numero == 69)
            {
                return "E";
            }
            
            if (numero == 70)
            {
                return "F";
            }
            
            if (numero == 71)
            {
                return "G";
            }
            
            if (numero == 72)
            {
                return "H";
            }
            
            if (numero == 73)
            {
                return "I";
            }
            
            if (numero == 74)
            {
                return "J";
            }
            
            if (numero == 75)
            {
                return "K";
            }
            
            if (numero == 76)
            {
                return "L";
            }
            
            if (numero == 77)
            {
                return "M";
            }
            
            if (numero == 78)
            {
                return "N";
            }
            
            if (numero == 79)
            {
                return "O";
            }
            
            if (numero == 80)
            {
                return "P";
            }
            
            if (numero == 81)
            {
                return "Q";
            }
            
            if (numero == 82)
            {
                return "R";
            }
            
            if (numero == 83)
            {
                return "S";
            }
            
            if (numero == 84)
            {
                return "T";
            }

            if (numero < 65)
            {
                throw new Exception("O número não pode ser menor que 65");
            }

            if (numero > 90 && numero < 97)
            {
                throw new Exception("O número não pode ser maior que 90 e menor que 97");
            }

            if (numero > 122)
            {
                throw new Exception("O número não pode ser maior que 122");
            }

            if (numero == 122) 
            {
                return "z";
            }
            return "";
        }
    }
}
