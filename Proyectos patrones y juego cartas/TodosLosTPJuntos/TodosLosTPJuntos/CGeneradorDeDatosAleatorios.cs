using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CGeneradorDeDatosAleatorios : CManejadorDeDatos, IObtencionDeDatos
	{
		private static CGeneradorDeDatosAleatorios unico = null;
		//******************************************************************************************
		private CGeneradorDeDatosAleatorios(IObtencionDeDatos sucesor) : base (sucesor)
		{
		}
		//*******************************************************************************************
		public static CGeneradorDeDatosAleatorios getInstancia (IObtencionDeDatos sucesor) {
			if (unico == null) {
				unico = new CGeneradorDeDatosAleatorios (sucesor);
			}
			return unico;
		}
		public override IComparable numeroAleatorio (int max) {
			Random auxiliar = new Random ();
			return new CNumero (auxiliar.Next (1, max) );
		}
		public override string stringAleatorio (int cant) {
			string caracteres = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
        	StringBuilder auxiliar = new StringBuilder();
        	Random random = new Random();
        	while (0 < cant--)
        	{
        	    auxiliar.Append(caracteres[random.Next(caracteres.Length)]);
        	}
        	return auxiliar.ToString();
		}
		public IComparable numeroPorTeclado () {
			return new CNumero (-1);
		}
		public string stringPorTeclado () {
			return "";
		}
		public double numeroDesdeArchivo(double max) {
			return -1;
		}
		public string stringDesdeArchivo(int cant) {
			return "";
		}
	}
}
