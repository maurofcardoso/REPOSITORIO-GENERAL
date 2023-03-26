using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CComparaBonus : IComoComparar
	{
		public CComparaBonus()
		{
		}
		//*******************************************************************************************
		public bool esIgual (IComparable x, IComparable y) {
			CVendedor vendedor1 = (CVendedor) x;
			CVendedor vendedor2 = (CVendedor) y;
			if (vendedor1.getBonus () == vendedor2.getBonus () ) {
				return true;
			}
			else {
				return false;
			}
		}
		public bool esMenor (IComparable x, IComparable y) {
			CVendedor vendedor1 = (CVendedor) x;
			CVendedor vendedor2 = (CVendedor) y;
			if (vendedor1.getBonus () < vendedor2.getBonus () ) {
				return true;
			}
			else {
				return false;
			}
		}
		public bool esMayor (IComparable x, IComparable y) {
			CVendedor vendedor1 = (CVendedor) x;
			CVendedor vendedor2 = (CVendedor) y;
			if (vendedor1.getBonus () > vendedor2.getBonus () ) {
				return true;
			}
			else {
				return false;
			}
		}
	}
}
