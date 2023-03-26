using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public interface IObservador
	{
		void actualizar (IObservado o);
	}
}
