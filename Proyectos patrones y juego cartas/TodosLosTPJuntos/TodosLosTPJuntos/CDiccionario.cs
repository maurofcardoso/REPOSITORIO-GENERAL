using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CDiccionario : IIterable, IColeccionable, IOrdenable
	{
		private CConjunto listaDiccionario;
		private IOrdenEnAula1 ordenInicio, ordenAulaLlena;
		private IOrdenEnAula2 ordenLlegaAlumno;
		//****************************************************************************************
		public CDiccionario()
		{
			this.listaDiccionario = new CConjunto ();
		}
		//****************************************************************************************
		public CConjunto getListaDiccionario () {
			return this.listaDiccionario;
		}
		public void agregar1 (CNumero clave, IComparable valor) {
			if (!this.listaDiccionario.pertenece (clave) ) {
				this.listaDiccionario.agregarElemento (new CObjetoClaveValor (clave, valor) );
			}
			else {
				this.listaDiccionario.setValor (new CObjetoClaveValor (clave, valor) );
			}
		}
		public IComparable valorDe (CNumero clave) {
			return this.listaDiccionario.valorAsociado (clave);
		}
		public int cuantos () {
			return this.listaDiccionario.cuantos ();
		}
		public IComparable minimo () {
			CObjetoClaveValor minimo1 = (CObjetoClaveValor) this.listaDiccionario.getListaConjunto () [0];
			foreach (CObjetoClaveValor x in this.listaDiccionario.getListaConjunto () ) {
				if (x.getValor ().sosMenor (minimo1.getValor () ) ) {
					minimo1 = x;
				}
			}
			return minimo1;
		}
		public IComparable maximo () {
			CObjetoClaveValor maximo1 = (CObjetoClaveValor) this.listaDiccionario.getListaConjunto () [0];
			foreach (CObjetoClaveValor x in this.listaDiccionario.getListaConjunto () ) {
				if (x.getValor ().sosMayor (maximo1.getValor () ) ) {
					maximo1 = x;
				}
			}
			return maximo1;
		}
		public void agregar (IComparable x) {
			if (this.listaDiccionario.getListaConjunto ().Count == 0) {
				if (ordenInicio != null) {
					ordenInicio.ejecutar ();
				}
			}
			if (ordenLlegaAlumno != null) {
				ordenLlegaAlumno.ejecutar (x);
			}
			if (this.listaDiccionario.getListaConjunto ().Count == 39) {
				if (ordenAulaLlena != null) {
					ordenAulaLlena.ejecutar ();
				}
			}
			this.listaDiccionario.getListaConjunto ().Add (new CObjetoClaveValor (new CNumero (2000), x) );
		}
		public bool contiene (IComparable x) {
			for (int y = 0; y < this.listaDiccionario.cuantos (); y++) {
				CObjetoClaveValor auxiliar = (CObjetoClaveValor) this.listaDiccionario.getListaConjunto () [y];
				if (auxiliar.getValor ().sosIgual (x) ) {
					return true;
				}
			}
			return false;
		}
		public IIterador crearIterador () {
			return new CIteradorDiccionario (this);
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
