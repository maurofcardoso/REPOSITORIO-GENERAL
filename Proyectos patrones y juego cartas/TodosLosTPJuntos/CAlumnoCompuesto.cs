using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TodosLosTPJuntos
{
	public class CAlumnoCompuesto : IAlumno
	{
		private CPila listaAlumnos;
		//******************************************************************************************
		public CAlumnoCompuesto()
		{
			this.listaAlumnos = new CPila ();
		}
		//*******************************************************************************************
		public void agregarCompuesto (IAlumno x) {
			this.listaAlumnos.agregar (x);
		}
		public string getApellido () {
			return "";
		}
		public string getNombre () {
			IIterador iterador = this.listaAlumnos.crearIterador ();
			while (!iterador.fin () ) {
				IAlumno alumnoAuxiliar = (IAlumno) iterador.actual ();
				Console.WriteLine (alumnoAuxiliar.getApellido ().ToUpper () + " " + alumnoAuxiliar.getNombre ().ToUpper () );
				iterador.siguiente ();
			}
			return "FIN DE LOS ALUMNOS...";
		}
		public CNumero getDni () {
			return new CNumero (0);
		}
		public CNumero getLegajo () {
			return new CNumero (0);
		}
		public CNumero getPromedio () {
			return new CNumero (0);
		}
		public int responderPregunta (int pregunta) {
			int opcion0 = 0;
			int opcion1 = 0;
			int opcion2 = 0;
			int opcion3 = 0;
			IIterador iterador = this.listaAlumnos.crearIterador ();
			while (!iterador.fin () ) {
				IAlumno alumnoAuxiliar = (IAlumno) iterador.actual ();
				int respuesta = alumnoAuxiliar.responderPregunta (pregunta);
				switch (respuesta) {
					case 0:
						opcion0 = opcion0 + 1;
						break;
					case 1:
						opcion1 = opcion1 + 1;
						break;
					case 2:
						opcion2 = opcion2 + 1;
						break;
					case 3:
						opcion3 = opcion3 + 1;
						break;
				}
				iterador.siguiente ();
			}
			int [] numero = new int[] {opcion0, opcion1, opcion2, opcion3};
			int num = numero.Max ();
			return num;
		}
		public string mostrarCalificacion () {
			IIterador iterador = this.listaAlumnos.crearIterador ();
			while (!iterador.fin () ) {
				IAlumno alumnoAuxiliar = (IAlumno) iterador.actual ();
				alumnoAuxiliar.mostrarCalificacion ();
				iterador.siguiente ();
			}
			return "FIN DE LOS ALUMNOS...";
		}
		public double getCalificacion () {
			return 0;
		}
		public void setCalificacion (double calificacion) {
			IIterador iterador = this.listaAlumnos.crearIterador ();
			while (!iterador.fin () ) {
				IAlumno alumnoAuxiliar = (IAlumno) iterador.actual ();
				alumnoAuxiliar.setCalificacion (calificacion);
				iterador.siguiente ();
			}
		}
		public IComoComparar getComparar () {
			return new CComparaDni ();
		}
		public bool sosIgual (IComparable x) {
			IIterador iterador = this.listaAlumnos.crearIterador ();
			while (!iterador.fin () ) {
				IAlumno alumnoAuxiliar = (IAlumno) iterador.actual ();
				if (alumnoAuxiliar.sosIgual (x) ) {
					return true;
				}
				iterador.siguiente ();
			}
			return false;
		}
		public bool sosMenor (IComparable x) {
			IIterador iterador = this.listaAlumnos.crearIterador ();
			while (!iterador.fin () ) {
				IAlumno alumnoAuxiliar = (IAlumno) iterador.actual ();
				if (alumnoAuxiliar.sosMayor (x) | alumnoAuxiliar.sosMenor (x) ) {
					return true;
				}
				iterador.siguiente ();
			}
			return false;
		}
		public bool sosMayor (IComparable x) {
			IIterador iterador = this.listaAlumnos.crearIterador ();
			while (!iterador.fin () ) {
				IAlumno alumnoAuxiliar = (IAlumno) iterador.actual ();
				if (alumnoAuxiliar.sosIgual (x) | alumnoAuxiliar.sosMenor (x) ) {
					return false;
				}
				iterador.siguiente ();
			}
			return false;
		}
		public void setComparar (string tipo) {
			
		}
	}
}
