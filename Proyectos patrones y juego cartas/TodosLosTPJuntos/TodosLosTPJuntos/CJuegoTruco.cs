using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CJuegoTruco : CJuegoCartas
	{
		int contador1, contador2;
		private ArrayList jugador1;
		private ArrayList jugador2;
		//*****************************************************************************************
		public CJuegoTruco()
		{
			this.contador1 = 0;
			this.contador2 = 0;
			this.jugador1 = new ArrayList ();
			this.jugador2 = new ArrayList ();
		}
		//*****************************************************************************************
		public override void mezclarElMazo () {
			Console.WriteLine ("MEZCLANDO LAS CARTAS...");
		}
		public override void repartirCartas () {
			for (int x = 0; x < 5; x++) {
				CNumero cartaNumeroJugador1 = (CNumero) CFabricaDeComparables.crearAleatorio ("NUMERO");
				jugador1.Add (cartaNumeroJugador1);
				Console.WriteLine (jugador1.Count);
			}
			for (int x = 0; x < 5; x++) {
				CNumero cartaNumeroJugador2 = (CNumero) CFabricaDeComparables.crearAleatorio ("NUMERO");
				jugador2.Add (cartaNumeroJugador2);
				Console.WriteLine (jugador2.Count);
			}
		}
		public override void jugarMano () {
			Console.WriteLine (jugador2.Count);
			for (int x = 0; x < 5; x++) {
				int cartaJugador1 = descartarCarta (jugador1, x).getValor ();
				int cartajugador2 = descartarCarta (jugador2, x).getValor ();
				if (cartaJugador1 > cartajugador2) {
					this.contador1 = this.contador1 + 1;
				}
				else {
					this.contador2 = this.contador2 + 1;
				}
			}
		}
		public override int chequearGanador () {
			if (this.contador1 > this.contador2) {
				return 1;
			}
			else {
				return 2;
			}
		}
		public void tomarCarta () {
			
		}
		public CNumero descartarCarta (ArrayList jugador, int mano) {
			return (CNumero) jugador [mano];
		}
	}
}
