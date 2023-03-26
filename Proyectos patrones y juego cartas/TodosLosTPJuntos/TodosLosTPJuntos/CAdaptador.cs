using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CAdaptador : Student
	{
		private IAlumno alumnoAdaptador;
		//*******************************************************************************************
		public CAdaptador(IAlumno alumno)
		{
			this.alumnoAdaptador = alumno;
		}
		//*******************************************************************************************
		public IAlumno getAlumnoAdaptador () {
			return this.alumnoAdaptador;
		}
		public string getName() {
			return this.alumnoAdaptador.getNombre ();
		}
		public int yourAnswerIs(int question) {
			return this.alumnoAdaptador.responderPregunta (question);
		}
		public void setScore(int score) {
			this.alumnoAdaptador.setCalificacion (score);
		}
		public string showResult() {
			return this.alumnoAdaptador.mostrarCalificacion ();
		}
		public bool equals(Student student) {
			CAdaptador alumnoAuxiliar = (CAdaptador) student;
			return this.alumnoAdaptador.sosIgual (alumnoAuxiliar.getAlumnoAdaptador () );
		}
		public bool lessThan(Student student) {
			CAdaptador alumnoAuxiliar = (CAdaptador) student;
			return this.alumnoAdaptador.sosMenor (alumnoAuxiliar.getAlumnoAdaptador () );
		}
		public bool greaterThan(Student student) {
			CAdaptador alumnoAuxiliar = (CAdaptador) student;
			return this.alumnoAdaptador.sosMayor (alumnoAuxiliar.getAlumnoAdaptador () );
		}
		public void setComparar (string tipo) {
			
		}
	}
}
