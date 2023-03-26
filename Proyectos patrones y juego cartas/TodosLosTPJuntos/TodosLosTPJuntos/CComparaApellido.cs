using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CComparaApellido : IComoComparar
	{
		public CComparaApellido()
		{
		}
		//********************************************************************************************
		public bool esIgual (IComparable x, IComparable y) {
			CPersona alumno1 = (CPersona) x;
			CPersona alumno2 = (CPersona) y;
			if (alumno1.getApellido ().CompareTo (alumno2.getApellido () ) == 0 ) {
				return true;
			}
			else {
				return false;
			}
		}
		public bool esMenor (IComparable x, IComparable y) {
			CPersona alumno1 = (CPersona) x;
			CPersona alumno2 = (CPersona) y;
			if (alumno1.getApellido ().CompareTo (alumno2.getApellido () ) == -1 ) {
				return true;
			}
			else {
				return false;
			}
		}
		public bool esMayor (IComparable x, IComparable y) {
			CPersona alumno1 = (CPersona) x;
			CPersona alumno2 = (CPersona) y;
			if (alumno1.getApellido ().CompareTo (alumno2.getApellido () ) == 1 ) {
				return true;
			}
			else {
				return false;
			}
		}
	}
}
