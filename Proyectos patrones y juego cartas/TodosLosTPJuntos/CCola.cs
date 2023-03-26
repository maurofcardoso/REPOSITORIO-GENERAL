using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CCola : IColeccionable, IIterable, IOrdenable
	{
		private Queue listaCola;
		private IOrdenEnAula1 ordenInicio, ordenAulaLlena;
		private IOrdenEnAula2 ordenLlegaAlumno;
		//*********************************************************************************************
		public CCola()
		{
			this.listaCola = new Queue ();
		}
		//*********************************************************************************************
		public Queue getListaCola () {
			return this.listaCola;
		}
		public int cuantos () {
			return this.listaCola.Count;
		}
		public IComparable minimo () {
			Queue listaColaAuxiliar = new Queue ();
			IComparable minimo1 = (IComparable) this.listaCola.Peek ();
			int contenido = this.listaCola.Count;
			for (int x = 0; x < contenido; x++) {
				IComparable auxiliar = (IComparable) this.listaCola.Dequeue ();
				if (auxiliar.sosMenor (minimo1) ) {
					minimo1 = auxiliar;
				}
				listaColaAuxiliar.Enqueue (auxiliar);
			}
			for (int x = 0; x < contenido; x++) {
				this.listaCola.Enqueue (listaColaAuxiliar.Dequeue () );
			}
			return minimo1;
		}
		public IComparable maximo () {
			Queue listaColaAuxiliar = new Queue ();
			IComparable maximo1 = (IComparable) this.listaCola.Peek ();
			int contenido = this.listaCola.Count;
			for (int x = 0; x < contenido; x++) {
				IComparable auxiliar = (IComparable) this.listaCola.Dequeue ();
				if (auxiliar.sosMayor (maximo1) ) {
					maximo1 = auxiliar;
				}
				listaColaAuxiliar.Enqueue (auxiliar);
			}
			for (int x = 0; x < contenido; x++) {
				this.listaCola.Enqueue (listaColaAuxiliar.Dequeue () );
			}
			return maximo1;
		}
		public void agregar (IComparable x) {
			if (this.listaCola.Count == 0) {
				if (ordenInicio != null) {
					ordenInicio.ejecutar ();
				}
			}
			if (ordenLlegaAlumno != null) {
				ordenLlegaAlumno.ejecutar (x);
			}
			if (this.listaCola.Count == 39) {
				if (ordenAulaLlena != null) {
					ordenAulaLlena.ejecutar ();
				}
			}
			this.listaCola.Enqueue (x);
		}
		public bool contiene (IComparable x) {
			Queue listaColaAuxiliar = new Queue ();
			bool respuesta = false;
			int contenido = this.listaCola.Count;
			for (int y = 0; y < contenido; y++) {
				IComparable auxiliar = (IComparable) this.listaCola.Dequeue ();
				if (auxiliar.sosIgual ((IComparable) x) ) {
					respuesta = true;
				}
				listaColaAuxiliar.Enqueue (auxiliar);
			}
			for (int y = 0; y < contenido; y++) {
				this.listaCola.Enqueue (listaColaAuxiliar.Dequeue () );
			}
			return respuesta;
		}
		public IIterador crearIterador () {
			return new CIteradorCola (this);
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
