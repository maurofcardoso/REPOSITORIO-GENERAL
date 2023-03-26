using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CIteradorDiccionario :IIterador
	{
		private int elementoActual;
		private ArrayList listaDiccionarioIterador;
		private CDiccionario diccionarioOriginal;
		//*******************************************************************************************
		public CIteradorDiccionario(CDiccionario x)
		{
			this.listaDiccionarioIterador = new ArrayList ();
			this.diccionarioOriginal = x;
			int contenido = this.diccionarioOriginal.getListaDiccionario ().getListaConjunto ().Count;
			for (int y = 0; y < contenido;y++) {
				this.listaDiccionarioIterador.Add (this.diccionarioOriginal.getListaDiccionario ().getListaConjunto ()[y] );
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
			return elementoActual >= this.listaDiccionarioIterador.Count;
		}
		public IComparable actual () {
			return (IComparable) this.listaDiccionarioIterador [elementoActual];
		}
	}
}
