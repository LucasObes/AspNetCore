using System.Diagnostics;
using ExemplosOrientacaoObjetos.InterfacesConfirmacaoDados;

IConfirmacaoCodigoSeguranca confirmacaoCodigoSeguranca;
Console.WriteLine("Deseja confirmar o código de segurança por qual método?\n1 - SMS\n2 - E-mail");
int menu = Convert.ToInt32(Console.ReadLine());

if(menu == 1)
{
    confirmacaoCodigoSeguranca = new ConfirmacaoCodigoSegurancaSms();
}
else
{
    confirmacaoCodigoSeguranca = new ConfirmacaoCosigoSegurancaEmail();
}

string codigo = "1234567";
confirmacaoCodigoSeguranca.EnviarCodigo(codigo);

