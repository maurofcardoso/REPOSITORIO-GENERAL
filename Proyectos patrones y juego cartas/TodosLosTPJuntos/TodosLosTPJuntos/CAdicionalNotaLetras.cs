using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CAdicionalNotaLetras :CAdicionalDecorado
	{
		public CAdicionalNotaLetras(IAlumno alumno) : base (alumno)
		{
		}
		//*****************************************************************************************
		public override string mostrarCalificacion () {
			return base.mostrarCalificacion () + " " + this.notaEnLetras (base.getCalificacion () );
		}
		public string notaEnLetras (double calificacion) {
			int nota = (int) calificacion;
			string auxiliar = "";
			switch (nota) {
				case 0:
					auxiliar = "(cero)";
					break;
				case 1:
					auxiliar = "(uno)";
					break;
				case 2:
					auxiliar = "(dos)";
					break;
				case 3:
					auxiliar = "(tres)";
					break;
				case 4:
					auxiliar = "(cuatro)";
					break;
				case 5:
					auxiliar = "(cinco)";
					break;
				case 6:
					auxiliar = "(seis)";
					break;
				case 7:
					auxiliar = "(siete)";
					break;
				case 8:
					auxiliar = "(ocho)";
					break;
				case 9:
					auxiliar = "(nueve)";
					break;
				case 10:
					auxiliar = "(diez)";
					break;
			}
			return auxiliar;
		}
	}
}
