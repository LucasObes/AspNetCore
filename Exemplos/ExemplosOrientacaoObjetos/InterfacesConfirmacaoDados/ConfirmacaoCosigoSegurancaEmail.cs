using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemplosOrientacaoObjetos.InterfacesConfirmacaoDados
{
    internal class ConfirmacaoCosigoSegurancaEmail : IConfirmacaoCodigoSeguranca
    {
        public void EnviarCodigo(string codigo)
        {
            Console.WriteLine($"Enviando o código '{codigo}' de segurança por e-mail");
        }
    }
}
