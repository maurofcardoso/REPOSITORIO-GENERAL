using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CFabricaDeAlumnoCompuesto : CFabricaDeComparables
	{
		public CFabricaDeAlumnoCompuesto()
		{
		}
		//*****************************************************************************************
		public override IComparable crearAleatorio () {
			return new CAlumnoCompuesto ();
		}
		public override IComparable crearPorTeclado () {
			return new CAlumnoCompuesto ();
		}
	}
}
