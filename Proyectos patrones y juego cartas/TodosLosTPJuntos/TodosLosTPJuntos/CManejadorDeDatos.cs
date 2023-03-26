using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TodosLosTPJuntos
{
	public abstract class CManejadorDeDatos : IObtencionDeDatos
	{
		IObtencionDeDatos sucesor;
		//*******************************************************************************************
		public CManejadorDeDatos(IObtencionDeDatos sucesor)
		{
			this.sucesor = sucesor;
		}
		public virtual IComparable numeroAleatorio (int max) {
			return this.sucesor.numeroAleatorio (max);
		}
		public virtual string stringAleatorio (int cant) {
			return this.sucesor.stringAleatorio (cant);
		}
		public virtual IComparable numeroPorTeclado () {
			return this.sucesor.numeroPorTeclado ();
		}
		public virtual string stringPorTeclado () {
			return this.sucesor.stringPorTeclado ();
		}
		public virtual IComparable numeroDesdeArchivo(int max) {
			return this.sucesor.numeroDesdeArchivo (max);
		}
		public virtual string stringDesdeArchivo(int cant) {
			return this.sucesor.stringDesdeArchivo (cant);
		}
	}
}
