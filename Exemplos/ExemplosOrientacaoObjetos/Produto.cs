using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemplosOrientacaoObjetos
{
    public class Produto
    {
        // Static: utilizado para armazenar uma informação global
        public static int Id = 10;
        public int id = 20;

        public void Incrementar()
        {
            id++;
        }

        public static void IncremmentarStatic()
        {
            Id++;
        }
    }
}
