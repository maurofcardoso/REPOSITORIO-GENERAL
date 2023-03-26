using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CAdicionalLegajo : CAdicionalDecorado
	{
		public CAdicionalLegajo(IAlumno alumno) : base (alumno)
		{
		}
		//********************************************************************************************
		public override string mostrarCalificacion () {
			return base.mostrarCalificacion () + "    " +  "LEGAJO: (" + base.getLegajo () + ") ";
		}
	}
}
