
using System;
using System.Collections.Generic;
namespace DeepSpace
{

	class Estrategia
	{
		private Planeta botOriginal;
		public String Consulta1( ArbolGeneral<Planeta> arbol)
		{
			return ditanciaBotRaiz (arbol);
		}
		public String Consulta2( ArbolGeneral<Planeta> arbol)
		{
			return descendientesBot (arbol);
		}
		public String Consulta3( ArbolGeneral<Planeta> arbol)
		{
			string cadena = "";
			cadena = cadena + poblacionTotal (arbol);
			int niveles = cantidadDeNiveles (arbol);
			for (int x = 0; x <= niveles; x++) {
				cadena = cadena + ";" + " " + promedioPoblacionPorNivel (arbol, x);
			}
			return cadena;
		}	
		public Movimiento CalcularMovimiento(ArbolGeneral<Planeta> arbol)
		{
			return movimientoAtaque (arbol);
//			List <ArbolGeneral<Planeta>> caminoHaciaJugador = caminoBotJugador (arbol);
//			List <ArbolGeneral<Planeta>> listanueva = caminoBotOriginalJugador (arbol);
//			if (caminoHaciaJugador.Count > 2) {
//				return movimientoAtaque (arbol);
//			}
//			else {
//				
//			}
		}
		
		private string ditanciaBotRaiz (ArbolGeneral<Planeta> arbol) {     //por niveles con separacion    
			Queue <ArbolGeneral<Planeta>> cola = new Queue<ArbolGeneral<Planeta>> ();
			ArbolGeneral<Planeta> colaAux;
			int nivel2 = 0;
			cola.Enqueue (arbol);
			cola.Enqueue (null);
			while (cola.Count > 0) {
				colaAux = cola.Dequeue ();
				if (colaAux == null) {
					if (cola.Count > 0) {
						nivel2++;
						cola.Enqueue (null);
					}
				}
				else {
					if (colaAux.getDatoRaiz ().EsPlanetaDeLaIA () ) {
						return nivel2.ToString ();
					}
					foreach (var hijo in colaAux.getHijos () ) {
						cola.Enqueue (hijo);
					}
				}
			}
			return nivel2.ToString ();
		}
		private string descendientesBot (ArbolGeneral<Planeta> arbol) { //recorrido por niveles
			string cadena = "";
			Queue <ArbolGeneral<Planeta>> cola = new Queue<ArbolGeneral<Planeta>> ();
			ArbolGeneral<Planeta> colaAux;
			cola.Enqueue (arbol);
			while (cola.Count > 0) {
				colaAux = cola.Dequeue ();
				if (colaAux.getDatoRaiz ().EsPlanetaDeLaIA () ) {
					Queue <ArbolGeneral<Planeta>> colaListado = new Queue<ArbolGeneral<Planeta>> ();
					ArbolGeneral<Planeta> colaAuxListado;
					colaListado.Enqueue (colaAux);
					while (colaListado.Count > 0) {
						colaAuxListado = colaListado.Dequeue ();
						cadena = cadena + colaAuxListado.getDatoRaiz ().ToString () + ";" + " ";
						foreach (var hijos in colaAuxListado.getHijos () ) {
							colaListado.Enqueue (hijos);
						}
					}
				}
				foreach (var hijo in colaAux.getHijos () ) {
					cola.Enqueue (hijo);
				}
			}
			return cadena;
		}
		private double promedioPoblacionPorNivel (ArbolGeneral<Planeta> arbol, int nivel) { //con separacion
			double poblacion = 0;
			int contador = 0;
			Queue <ArbolGeneral<Planeta>> cola = new Queue<ArbolGeneral<Planeta>> ();
			ArbolGeneral<Planeta> colaAux;
			int nivel2 = 0;
			cola.Enqueue (arbol);
			cola.Enqueue (null);
			while (cola.Count > 0) {
				colaAux = cola.Dequeue ();
				if (colaAux == null) {
					if (cola.Count > 0) {
						nivel2++;
						cola.Enqueue (null);
					}
				}
				else {
					if (nivel == nivel2) {
						poblacion = poblacion + colaAux.getDatoRaiz ().Poblacion ();
						contador++;
					}
					foreach (var hijo in colaAux.getHijos () ) {
						cola.Enqueue (hijo);
					}
				}
			}
			return poblacion / contador;
		}
		private double poblacionTotal (ArbolGeneral<Planeta> arbol) { //por niveles
			double poblacionTotal = 0;
			Queue <ArbolGeneral<Planeta>> cola = new Queue<ArbolGeneral<Planeta>> ();
			ArbolGeneral<Planeta> colaAux;
			cola.Enqueue (arbol);
			while (cola.Count > 0) {
				colaAux = cola.Dequeue ();
				poblacionTotal = poblacionTotal + colaAux.getDatoRaiz ().Poblacion ();
				foreach (var hijo in colaAux.getHijos () ) {
					cola.Enqueue (hijo);
					}
			}
			return poblacionTotal;
		}
		private int cantidadDeNiveles (ArbolGeneral<Planeta> arbol) {      //con separacion   
			Queue <ArbolGeneral<Planeta>> cola = new Queue<ArbolGeneral<Planeta>> ();
			ArbolGeneral<Planeta> colaAux;
			int nivel2 = 0;
			cola.Enqueue (arbol);
			cola.Enqueue (null);
			while (cola.Count > 0) {
				colaAux = cola.Dequeue ();
				if (colaAux == null) {
					if (cola.Count > 0) {
						nivel2++;
						cola.Enqueue (null);
					}
				}
				else {
					foreach (var hijo in colaAux.getHijos () ) {
						cola.Enqueue (hijo);
					}
				}
			}
			return nivel2;
		}
		
