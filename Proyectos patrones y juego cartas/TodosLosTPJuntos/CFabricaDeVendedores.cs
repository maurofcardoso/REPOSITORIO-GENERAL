using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CFabricaDeVendedores : CFabricaDeComparables
	{
		public CFabricaDeVendedores()
		{
		}
		//*****************************************************************************************
		public override IComparable crearAleatorio () {
			CGeneradorDeDatosAleatorios auxiliar = new CGeneradorDeDatosAleatorios ();
			return new CVendedor (auxiliar.stringAleatorio (10), auxiliar.stringAleatorio (10), (CNumero) auxiliar.numeroAleatorio (8), (CNumero) auxiliar.numeroAleatorio (6) );
		}
		public override IComparable crearPorTeclado () {
			CLectorDeDatos auxiliar = new CLectorDeDatos ();
			return new CVendedor (auxiliar.stringPorTeclado (), auxiliar.stringPorTeclado (), (CNumero) auxiliar.numeroPorTeclado (), (CNumero) auxiliar.numeroPorTeclado () );
		}
	}
}
