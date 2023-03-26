using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public interface IColeccionable : IIterable
	{
		int cuantos ();
		IComparable minimo ();
		IComparable maximo ();
		void agregar (IComparable x);
		bool contiene (IComparable x);
	}
}
