using System.Diagnostics;
using ExemplosOrientacaoObjetos.InterfacesConfirmacaoDados;

//IConfirmacaoCodigoSeguranca confirmacaoCodigoSeguranca;
//Console.WriteLine("Deseja confirmar o código de segurança por qual método?\n1 - SMS\n2 - E-mail");
//int menu = Convert.ToInt32(Console.ReadLine());

//if (menu == 1)
//{
//    confirmacaoCodigoSeguranca = new ConfirmacaoCodigoSegurancaSms();
//}
//else
//{
//    confirmacaoCodigoSeguranca = new ConfirmacaoCosigoSegurancaEmail();
//}

//string codigo = "1234567";
//confirmacaoCodigoSeguranca.EnviarCodigo(codigo);

using ExemplosOrientacaoObjetos;

var produtoA = new Produto();
var produtoB = new Produto();
var produtoC = new Produto();

// ProdutoA => 22
produtoA.Incrementar();
produtoA.Incrementar();

// ProdutoB => 23
produtoB.Incrementar();
produtoB.Incrementar();
produtoB.Incrementar();

// Pra classe Produto o Id é 10 pois é static
Produto.IncremmentarStatic();
Produto.IncremmentarStatic();

Console.WriteLine("Produto A: " + produtoA.id);
Console.WriteLine("Produto B: " + produtoB.id);
Console.WriteLine("Produto ID: " + Produto.Id);

