using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CAlumno : CPersona, IAlumno
	{
		private CNumero legajo;
		private CNumero promedio;
		private IComoComparar comparar;
		private double calificacion;
		//*********************************************************************************************
		public CAlumno(string nombre, string apellido, CNumero dni, CNumero legajo, CNumero promedio) : base (nombre, apellido, dni)
		{
			this.legajo = legajo;
			this.promedio = promedio;
			this.comparar = new CComparaDni ();
		}
		//*********************************************************************************************
		public IComoComparar getComparar () {
			return this.comparar;
		}
		public double getCalificacion () {
			return this.calificacion;
		}
		public void setCalificacion (double calificacion) {
			this.calificacion = calificacion;
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
			}
		}
		public CNumero getLegajo () {
			return this.legajo;
		}
		public CNumero getPromedio () {
			return this.promedio;
		}
		public override bool sosIgual (IComparable x) {
			IAlumno alumnoAuxiliar = (IAlumno) x;
			return comparar.esIgual (this, alumnoAuxiliar);
		}
		public override bool sosMenor (IComparable x) {
			IAlumno alumnoAuxiliar = (IAlumno) x;
			return comparar.esMenor (this, alumnoAuxiliar);
		}
		public override bool sosMayor (IComparable x) {
			IAlumno alumnoAuxiliar = (IAlumno) x;
			return comparar.esMayor(this, alumnoAuxiliar);
		}
		public virtual int responderPregunta (int pregunta) {
			CGeneradorDeDatosAleatorios auxiliar = CGeneradorDeDatosAleatorios.getInstancia (null);
			CNumero numeroAuxiliar = (CNumero) auxiliar.numeroAleatorio (4);
			return numeroAuxiliar.getValor ();
		}
		public string mostrarCalificacion () {
			string cadena = base.getApellido () + " " + base.getNombre () + "    " + "CALIFICACION" + " " + this.getCalificacion ();
			return cadena;
		}
		public override string ToString()
		{
			return string.Format(" {0}, {1}, DNI = {2}, LEGAJO = {3}, PROMEDIO = {4} ", base.getApellido (), base.getNombre(), base.getDni (), legajo, promedio);
		}

	}
}
