using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CAlumnoMuyEstudioso : CAlumno
	{
		public CAlumnoMuyEstudioso(string nombre, string apellido, CNumero dni, CNumero legajo, CNumero promedio) : base (nombre, apellido, dni, legajo, promedio)
		{
		}
		//******************************************************************************************
		public override int responderPregunta (int pregunta) {
			return pregunta % 3;
		}
	}
}
