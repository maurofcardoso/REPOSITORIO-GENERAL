using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CComparaNumero : IComoComparar
	{
		public CComparaNumero()
		{
		}
		public bool esIgual (IComparable x, IComparable y) {
			CNumero numero1 = (CNumero) x;
			CNumero numero2 = (CNumero) y;
			if (numero1.getValor () == numero2.getValor () ) {
				return true;
			}
			else {
				return false;
			}
		}
		public bool esMenor (IComparable x, IComparable y) {
			CNumero numero1 = (CNumero) x;
			CNumero numero2 = (CNumero) y;
			if (numero1.getValor () < numero2.getValor () ) {
				return true;
			}
			else {
				return false;
			}
		}
		public bool esMayor (IComparable x, IComparable y) {
			CNumero numero1 = (CNumero) x;
			CNumero numero2 = (CNumero) y;
			if (numero1.getValor () > numero2.getValor () ) {
				return true;
			}
			else {
				return false;
			}
		}
	}
}
