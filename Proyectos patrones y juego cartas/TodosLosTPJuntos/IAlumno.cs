using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public interface IAlumno : IComparable
	{
		string getApellido ();
		string getNombre ();
		CNumero getDni ();
		CNumero getLegajo ();
		CNumero getPromedio ();
		int responderPregunta (int pregunta);
		string mostrarCalificacion ();
		double getCalificacion ();
		void setCalificacion (double calificacion);
		IComoComparar getComparar ();
	}
}
