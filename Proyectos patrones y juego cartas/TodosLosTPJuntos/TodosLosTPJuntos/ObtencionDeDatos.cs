/*
 * Created by Metodologías de Programación I
 * Activity 7. 
 * Chain of responsability and Singleton patterns 
 *
 * Antes de usar este código el alumno deberá agregar a la variable "ruta_archivo" de la clase 
 * "LectorDeArchivos" la ruta correspondiente a su equipo donde haya guardado el archvo con los datos
 * provistos por la cátedra (archivo datos.txt)
 *
 * IMPORTANTE *  
 * El código que está en este archivo SI puede modificarse para resolver la actividad solicitada
 * 
 */

using System;
using System.Dynamic;
using System.Data;
using Microsoft.VisualBasic;
using Microsoft.CSharp;
using System.IO;
//using MetodologíasDeProgramaciónI;

namespace TodosLosTPJuntos
{
	public class LectorDeArchivos : CManejadorDeDatos, IObtencionDeDatos {
		
		// El alumno deberá agregar la ruta correspondiente a su equipo donde haya guardado el archvo con los datos
		private const string ruta_archivo = @"C:\Users\Usuario\Downloads\METODOLOGIA\datos.txt";
		// --------------------------------------------------------------------------------------------------------
		
		private StreamReader lector_de_archivos;
		
		public LectorDeArchivos(IObtencionDeDatos sucesor):base(sucesor){
			lector_de_archivos = new StreamReader(ruta_archivo);
		}
		
		public override IComparable numeroDesdeArchivo(int max){
			string linea = lector_de_archivos.ReadLine();
			double num = Double.Parse(linea.Substring(0, linea.IndexOf('\t')))*1;
			int numero = (int) num;
			return  new CNumero (numero);
		}
		
		public override string stringDesdeArchivo(int cant){
			string linea = lector_de_archivos.ReadLine();
			linea = linea.Substring(linea.IndexOf('\t')+1);
			cant = Math.Min(cant, linea.Length);
			return linea.Substring(0, cant);
		}
		public IComparable numeroAleatorio (int max) {
			return new CNumero (-1);
		}
		public string stringAleatorio (int cant) {
			return "";
		}
		public IComparable numeroPorTeclado () {
			return new CNumero (-1);
		}
		public string stringPorTeclado () {
			return "";
		}
	}
}
