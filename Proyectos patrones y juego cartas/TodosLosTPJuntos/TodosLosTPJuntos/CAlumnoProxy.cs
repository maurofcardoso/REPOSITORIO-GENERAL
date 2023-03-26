using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CAlumnoProxy : IAlumno
	{
		private string apellido;
		private string nombre;
		private CNumero dni;
		private CNumero legajo;
		private CNumero promedio;
		private IComoComparar comparar;
		private double calificacion;
		private IAlumno alumnoReal;
		//*****************************************************************************************
		public CAlumnoProxy()
		{
			this.comparar = new CComparaDni ();
			this.alumnoReal = null;
			this.apellido = "proxy";
			this.nombre = "proxy";
			this.dni = new CNumero (9999);
			this.legajo = new CNumero (9999);
			this.promedio = new CNumero (9999);
			this.calificacion = 9999;
		}
		//*******************************************************************************************
		public string getApellido () {
			return this.apellido;
		}
		public void setApellido (string apellido) {
			this.apellido = apellido;
		}
		public string getNombre () {
			return this.nombre;
		}
		public void setNombre (string nombre) {
			this.nombre = nombre;
		}
		public CNumero getDni () {
			return this.dni;
		}
		public void setDni(CNumero dni) {
			this.dni = dni;
		}
		public double getCalificacion () {
			return this.calificacion;
		}
		public void setCalificacion (double calificacion) {
			this.calificacion = calificacion;
		}
		public void setComparar (string tipo) {
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
		public void setLegajo (CNumero legajo) {
			this.legajo = legajo;
		}
		public CNumero getPromedio () {
			return this.promedio;
		}
		public void setPromedio (CNumero promedio) {
			this.promedio = promedio;
		}
		public bool sosIgual (IComparable x) {
			IAlumno alumnoAuxiliar = (IAlumno) x;
			return comparar.esIgual (this, alumnoAuxiliar);
		}
		public bool sosMenor (IComparable x) {
			IAlumno alumnoAuxiliar = (IAlumno) x;
			return comparar.esMenor (this, alumnoAuxiliar);
		}
		public bool sosMayor (IComparable x) {
			IAlumno alumnoAuxiliar = (IAlumno) x;
			return comparar.esMayor(this, alumnoAuxiliar);
		}
		public virtual int responderPregunta (int pregunta) {
			if (this.alumnoReal == null) {
				alumnoReal = (IAlumno) CFabricaDeAlumnos.crearAleatorio ("ALUMNOMUYESTUDIOSO");
			}
			this.apellido = alumnoReal.getApellido ();
			this.nombre = alumnoReal.getNombre ();
			this.legajo = alumnoReal.getLegajo ();
			this.promedio = alumnoReal.getPromedio ();
			this.dni = alumnoReal.getDni ();
			this.calificacion = alumnoReal.getCalificacion ();
			this.comparar = alumnoReal.getComparar ();
			return this.alumnoReal.responderPregunta (pregunta);
		}
		public string mostrarCalificacion () {
			string cadena = this.apellido + " " + this.nombre + "    " + "CALIFICACION" + " " + this.getCalificacion ();
			return cadena;
		}
		public IComoComparar getComparar () {
			return this.comparar;
		}
	}
}
