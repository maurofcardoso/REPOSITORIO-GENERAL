using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CColeccionMultiple : IColeccionable
	{
		private CPila pila;
		private CCola cola;
		//*******************************************************************************************
		public CColeccionMultiple(CPila pila, CCola cola)
		{
			this.pila = pila;
			this.cola = cola;
		}
		//*******************************************************************************************
		public int cuantos () {
			return this.pila.cuantos () + this.cola.cuantos ();
		}
		public IComparable minimo () {
			if (this.pila.minimo ().sosMenor (this.cola.minimo () ) ) {
				return this.pila.minimo ();
			}
			else {
				return this.cola.minimo ();
			}
		}
		public IComparable maximo () {
			if (this.pila.maximo ().sosMayor (this.cola.maximo () ) ) {
				return this.pila.maximo ();
			}
			else {
				return this.cola.maximo ();
			}
		}
		public void agregar (IComparable x) {
			
		}
		public bool contiene (IComparable x) {
			if (this.pila.contiene (x) | this.cola.contiene (x) ) {
				return true;
			}
			else {
				return false;
			}
		}
		public IIterador crearIterador () {
			return null;
		}
	}
}
