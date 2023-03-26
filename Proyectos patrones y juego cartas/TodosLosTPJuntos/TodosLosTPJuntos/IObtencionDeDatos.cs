using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TodosLosTPJuntos
{
	public interface IObtencionDeDatos
	{
		IComparable numeroAleatorio (int max);
		string stringAleatorio (int cant);
		IComparable numeroPorTeclado ();
		string stringPorTeclado ();
		IComparable numeroDesdeArchivo(int max);
		string stringDesdeArchivo(int cant);
	}
}
