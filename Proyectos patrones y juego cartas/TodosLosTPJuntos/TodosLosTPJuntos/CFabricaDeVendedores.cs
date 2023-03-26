using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CFabricaDeVendedores : CFabricaDeComparables
	{
		CManejadorDeDatos manejador;
		//****************************************************************************************
		public CFabricaDeVendedores()
		{
			CManejadorDeDatos auxiliar = CGeneradorDeDatosAleatorios.getInstancia (null);
			CManejadorDeDatos auxiliar2 = new LectorDeArchivos (auxiliar);
			this.manejador = CLectorDeDatos.getInstancia (auxiliar2);
		}
		//*****************************************************************************************
		public override IComparable crearAleatorio () {
			return new CVendedor (manejador.stringAleatorio (10), manejador.stringAleatorio (10), (CNumero) manejador.numeroAleatorio (8), (CNumero) manejador.numeroAleatorio (6) );
		}
		public override IComparable crearPorTeclado () {
			return new CVendedor (manejador.stringPorTeclado (), manejador.stringPorTeclado (), (CNumero) manejador.numeroPorTeclado (), (CNumero) manejador.numeroPorTeclado () );
		}
		public override IComparable crearDesdeArchivo () {
			return new CVendedor (manejador.stringDesdeArchivo (10), manejador.stringDesdeArchivo (10), (CNumero) manejador.numeroDesdeArchivo (8), (CNumero) manejador.numeroDesdeArchivo (6) );
		}
	}
}
