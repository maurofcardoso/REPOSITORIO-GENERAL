using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CFabricaDeAlumnos : CFabricaDeComparables
	{
		CManejadorDeDatos manejador;
		//***************************************************************************************
		public CFabricaDeAlumnos()
		{
			CManejadorDeDatos auxiliar = CGeneradorDeDatosAleatorios.getInstancia (null);
			CManejadorDeDatos auxiliar2 = new LectorDeArchivos (auxiliar);
			this.manejador = CLectorDeDatos.getInstancia (auxiliar2);
		}
		//***************************************************************************************
		public override IComparable crearAleatorio () {
			IAlumno alumno = new CAlumno (manejador.stringAleatorio (10), manejador.stringAleatorio (10), (CNumero) manejador.numeroAleatorio (8), (CNumero) manejador.numeroAleatorio (6), (CNumero) manejador.numeroAleatorio (2) );
			return alumno;
		}
		public override IComparable crearPorTeclado () {
			return new CAlumno (manejador.stringPorTeclado (), manejador.stringPorTeclado (), (CNumero) manejador.numeroPorTeclado (), (CNumero) manejador.numeroPorTeclado (), (CNumero) manejador.numeroPorTeclado () );
		}
		public override IComparable crearDesdeArchivo () {
			return new CAlumno (manejador.stringDesdeArchivo (10), manejador.stringDesdeArchivo (10), (CNumero) manejador.numeroDesdeArchivo (8), (CNumero) manejador.numeroDesdeArchivo (6), (CNumero) manejador.numeroDesdeArchivo (2) );
		}
	}
}
