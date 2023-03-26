using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CLectorDeDatos : CManejadorDeDatos, IObtencionDeDatos
	{
		private static CLectorDeDatos unico = null;
		//*******************************************************************************************
		private CLectorDeDatos(IObtencionDeDatos sucesor) : base (sucesor)
		{
			
		}
		//********************************************************************************************
		public static CLectorDeDatos getInstancia (IObtencionDeDatos sucesor) {
			if (unico == null) {
				unico = new CLectorDeDatos (sucesor);
			}
			return unico;
		}
		public override IComparable numeroPorTeclado () {
			Console.WriteLine ("INGRESE EL NUMERO QUE DESEA: ");
			return new CNumero (int.Parse (Console.ReadLine () ) );
		}
		public override string stringPorTeclado () {
			Console.WriteLine ("INGRESE LA CADENA QUE DESEA: ");
			return Console.ReadLine ();
		}
		public IComparable numeroAleatorio (int max) {
			return new CNumero (-1);
		}
		public string stringAleatorio (int cant) {
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
