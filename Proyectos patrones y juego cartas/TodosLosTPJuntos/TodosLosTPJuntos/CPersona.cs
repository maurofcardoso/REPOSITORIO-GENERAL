using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CPersona : IComparable
	{
		private string nombre;
		private CNumero dni;
		private IComoComparar comparar;
		private string apellido;
		//*******************************************************************************************
		public CPersona(string nombre, string apellido, CNumero dni)
		{
			this.nombre = nombre;
			this.dni = dni;
			this.apellido = apellido;
			this.comparar = new CComparaNombre ();
		}
		//*******************************************************************************************
		public string getApellido () {
			return this.apellido.ToUpper ();
		}
		public string getNombre () {
			return this.nombre.ToUpper ();
		}
		public CNumero getDni () {
			return this.dni;
		}
		public virtual bool sosIgual (IComparable x) {
			CPersona personaAuxiliar = (CPersona) x;
			return comparar.esIgual (this, personaAuxiliar);
		}
		public virtual bool sosMenor (IComparable x) {
			CPersona personaAuxiliar = (CPersona) x;
			return comparar.esMenor (this, personaAuxiliar);
		}
		public virtual bool sosMayor (IComparable x) {
			CPersona personaAuxiliar = (CPersona) x;
			return comparar.esMayor (this, personaAuxiliar);
		}
		public virtual void setComparar (string tipo) {
			switch (tipo) {
				case "DNI":
					this.comparar = new CComparaDni ();
					break;
				case "NOMBRE":
					this.comparar = new CComparaNombre ();
					break;
				case "APELLIDO":
					this.comparar = new CComparaApellido ();
					break;
			}
		}
		public override string ToString()
		{
			return string.Format("Apellido = {0}, Nombre = {1}, Dni = {2}", this.apellido.ToUpper (), this.nombre.ToUpper (), this.dni);
		}


	}
}
