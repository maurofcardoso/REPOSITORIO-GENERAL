using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public interface IOrdenable
	{
		void setOrdenInicio (IOrdenEnAula1 x);
		void setOrdenLlegaAlumno (IOrdenEnAula2 x);
		void setOrdenAulaLlena (IOrdenEnAula1 x);
	}
}
