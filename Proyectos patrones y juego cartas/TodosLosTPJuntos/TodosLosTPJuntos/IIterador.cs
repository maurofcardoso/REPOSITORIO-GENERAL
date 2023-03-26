using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public interface IIterador
	{
		void primero ();
		void siguiente ();
		bool fin ();
		IComparable actual ();
		
	}
}
