using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CComparaNombre : IComoComparar
	{
		public CComparaNombre()
		{
		}
		//*********************************************************************************************
		public bool esIgual (IComparable x, IComparable y) {
			CPersona alumno1 = (CPersona) x;
			CPersona alumno2 = (CPersona) y;
			if (alumno1.getNombre ().CompareTo (alumno2.getNombre () ) == 0 ) {
				return true;
			}
			else {
				return false;
			}
		}
		public bool esMenor (IComparable x, IComparable y) {
			CPersona alumno1 = (CPersona) x;
			CPersona alumno2 = (CPersona) y;
			if (alumno1.getNombre ().CompareTo (alumno2.getNombre () ) == -1 ) {
				return true;
			}
			else {
				return false;
			}
		}
		public bool esMayor (IComparable x, IComparable y) {
			CPersona alumno1 = (CPersona) x;
			CPersona alumno2 = (CPersona) y;
			if (alumno1.getNombre ().CompareTo (alumno2.getNombre () ) == 1 ) {
				return true;
			}
			else {
				return false;
			}
		}
	}
}
