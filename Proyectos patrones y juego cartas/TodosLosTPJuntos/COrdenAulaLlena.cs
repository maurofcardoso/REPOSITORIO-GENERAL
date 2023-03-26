using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class COrdenAulaLlena : IOrdenEnAula1
	{
		private CAula aula;
		//******************************************************************************************
		public COrdenAulaLlena(CAula aula)
		{
			this.aula = aula;
		}
		//******************************************************************************************
		public void ejecutar () {
			this.aula.claseLista ();
		}
	}
}
