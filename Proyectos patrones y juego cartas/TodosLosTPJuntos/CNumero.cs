using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CNumero : IComparable
	{
		private int valor;
		private IComoComparar comparar;
		//***********************************************************************************************
		public CNumero(int valor)
		{
			this.valor = valor;
			this.comparar = new CComparaNumero ();
		}
		//***********************************************************************************************
		public int getValor () {
			return this.valor;
		}
		public bool sosIgual (IComparable x) {
			CNumero numero = (CNumero) x;
			return comparar.esIgual (this, numero);
		}
		public bool sosMenor (IComparable x) {
			CNumero numero = (CNumero) x;
			return comparar.esMenor (this, numero);
		}
		public bool sosMayor (IComparable x) {
			CNumero numero = (CNumero) x;
			return comparar.esMayor (this, numero);
		}
		public override string ToString()
		{
			return string.Format("{0}", valor);
		}
		public void setComparar (string tipo) {
			switch (tipo) {
				case "VALOR":
					this.comparar = new CComparaNumero ();
					break;
			}
		}

	}
}
