using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CVendedor : CPersona, IObservado
	{
		private CNumero sueldoBasico;
		private double bonus;
		private IComoComparar comparar;
		private double monto;
		private ArrayList listaObservadores;
		//*****************************************************************************************
		public CVendedor(string nombre, string apellido, CNumero dni, CNumero sueldoBasico) : base (nombre, apellido, dni)
		{
			this.sueldoBasico = sueldoBasico;
			this.bonus = 1;
			this.comparar = new CComparaBonus ();
			this.listaObservadores = new ArrayList ();
		}
		//******************************************************************************************
		public void setMonto (double monto) {
			this.monto = monto;
		}
		public double getMonto () {
			return this.monto;
		}
		public double getBonus () {
			return this.bonus;
		}
		public void venta (double monto) {
			this.monto = monto;
			this.notificarObservador ();
		}
		public void aumentaBonus () {
			bonus = bonus * 1.01;
		}
		public override bool sosIgual (IComparable x) {
			CVendedor auxiliar = (CVendedor) x;
			return comparar.esIgual (this, auxiliar);
		}
		public override bool sosMenor (IComparable x) {
			CVendedor auxiliar = (CVendedor) x;
			return comparar.esMenor (this, auxiliar);
		}
		public override bool sosMayor (IComparable x) {
			CVendedor auxiliar = (CVendedor) x;
			return comparar.esMayor (this, auxiliar);
		}
		public override void setComparar (string tipo) {
			switch (tipo) {
				case "PROMEDIO":
					this.comparar = new CComparaPromedio ();
					break;
				case "LEGAJO":
					this.comparar = new CComparaLegajo ();
					break;
				case "DNI":
					this.comparar = new CComparaDni ();
					break;
				case "NOMBRE":
					this.comparar = new CComparaNombre ();
					break;
				case "APELLIDO":
					this.comparar = new CComparaApellido ();
					break;
				case "BONUS":
					this.comparar = new CComparaBonus ();
					break;
			}
		}
		public void agregarObservador (IObservador o) {
			this.listaObservadores.Add (o);
			this.notificarObservador ();
		}
		public void quitarObservador (IObservador o) {
			this.listaObservadores.Remove (o);
			this.notificarObservador ();
		}
		public void notificarObservador () {
			foreach (IObservador x in this.listaObservadores) {
				x.actualizar (this);
			}
		}
		public override string ToString()
		{
			return string.Format("SueldoBasico = {0}, Bonus = {1}, Monto={2}", sueldoBasico, bonus, monto);
		}


	}
}
