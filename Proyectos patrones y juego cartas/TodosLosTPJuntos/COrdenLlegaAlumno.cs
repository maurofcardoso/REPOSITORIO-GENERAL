using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class COrdenLlegaAlumno : IOrdenEnAula2
	{
		private CAula aula;
		//****************************************************************************************
		public COrdenLlegaAlumno(CAula aula)
		{
			this.aula = aula;
		}
		//****************************************************************************************
		public void ejecutar (IComparable x) {
			IAlumno alumno = (IAlumno) x;
			this.aula.nuevoAlumno (alumno);
		}
	}
}
