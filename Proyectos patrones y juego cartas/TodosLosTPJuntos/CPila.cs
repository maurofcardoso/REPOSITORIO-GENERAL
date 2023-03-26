using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CPila : IColeccionable, IIterable, IOrdenable
	{
		private Stack listaPila;
		private IOrdenEnAula1 ordenInicio, ordenAulaLlena;
		private IOrdenEnAula2 ordenLlegaAlumno;
		//********************************************************************************************
		public CPila()
		{
			this.listaPila = new Stack ();
			this.ordenInicio = null;
			this.ordenLlegaAlumno = null;
			this.ordenAulaLlena = null;
		}
		//********************************************************************************************
		public Stack getListaPila () {
			return this.listaPila;
		}
		public int cuantos () {
			return this.listaPila.Count;
		}
		public IComparable minimo () {
			Stack listaPilaAuxiliar = new Stack ();
			IComparable minimo1 = (IComparable) this.listaPila.Peek ();
			int contenido = this.listaPila.Count;
			for (int x = 0; x < contenido; x++) {
				IComparable auxiliar = (IComparable) this.listaPila.Pop ();
				if (auxiliar.sosMenor (minimo1) ) {
					minimo1 = auxiliar;
				}
				listaPilaAuxiliar.Push (auxiliar);
			}
			for (int x = 0; x < contenido; x++) {
				this.listaPila.Push (listaPilaAuxiliar.Pop () );
			}
			return minimo1;
		}
		public IComparable maximo () {
			Stack listaPilaAuxiliar = new Stack ();
			IComparable maximo1 = (IComparable) this.listaPila.Peek ();
			int contenido = this.listaPila.Count;
			for (int x = 0; x < contenido; x++) {
				IComparable auxiliar = (IComparable) this.listaPila.Pop ();
				if (auxiliar.sosMayor (maximo1) ) {
					maximo1 = auxiliar;
				}
				listaPilaAuxiliar.Push (auxiliar);
			}
			for (int x = 0; x < contenido; x++) {
				this.listaPila.Push (listaPilaAuxiliar.Pop () );
			}
			return maximo1;
		}
		public void agregar (IComparable x) {
			if (this.listaPila.Count == 0) {
				if (ordenInicio != null) {
					ordenInicio.ejecutar ();
				}
			}
			if (ordenLlegaAlumno != null) {
				ordenLlegaAlumno.ejecutar (x);
			}
			if (this.listaPila.Count == 39) {
				if (ordenAulaLlena != null) {
					ordenAulaLlena.ejecutar ();
				}
			}
			this.listaPila.Push (x);
		}
		public bool contiene (IComparable x) {
			Stack listaPilaAuxiliar = new Stack ();
			bool respuesta = false;
			int contenido = this.listaPila.Count;
			for (int y = 0; y < contenido; y++) {
				IComparable auxiliar = (IComparable) this.listaPila.Pop ();
				if (auxiliar.sosIgual ((IComparable) x) ) {
					respuesta = true;
				}
				listaPilaAuxiliar.Push (auxiliar);
			}
			for (int y = 0; y < contenido; y++) {
				this.listaPila.Push (listaPilaAuxiliar.Pop () );
			}
			return respuesta;
		}
		public IIterador crearIterador () {
			return new CIteradorPila (this);
		}
		public void setOrdenInicio (IOrdenEnAula1 x) {
			this.ordenInicio = x;
		}
		public void setOrdenLlegaAlumno (IOrdenEnAula2 x) {
			this.ordenLlegaAlumno = x;
		}
		public void setOrdenAulaLlena (IOrdenEnAula1 x) {
			this.ordenAulaLlena = x;
		}
	}
}
