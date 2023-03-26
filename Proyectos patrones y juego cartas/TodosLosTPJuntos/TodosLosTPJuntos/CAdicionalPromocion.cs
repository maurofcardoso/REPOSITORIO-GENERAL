using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CAdicionalPromocion : CAdicionalDecorado
	{
		public CAdicionalPromocion(IAlumno alumno) : base (alumno)
		{
		}
		//*******************************************************************************************
		public override string mostrarCalificacion () {
			if (base.getCalificacion () >= 7) {
				return base.mostrarCalificacion () + " " + "(PROMOCION)";
			}
			if (base.getCalificacion () < 7 & base.getCalificacion () >= 4) {
				return base.mostrarCalificacion () + " " + "(APROBADO)";
			}
			if (base.getCalificacion () < 4) {
				return base.mostrarCalificacion () + " " + "(DESAPROBADO)";
			}
			return "";
		}
	}
}
