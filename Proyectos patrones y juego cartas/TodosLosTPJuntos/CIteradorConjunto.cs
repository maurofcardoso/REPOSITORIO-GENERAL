using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CIteradorConjunto : IIterador
	{
		private int elementoActual;
		private ArrayList listaConjuntoIterador;
		private CConjunto conjuntoOriginal;
		//******************************************************************************************
		public CIteradorConjunto(CConjunto x)
		{
			this.listaConjuntoIterador = new ArrayList ();
			this.conjuntoOriginal = x;
			foreach (IComparable y in this.conjuntoOriginal.getListaConjunto () ) {
				this.listaConjuntoIterador.Add (y);
			}
			primero ();
		}
		public void primero () {
			elementoActual = 0;
		}
		public void siguiente () {
			elementoActual = elementoActual + 1;
		}
		public bool fin () {
			return elementoActual >= this.listaConjuntoIterador.Count;
		}
		public IComparable actual () {
			return (IComparable) this.listaConjuntoIterador [elementoActual];
		}
	}
}
