namespace LojaRepositorios.ExtensionsMethods
{
	public static class StringExtensionMethod // .ObterCpfLimpo
	{
		public static string ObterCpfLimpo(this string texto)
		{
			return texto.Replace("-", "").Replace(".", "");
		}
	}
}