		private List <ArbolGeneral<Planeta>> caminoOrigenBot(ArbolGeneral<Planeta> arbol) {
			List <ArbolGeneral<Planeta>> lista = new List<ArbolGeneral<Planeta>> ();
			bool resp = _caminoOrigenBot (arbol, lista);
			List <ArbolGeneral<Planeta>> listaAux = new List<ArbolGeneral<Planeta>> ();
			int contenido = lista.Count -1;
			while (contenido >= 0) {
				listaAux.Add (lista [contenido] );
				contenido = contenido - 1;
			}
			return listaAux;
		}
		private bool _caminoOrigenBot (ArbolGeneral<Planeta> arbol, List <ArbolGeneral<Planeta>> lista) {
			bool resp = false;
			if (arbol.getDatoRaiz ().EsPlanetaDeLaIA () ) {  //preorden
				botOriginal = arbol.getDatoRaiz ();
				resp = true;
			}
			else {
				foreach (var x in arbol.getHijos () ) {
					resp = _caminoOrigenBot (x, lista);
					if (resp == true) {
						break;
					}
				}
			}
			if (resp == true) {
				lista.Add (arbol);
			}
			return resp;
		}
		private List <ArbolGeneral<Planeta>> caminoOrigenJugador(ArbolGeneral<Planeta> arbol) {
			List <ArbolGeneral<Planeta>> lista = new List<ArbolGeneral<Planeta>> ();
			bool resp = _caminoOrigenJugador (arbol, lista);
			List <ArbolGeneral<Planeta>> listaAux = new List<ArbolGeneral<Planeta>> ();
			int contenido = lista.Count -1;
			while (contenido >= 0) {
				listaAux.Add (lista [contenido] );
				contenido = contenido - 1;
			}
			return listaAux;
		}
		private bool _caminoOrigenJugador (ArbolGeneral<Planeta> arbol,List <ArbolGeneral<Planeta>> lista) {
			bool resp = false;
			if (arbol.getDatoRaiz ().EsPlanetaDelJugador () ) {  //preorden
				resp = true;
			}
			else {
				foreach (var x in arbol.getHijos () ) {
					resp = _caminoOrigenJugador (x, lista);
					if (resp == true) {
						break;
					}
				}
			}
			if (resp == true) {
				lista.Add (arbol);
			}
			return resp;
		}
		private ArbolGeneral<Planeta> ancestroComunMinimo (ArbolGeneral<Planeta> arbol) {
			ArbolGeneral<Planeta> minimo = new ArbolGeneral<Planeta> (arbol.getDatoRaiz () );
			List <ArbolGeneral<Planeta>> caminoBot = caminoOrigenBot (arbol);
			List <ArbolGeneral<Planeta>> caminoJugador = caminoOrigenJugador (arbol);
			if (caminoBot.Count <= caminoJugador.Count) {
				for (int x = 0; x < caminoBot.Count; x++) {
					if (caminoBot [x] == caminoJugador [x] ) {
						minimo = caminoBot [x];
						break;
					}
				}
			}
			else {
				for (int x = 0; x < caminoJugador.Count; x++) {
					if (caminoBot [x] == caminoJugador [x] ) {
						minimo = caminoBot [x];
						break;
					}
				}
			}
			return minimo;
		}
		private List <ArbolGeneral<Planeta>> caminoBotJugador (ArbolGeneral<Planeta> arbol) {
			List <ArbolGeneral<Planeta>> listaBotAux = new List<ArbolGeneral<Planeta>> ();
			List <ArbolGeneral<Planeta>> caminoBot = caminoOrigenBot (arbol);
			List <ArbolGeneral<Planeta>> caminoJugador = caminoOrigenJugador (arbol);
			ArbolGeneral<Planeta> ancestro = ancestroComunMinimo (arbol);
			for (int x = caminoBot.Count - 1; x >= 0;x--) {
				if (caminoBot [x] == ancestro) {
					listaBotAux.Add (caminoBot [x] );
					break;
				}
				else {
					listaBotAux.Add (caminoBot [x] );
				}
			}
			for (int x = 0; x < caminoJugador.Count; x++) {
				if (caminoJugador [x] == ancestro) {
					for (int y = x+1; y < caminoJugador.Count; y++) {
						listaBotAux.Add (caminoJugador [y] );
					}
					break;
				}
			}
			return listaBotAux;
		}
		private Movimiento movimientoAtaque (ArbolGeneral<Planeta> arbol) {
			List <ArbolGeneral<Planeta>> caminoHaciaJugador = caminoBotJugador (arbol);
			Movimiento movimientoAtaque1 = new Movimiento (caminoHaciaJugador [0].getDatoRaiz (), caminoHaciaJugador [1].getDatoRaiz () );
			return movimientoAtaque1;
		}
		
