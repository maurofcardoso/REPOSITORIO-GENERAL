using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CAula
	{
		private Teacher profesor;
		//*******************************************************************************************
		public CAula()
		{
		}
		//******************************************************************************************
		public void comenzar () {
			Console.WriteLine ("VAMOS A COMENZAR LA CLASE!!");
			this.profesor = new Teacher ();
		}
		public void nuevoAlumno (IAlumno alumno) {
			CAdaptador auxiliar = new CAdaptador (alumno);
			profesor.goToClass (auxiliar);
		}
		public void claseLista () {
			profesor.teachingAClass ();
		}
	}
}
