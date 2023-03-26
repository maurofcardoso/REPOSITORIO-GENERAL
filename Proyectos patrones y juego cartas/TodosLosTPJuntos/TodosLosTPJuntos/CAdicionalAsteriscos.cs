using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CAdicionalAsteriscos : CAdicionalDecorado
	{
		public CAdicionalAsteriscos(IAlumno alumno) : base (alumno)
		{
		}
		//****************************************************************************************
		public override string mostrarCalificacion () {
			return "*****************************************************************************************************************\n*\t" + base.mostrarCalificacion () + "\n*\t\t\n*****************************************************************************************************************";
		}
	}
}
