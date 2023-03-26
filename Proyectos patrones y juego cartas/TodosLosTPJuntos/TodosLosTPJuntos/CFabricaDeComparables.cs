using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public abstract class CFabricaDeComparables : IFabricaDeComparables
	{
		public CFabricaDeComparables()
		{
		}
		//***************************************************************************************
		public static IComparable crearAleatorio (string opcion) {
			CFabricaDeComparables fabricar = null;
			if (opcion == "NUMERO") {
				fabricar = new CFabricaDeNumeros ();
			}
			if (opcion == "ALUMNO") {
				fabricar = new CFabricaDeAlumnos ();
			}
			if (opcion == "VENDEDOR") {
				fabricar = new CFabricaDeVendedores ();
			}
			if (opcion == "ALUMNOMUYESTUDIOSO") {
				fabricar = new CFabricaDeAlumnosMuyEstudiosos ();
			}
			if (opcion == "ALUMNOPROXY") {
				fabricar = new CFabricaDeAlumnosProxy ();
			}
			if (opcion == "ALUMNOCOMPUESTO") {
				fabricar = new CFabricaDeAlumnoCompuesto ();
			}
			return fabricar.crearAleatorio ();
		}
		public static IComparable crearPorTeclado (string opcion) {
			CFabricaDeComparables fabricar = null;
			if (opcion == "NUMERO") {
				fabricar = new CFabricaDeNumeros ();
			}
			if (opcion == "ALUMNO") {
				fabricar = new CFabricaDeAlumnos ();
			}
			if (opcion == "VENDEDOR") {
				fabricar = new CFabricaDeVendedores ();
			}
			if (opcion == "ALUMNOMUYESTUDIOSO") {
				fabricar = new CFabricaDeAlumnosMuyEstudiosos ();
			}
			if (opcion == "ALUMNOPROXY") {
				fabricar = new CFabricaDeAlumnosProxy ();
			}
			if (opcion == "ALUMNOCOMPUESTO") {
				fabricar = new CFabricaDeAlumnoCompuesto ();
			}
			return fabricar.crearPorTeclado ();
		}
		public static IComparable crearDesdeArchivo (string opcion) {
			CFabricaDeComparables fabricar = null;
			if (opcion == "NUMERO") {
				fabricar = new CFabricaDeNumeros ();
			}
			if (opcion == "ALUMNO") {
				fabricar = new CFabricaDeAlumnos ();
			}
			if (opcion == "VENDEDOR") {
				fabricar = new CFabricaDeVendedores ();
			}
			if (opcion == "ALUMNOMUYESTUDIOSO") {
				fabricar = new CFabricaDeAlumnosMuyEstudiosos ();
			}
			if (opcion == "ALUMNOPROXY") {
				fabricar = new CFabricaDeAlumnosProxy ();
			}
			if (opcion == "ALUMNOCOMPUESTO") {
				fabricar = new CFabricaDeAlumnoCompuesto ();
			}
			return fabricar.crearDesdeArchivo ();
		}
		
		public abstract IComparable crearAleatorio ();
		public abstract IComparable crearPorTeclado ();
		public abstract IComparable crearDesdeArchivo ();
	}
}
