using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public abstract class CAdicionalDecorado : IAlumno
	{
		private IAlumno alumnoAdicionalDecorado;
		//****************************************************************************************
		public CAdicionalDecorado(IAlumno alumno)
		{
			this.alumnoAdicionalDecorado = alumno;
		}
		//****************************************************************************************
		public IComoComparar getComparar () {
			return this.alumnoAdicionalDecorado.getComparar ();
		}
		public string getApellido () {
			return this.alumnoAdicionalDecorado.getApellido ();
		}
		public string getNombre () {
			return this.alumnoAdicionalDecorado.getNombre ();
		}
		public CNumero getDni () {
			return this.alumnoAdicionalDecorado.getDni ();
		}
		public CNumero getLegajo () {
			return this.alumnoAdicionalDecorado.getLegajo ();
		}
		public CNumero getPromedio () {
			return this.alumnoAdicionalDecorado.getPromedio ();
		}
		public int responderPregunta (int pregunta) {
			return this.alumnoAdicionalDecorado.responderPregunta (pregunta);
		}
		public virtual string mostrarCalificacion () {
			return this.alumnoAdicionalDecorado.mostrarCalificacion ();
		}
		public double getCalificacion () {
			return this.alumnoAdicionalDecorado.getCalificacion ();
		}
		public void setCalificacion (double calificacion) {
			this.alumnoAdicionalDecorado.setCalificacion (calificacion);
		}
		public bool sosIgual (IComparable x) {
			return this.alumnoAdicionalDecorado.sosIgual (x);
		}
		public bool sosMenor (IComparable x) {
			return this.alumnoAdicionalDecorado.sosMenor (x);
		}
		public bool sosMayor (IComparable x) {
			return this.alumnoAdicionalDecorado.sosMayor (x);
		}
		public void setComparar (string tipo) {
			
		}
	}
}
