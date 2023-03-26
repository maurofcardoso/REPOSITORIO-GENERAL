using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class COrdenInicio : IOrdenEnAula1
	{
		private CAula aula;
		//******************************************************************************************
		public COrdenInicio(CAula aula)
		{
			this.aula = aula;
		}
		//******************************************************************************************
		public void ejecutar () {
			this.aula.comenzar ();
		}
	}
}
