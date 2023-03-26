using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public interface IFabricaDeComparables
	{
		IComparable crearAleatorio ();
		IComparable crearPorTeclado ();
		IComparable crearDesdeArchivo ();
	}
}
