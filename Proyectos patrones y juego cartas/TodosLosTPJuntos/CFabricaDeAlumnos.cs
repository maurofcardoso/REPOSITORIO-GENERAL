using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CFabricaDeAlumnos : CFabricaDeComparables
	{
		public CFabricaDeAlumnos()
		{
		}
		//***************************************************************************************
		public override IComparable crearAleatorio () {
			CGeneradorDeDatosAleatorios auxiliar = new CGeneradorDeDatosAleatorios ();
			IAlumno alumno = new CAlumno (auxiliar.stringAleatorio (10), auxiliar.stringAleatorio (10), (CNumero) auxiliar.numeroAleatorio (8), (CNumero) auxiliar.numeroAleatorio (6), (CNumero) auxiliar.numeroAleatorio (2) );
			return alumno;
		}
		public override IComparable crearPorTeclado () {
			CLectorDeDatos auxiliar = new CLectorDeDatos ();
			return new CAlumno (auxiliar.stringPorTeclado (), auxiliar.stringPorTeclado (), (CNumero) auxiliar.numeroPorTeclado (), (CNumero) auxiliar.numeroPorTeclado (), (CNumero) auxiliar.numeroPorTeclado () );
		}
	}
}
