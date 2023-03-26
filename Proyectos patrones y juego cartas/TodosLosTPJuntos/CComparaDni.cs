using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CComparaDni :IComoComparar
	{
		public CComparaDni()
		{
		}
		//**********************************************************************************************
		public bool esIgual (IComparable x, IComparable y) {
			IAlumno alumno1 = (IAlumno) x;
			IAlumno alumno2 = (IAlumno) y;
			if (alumno1.getDni ().getValor () == alumno2.getDni ().getValor () ) {
				return true;
			}
			else {
				return false;
			}
		}
		public bool esMenor (IComparable x, IComparable y) {
			IAlumno alumno1 = (IAlumno) x;
			IAlumno alumno2 = (IAlumno) y;
			if (alumno1.getDni ().getValor () < alumno2.getDni ().getValor () ) {
				return true;
			}
			else {
				return false;
			}
		}
		public bool esMayor (IComparable x, IComparable y) {
			IAlumno alumno1 = (IAlumno) x;
			IAlumno alumno2 = (IAlumno) y;
			if (alumno1.getDni ().getValor () > alumno2.getDni ().getValor () ) {
				return true;
			}
			else {
				return false;
			}
		}
	}
}
