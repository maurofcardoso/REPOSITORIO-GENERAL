using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CConjunto : IColeccionable, IIterable, IOrdenable
	{
		private ArrayList listaConjunto;
		private IOrdenEnAula1 ordenInicio, ordenAulaLlena;
		private IOrdenEnAula2 ordenLlegaAlumno;
		//********************************************************************************************
		public CConjunto()
		{
			this.listaConjunto = new ArrayList ();
		}
		//*********************************************************************************************
		public ArrayList getListaConjunto () {
			return this.listaConjunto;
		}
		public IComparable valorAsociado (IComparable x) {
			IComparable auxiliar = null;
			foreach (CObjetoClaveValor y in this.listaConjunto) {
				if (y.getClave ().sosIgual (x) ) {
					auxiliar = y.getValor ();
				}
			}
			return auxiliar;
		}
		public void setValor (CObjetoClaveValor x) {
			for (int y = 0; y < this.listaConjunto.Count; y++) {
				CObjetoClaveValor auxiliar = (CObjetoClaveValor) this.listaConjunto [y];
				if (auxiliar.getClave ().sosIgual (x) ) {
					this.listaConjunto [y] = x;
				}
			}
		}
		public void agregarElemento (IComparable x) {
			if (!pertenece (x) ) {
				this.listaConjunto.Add (x);
			}
		}
		public bool pertenece (IComparable x) {
			foreach (IComparable y in this.listaConjunto) {
				if (y.sosIgual (x)) {
					return true;
				}
			}
			return false;
		}
		public int cuantos () {
			return this.listaConjunto.Count;
		}
		public IComparable minimo () {
			IComparable minimo1 = (IComparable) this.listaConjunto [0];
			foreach (IComparable x in this.listaConjunto) {
				if (x.sosMenor (minimo1) ) {
					minimo1 = x;
				}
			}
			return minimo1;
		}
		public IComparable maximo () {
			IComparable maximo1 = (IComparable) this.listaConjunto [0];
			foreach (IComparable x in this.listaConjunto) {
				if (x.sosMenor (maximo1) ) {
					maximo1 = x;
				}
			}
			return maximo1;
		}
		public void agregar (IComparable x) {
			if (this.listaConjunto.Count == 0) {
				if (ordenInicio != null) {
					ordenInicio.ejecutar ();
				}
			}
			if (ordenLlegaAlumno != null) {
				ordenLlegaAlumno.ejecutar (x);
			}
			if (this.listaConjunto.Count == 39) {
				if (ordenAulaLlena != null) {
					ordenAulaLlena.ejecutar ();
				}
			}
			this.listaConjunto.Add (new CObjetoClaveValor (new CNumero (1000), x) );
		}
		public bool contiene (IComparable x) {
			foreach (CObjetoClaveValor y in this.listaConjunto) {
				if (y.getValor ().sosIgual (x) ) {
					return true;
				}
			}
			return false;
		}
		public IIterador crearIterador () {
			return new CIteradorConjunto (this);
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
