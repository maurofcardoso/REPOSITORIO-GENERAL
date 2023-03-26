using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CFabricaDeNumeros : CFabricaDeComparables
	{
		public CFabricaDeNumeros()
		{
		}
		//*****************************************************************************************
		public override IComparable crearAleatorio () {
			CGeneradorDeDatosAleatorios auxiliar = new CGeneradorDeDatosAleatorios ();
			return auxiliar.numeroAleatorio (13);
		}
		public override IComparable crearPorTeclado () {
			CLectorDeDatos auxiliar = new CLectorDeDatos ();
			return auxiliar.numeroPorTeclado ();
		}
	}
}
