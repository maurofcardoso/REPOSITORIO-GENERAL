using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CIteradorCola : IIterador
	{
		private int elementoActual;
		private ArrayList listaColaIterador;
		private CCola colaOriginal;
		//******************************************************************************************
		public CIteradorCola(CCola x)
		{
			this.listaColaIterador = new ArrayList ();
			this.colaOriginal = x;
			Queue colaAuxiliar = new Queue ();
			int contenido = this.colaOriginal.cuantos ();
			for (int y = 0; y < contenido; y++) {
				IComparable auxiliar = (IComparable) this.colaOriginal.getListaCola ().Dequeue ();
				this.listaColaIterador.Add (auxiliar);
				colaAuxiliar.Enqueue (auxiliar);
			}
			for (int y = 0; y < contenido; y++) {
				this.colaOriginal.getListaCola ().Enqueue (colaAuxiliar.Dequeue () );
			}
			primero ();
		}
		//******************************************************************************************
		public void primero () {
			elementoActual = 0;
		}
		public void siguiente () {
			elementoActual = elementoActual + 1;
		}
		public bool fin () {
			return elementoActual >= this.listaColaIterador.Count;
		}
		public IComparable actual () {
			return (IComparable) this.listaColaIterador [elementoActual];
		}
	}
}
