using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CIteradorPila : IIterador
	{
		private ArrayList ListaPilaIterador;
		private CPila pilaOriginal;
		private int elementoActual;
		//******************************************************************************************
		public CIteradorPila(CPila x)
		{
			this.ListaPilaIterador = new ArrayList ();
			this.pilaOriginal = x;
			Stack pilaAuxiliar = new Stack ();
			int contenido = this.pilaOriginal.cuantos ();
			for (int y = 0; y < contenido; y++) {
				IComparable auxiliar = (IComparable) this.pilaOriginal.getListaPila ().Pop ();
				this.ListaPilaIterador.Add (auxiliar);
				pilaAuxiliar.Push (auxiliar);
			}
			for (int y = 0; y < contenido; y++) {
				this.pilaOriginal.getListaPila ().Push (pilaAuxiliar.Pop () );
			}
			primero ();
		}
		//*******************************************************************************************
		public void primero () {
			elementoActual = 0;
		}
		public void siguiente () {
			elementoActual = elementoActual + 1;
		}
		public bool fin () {
			return elementoActual >= this.ListaPilaIterador.Count;
		}
		public IComparable actual () {
			return (IComparable) this.ListaPilaIterador [elementoActual];
		}
	}
}
