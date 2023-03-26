using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CObjetoClaveValor : IComparable
	{
		private CNumero clave;
		private IComparable valor;
		private IComoComparar comparar;
		//********************************************************************************************
		public CObjetoClaveValor(CNumero clave, IComparable valor)
		{
			this.clave = clave;
			this.valor = valor;
			this.comparar = new CComparaClave ();
		}
		//********************************************************************************************
		public void setComparar (string tipo) {
			switch (tipo) {
				case "CLAVE":
					this.comparar = new CComparaClave ();
					break;
			}
		}
		public CNumero getClave () {
			return this.clave;
		}
		public IComparable getValor () {
			return this.valor;
		}
		public bool sosIgual (IComparable x) {
			CObjetoClaveValor objetoClaveValor = (CObjetoClaveValor) x;
			return comparar.esIgual (this, objetoClaveValor);
		}
		public bool sosMenor (IComparable x) {
			CObjetoClaveValor objetoClaveValor = (CObjetoClaveValor) x;
			return comparar.esMenor (this, objetoClaveValor);
		}
		public bool sosMayor (IComparable x) {
			CObjetoClaveValor objetoClaveValor = (CObjetoClaveValor) x;
			return comparar.esMayor (this, objetoClaveValor);
		}
		public override string ToString()
		{
			return string.Format("Clave = {0}, Valor = {1}", clave, valor);
		}

	}
}
