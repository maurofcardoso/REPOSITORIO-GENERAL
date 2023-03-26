using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public abstract class CJuegoCartas
	{
		//*******************************************************************************************
		public CJuegoCartas()
		{
		}
		//********************************************************************************************
		public int empezarJuego () {
			mezclarElMazo ();
			repartirCartas ();
			jugarMano ();
			return chequearGanador ();
		}
		public abstract void mezclarElMazo ();
		public abstract void repartirCartas ();
		public abstract void jugarMano ();
		public abstract int chequearGanador ();
	}
}
