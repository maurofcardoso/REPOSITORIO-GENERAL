using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CFabricaDeAlumnosProxy : CFabricaDeComparables
	{
		public CFabricaDeAlumnosProxy()
		{
		}
		//*********************************************************************************************
		public override IComparable crearAleatorio () {
			return new CAlumnoProxy ();
		}
		public override IComparable crearPorTeclado () {
			return new CAlumnoProxy ();
		}
		public override IComparable crearDesdeArchivo () {
			return new CAlumnoProxy ();
		}
	}
}
