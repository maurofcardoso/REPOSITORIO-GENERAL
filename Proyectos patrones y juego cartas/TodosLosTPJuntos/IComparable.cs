using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public interface IComparable
	{
		bool sosIgual (IComparable x);
		bool sosMenor (IComparable x);
		bool sosMayor (IComparable x);
		void setComparar (string tipo);
	}
}
