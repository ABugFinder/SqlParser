using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlParser.Simbolos
{
	public class Delimitador
	{
		public String delimitador;
		public int valor;

		public Delimitador(String delimitador, int valor)
		{
			this.delimitador = delimitador;
			this.valor = valor;
		}



	}
}
