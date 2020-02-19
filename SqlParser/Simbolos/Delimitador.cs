using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlParser.Simbolos
{
	public class Delimitador
	{
		public String palabra;
		public int valor;

		public Delimitador(String delimitador, int valor)
		{
			this.palabra = delimitador;
			this.valor = valor;
		}



	}
}
