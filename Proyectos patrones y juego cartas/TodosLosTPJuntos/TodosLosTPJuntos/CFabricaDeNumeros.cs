using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CFabricaDeNumeros : CFabricaDeComparables
	{
		CManejadorDeDatos manejador;
		//****************************************************************************************
		public CFabricaDeNumeros()
		{
			CManejadorDeDatos auxiliar = CGeneradorDeDatosAleatorios.getInstancia (null);
			CManejadorDeDatos auxiliar2 = new LectorDeArchivos (auxiliar);
			this.manejador = CLectorDeDatos.getInstancia (auxiliar2);
		}
		//*****************************************************************************************
		public override IComparable crearAleatorio () {
			return manejador.numeroAleatorio (13);
		}
		public override IComparable crearPorTeclado () {
			return manejador.numeroPorTeclado ();
		}
		public override IComparable crearDesdeArchivo () {
			return manejador.numeroDesdeArchivo (13);
		}
	}
}
