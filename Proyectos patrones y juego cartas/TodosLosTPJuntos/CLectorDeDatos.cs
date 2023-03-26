using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CLectorDeDatos
	{
		public CLectorDeDatos()
		{
		}
		//********************************************************************************************
		public IComparable numeroPorTeclado () {
			Console.WriteLine ("INGRESE EL NUMERO QUE DESEA: ");
			return new CNumero (int.Parse (Console.ReadLine () ) );
		}
		public string stringPorTeclado () {
			Console.WriteLine ("INGRESE LA CADENA QUE DESEA: ");
			return Console.ReadLine ();
		}
	}
}
