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
		public static int empezarJuego (string opcion) {
			CJuegoCartas juego = null;
			if (opcion == "truco") {
				juego = new CJuegoTruco ();
			}
			juego.mezclarElMazo ();
			juego.repartirCartas ();
			juego.jugarMano ();
			return juego.chequearGanador ();
		}
		public abstract void mezclarElMazo ();
		public abstract void repartirCartas ();
		public abstract void jugarMano ();
		public abstract int chequearGanador ();
	}
}
