using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public interface IComoComparar
	{
		bool esIgual (IComparable x, IComparable y);
		bool esMenor (IComparable x, IComparable y);
		bool esMayor (IComparable x, IComparable y);
	}
}
