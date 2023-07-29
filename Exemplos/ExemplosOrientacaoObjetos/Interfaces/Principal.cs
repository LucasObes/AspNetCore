using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemplosOrientacaoObjetos.Interfaces
{
    internal class Principal
    {
        public void Executar()
        {
            var contaCorrente = new ContaCorrente();
            contaCorrente.Depositar(100);
            contaCorrente.SacarUtilizandoChequeEspecial(950);

            var contaSalario = new ContaSalario();
            contaSalario.Depositar(100);
            contaSalario.Sacar(120);

            Console.WriteLine($"Conta corrente: {contaCorrente.Saldo}");
            Console.WriteLine($"Conta salário: {contaSalario.Saldo}");
        }
    }
}
