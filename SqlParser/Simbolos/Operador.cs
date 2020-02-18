using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlParser.Simbolos
{
	public class Operador
	{
		public String operador;
		public int valor;

		public Operador(String operador, int valor)
		{
			this.operador = operador;
			this.valor = valor;
		}
	}

}