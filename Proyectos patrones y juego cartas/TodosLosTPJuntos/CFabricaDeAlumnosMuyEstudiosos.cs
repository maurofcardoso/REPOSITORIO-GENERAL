using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CFabricaDeAlumnosMuyEstudiosos :CFabricaDeComparables
	{
		public CFabricaDeAlumnosMuyEstudiosos()
		{
		}
		//**********************************************************************************************
		public override IComparable crearAleatorio () {
			CGeneradorDeDatosAleatorios auxiliar = new CGeneradorDeDatosAleatorios ();
			IAlumno alumno = new CAlumnoMuyEstudioso (auxiliar.stringAleatorio (10), auxiliar.stringAleatorio (10), (CNumero) auxiliar.numeroAleatorio (8), (CNumero) auxiliar.numeroAleatorio (6), (CNumero) auxiliar.numeroAleatorio (2) );
			return alumno;
		}
		public override IComparable crearPorTeclado () {
			CLectorDeDatos auxiliar = new CLectorDeDatos ();
			return new CAlumnoMuyEstudioso (auxiliar.stringPorTeclado (), auxiliar.stringPorTeclado (), (CNumero) auxiliar.numeroPorTeclado (), (CNumero) auxiliar.numeroPorTeclado (), (CNumero) auxiliar.numeroPorTeclado () );
		}
	}
}
