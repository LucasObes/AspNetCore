using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemplosOrientacaoObjetos.Interfaces
{
    internal interface IContaDeposito
    {
        // Interface: é um contrato, define o que um método vai fazer. Comportamento compartilhado entre várias classes em uma só
        void Depositar(decimal valor);
    }
}
