using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CComparaClave : IComoComparar
	{
		public CComparaClave()
		{
		}
		public bool esIgual (IComparable x, IComparable y) {
			CObjetoClaveValor objetoClaveValor1 = (CObjetoClaveValor) x;
			CObjetoClaveValor objetoClaveValor2 = (CObjetoClaveValor) y;
			if (objetoClaveValor1.getClave ().sosIgual (objetoClaveValor2.getClave () ) ) {
				return true;
			}
			else {
				return false;
			}
		}
		public bool esMenor (IComparable x, IComparable y) {
			CObjetoClaveValor objetoClaveValor1 = (CObjetoClaveValor) x;
			CObjetoClaveValor objetoClaveValor2 = (CObjetoClaveValor) y;
			if (objetoClaveValor1.getClave ().sosMenor (objetoClaveValor2.getClave () ) ) {
				return true;
			}
			else {
				return false;
			}
		}
		public bool esMayor (IComparable x, IComparable y) {
			CObjetoClaveValor objetoClaveValor1 = (CObjetoClaveValor) x;
			CObjetoClaveValor objetoClaveValor2 = (CObjetoClaveValor) y;
			if (objetoClaveValor1.getClave ().sosMayor (objetoClaveValor2.getClave () ) ) {
				return true;
			}
			else {
				return false;
			}
		}
	}
}
