using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TodosLosTPJuntos
{
	public class CGerente : IObservador
	{
		private CPila mejores;
		private CPila listaVendedores;
		//*******************************************************************************************
		public CGerente()
		{
			this.mejores = new CPila ();
			this.listaVendedores = new CPila ();
		}
		//*******************************************************************************************
		public void cerrar () {
			IIterador auxiliar = mejores.crearIterador ();
			Console.WriteLine ("ESTE ES EL LISTADO DE LOS MEJORES VENDEDORES: ");
			while (!auxiliar.fin () ) {
				CVendedor vendedorAuxiliar = (CVendedor) auxiliar.actual ();
				Console.WriteLine (vendedorAuxiliar.getApellido (), vendedorAuxiliar.getNombre (), "su bonus fue: ", vendedorAuxiliar.getBonus () );
				auxiliar.siguiente ();
			}
			Console.WriteLine ("                                                                       ");
			Console.WriteLine ("ESTOS SON TODOS LOS VENDEDORES: ");
			IIterador iterador = this.listaVendedores.crearIterador ();
			while (!iterador.fin () ) {
				CVendedor vendedorAuxiliar2 = (CVendedor) iterador.actual ();
				Console.WriteLine (vendedorAuxiliar2.getApellido (), vendedorAuxiliar2.getNombre (), "su bonus fue: ", vendedorAuxiliar2.getBonus () );
				iterador.siguiente ();
			}
		}
		public void venta (double monto, CVendedor vendedor) {
			if (monto > 5000) {
				if (!buscaVendedor (vendedor) ) {
					mejores.agregar (vendedor);
				}
				vendedor.aumentaBonus ();
			}
		}
		public bool buscaVendedor (CVendedor vendedor) {
			IIterador auxiliar = mejores.crearIterador ();
			while (!auxiliar.fin () ) {
				if (auxiliar.actual ().sosIgual (vendedor) ) {
					return true;
				}
				auxiliar.siguiente ();
			}
			return false;
		}
		public void actualizar (IObservado o) {
			CVendedor auxiliar = (CVendedor) o;
			this.venta (auxiliar.getMonto (), auxiliar);
			if (!buscaVendedor (auxiliar) ) {
				this.listaVendedores.agregar (auxiliar);
			}
			else {
				CPila pilaAuxiliar = new CPila ();
				int contenido = this.listaVendedores.cuantos ();
				for (int x = 0; x < contenido; x++) {
					CVendedor vendedorAuxiliar = (CVendedor) this.listaVendedores.getListaPila ().Pop ();
					if (vendedorAuxiliar.sosIgual (auxiliar) ) {
						pilaAuxiliar.getListaPila ().Push (vendedorAuxiliar);
					}
					else {
						pilaAuxiliar.getListaPila ().Push (vendedorAuxiliar);
					}
				}
				for (int x = 0; x < contenido; x++) {
					this.listaVendedores.getListaPila ().Push (pilaAuxiliar.getListaPila ().Pop () );
				}
			}
		}

	}
}
