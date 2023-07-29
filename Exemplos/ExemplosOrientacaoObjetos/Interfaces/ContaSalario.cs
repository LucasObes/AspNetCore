using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemplosOrientacaoObjetos.Interfaces
{
    internal class ContaSalario : IContaDeposito, IContaSaque
    {
        // private set: permite que somente classes de dentro do projeto interfiram no Saldo
        public decimal Saldo { get; private set; } = 0;
        public void Depositar(decimal valor) // Assinatura: void Depositar (decimal valor)
        {
            Saldo += valor * 1.05m;
        }

        public void Sacar(decimal valor)
        {
            if(Saldo - valor < 0)
            {
                throw new Exception("Conta não possui saldo suficiente para a operação"); 
            }
            else
            {
                Saldo -= valor;
            }
        }

        public void SacarUtilizandoChequeEspecial(decimal valor)
        {
            throw new Exception("Conta Salário não possui a opção de saque com Cheque Especial habilitada");
        }
    }
}
