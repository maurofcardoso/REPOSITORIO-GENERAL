using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CGeneradorDeDatosAleatorios
	{
		public CGeneradorDeDatosAleatorios()
		{
		}
		//*******************************************************************************************
		public IComparable numeroAleatorio (int max) {
			Random auxiliar = new Random ();
			return new CNumero (auxiliar.Next (1, max) );
		}
		public string stringAleatorio (int cant) {
			string caracteres = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
        	StringBuilder auxiliar = new StringBuilder();
        	Random random = new Random();
        	while (0 < cant--)
        	{
        	    auxiliar.Append(caracteres[random.Next(caracteres.Length)]);
        	}
        	return auxiliar.ToString();
		}
	}
}