		//******************************************************************************************
		//******************************************************************************************
		
//		private List <ArbolGeneral<Planeta>> caminoOrigenBotOriginal(ArbolGeneral<Planeta> arbol) {
//			List <ArbolGeneral<Planeta>> lista = new List<ArbolGeneral<Planeta>> ();
//			bool resp = _caminoOrigenBotOriginal (arbol, lista);
//			List <ArbolGeneral<Planeta>> listaAux = new List<ArbolGeneral<Planeta>> ();
//			int contenido = lista.Count -1;
//			while (contenido >= 0) {
//				listaAux.Add (lista [contenido] );
//				contenido = contenido - 1;
//			}
//			return listaAux;
//		}
//		private bool _caminoOrigenBotOriginal (ArbolGeneral<Planeta> arbol, List <ArbolGeneral<Planeta>> lista) {
//			bool resp = false;
//			if (arbol.getDatoRaiz () == botOriginal ) {  //preorden
//				resp = true;
//			}
//			else {
//				foreach (var x in arbol.getHijos () ) {
//					resp = _caminoOrigenBotOriginal (x, lista);
//					if (resp == true) {
//						break;
//					}
//				}
//			}
//			if (resp == true) {
//				lista.Add (arbol);
//			}
//			return resp;
//		}
//		private List <ArbolGeneral<Planeta>> caminoBotOriginalJugador (ArbolGeneral<Planeta> arbol) {
//			List <ArbolGeneral<Planeta>> listaBotAux = new List<ArbolGeneral<Planeta>> ();
//			List <ArbolGeneral<Planeta>> caminoBotOriginal = caminoOrigenBotOriginal (arbol);
//			List <ArbolGeneral<Planeta>> caminoJugador = caminoOrigenJugador (arbol);
//			ArbolGeneral<Planeta> ancestro = ancestroComunMinimoBotOriginal (arbol);
//			for (int x = caminoBotOriginal.Count - 1; x >= 0;x--) {
//				if (caminoBotOriginal [x] == ancestro) {
//					listaBotAux.Add (caminoBotOriginal [x] );
//					break;
//				}
//				else {
//					listaBotAux.Add (caminoBotOriginal [x] );
//				}
//			}
//			for (int x = 0; x < caminoJugador.Count; x++) {
//				if (caminoJugador [x] == ancestro) {
//					for (int y = x+1; y < caminoJugador.Count; y++) {
//						listaBotAux.Add (caminoJugador [y] );
//					}
//					break;
//				}
//			}
//			return listaBotAux;
//		}
//		private ArbolGeneral<Planeta> ancestroComunMinimoBotOriginal (ArbolGeneral<Planeta> arbol) {
//			ArbolGeneral<Planeta> minimo = new ArbolGeneral<Planeta> (arbol.getDatoRaiz () );
//			List <ArbolGeneral<Planeta>> caminoBotOriginal = caminoOrigenBotOriginal (arbol);
//			List <ArbolGeneral<Planeta>> caminoJugador = caminoOrigenJugador (arbol);
//			if (caminoBotOriginal.Count <= caminoJugador.Count) {
//				for (int x = 0; x < caminoBotOriginal.Count; x++) {
//					if (caminoBotOriginal [x] == caminoJugador [x] ) {
//						minimo = caminoBotOriginal [x];
//					}
//				}
//			}
//			else {
//				for (int x = 0; x < caminoJugador.Count; x++) {
//					if (caminoBotOriginal [x] == caminoJugador [x] ) {
//						minimo = caminoBotOriginal [x];
//					}
//				}
//			}
//			return minimo;
//		}
//		private Movimiento movimientoAtaqueRefuerzos (ArbolGeneral<Planeta> arbol) {
//				if (caminoHaciaJugador [0].getDatoRaiz ().population > caminoHaciaJugador [1].getDatoRaiz ().population * 2) {
//					Movimiento movimientoAtaqueComun = new Movimiento (caminoHaciaJugador [0].getDatoRaiz (), caminoHaciaJugador [1].getDatoRaiz () );
//					return movimientoAtaqueComun;
//				}
//				else {
//					int cont = 0;
//					for (int z = 0; z <= listanueva.Count - 2;) {
//						Movimiento movimientoAtaqueRefuerzos2 = new Movimiento (listanueva [cont].getDatoRaiz (), listanueva [cont + 1].getDatoRaiz () );
//						cont = cont + 1;
//					}
//				}
//			}
//			Movimiento movimientoAtaque11 = new Movimiento (caminoHaciaJugador [0].getDatoRaiz (), caminoHaciaJugador [1].getDatoRaiz () );
//			return movimientoAtaque11;
//		}
	}
}
