using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public interface IObservado
	{
		void agregarObservador (IObservador o);
		void quitarObservador (IObservador o);
		void notificarObservador ();
	}
}
