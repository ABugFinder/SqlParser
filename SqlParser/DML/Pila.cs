using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlParser.DML
{
    class Pila
    {
		public Nodo head;
		//Apuntadores
		public Nodo p, y;

		public Pila()
		{
			head = null;
			p = null;
			y = null;
		}

		public void push(String dato)
		{
			if (head == null)
			{

				head = new Nodo(dato);
				y = head;
				p = y.sig;

			}
			else
			{

				p = new Nodo(dato);
				p.ant = y;
				y = p;
				p = y.sig;

			}
		}

		public String pop()
		{
			String aux = "";

			if (head != null && y != null)
			{

				aux = y.dato;
				y = y.ant;

				if (y != null)
				{
					y.sig = null;
					p = y.sig;
				}

			}
			return aux;
		}

		public String getApuntador()
		{
			if (head != null && y != null)
			{
				return y.dato;
			}
			return "vacio";
		}

		/*
		public void pushPalabras(String linea, Pila pila)
		{
			String[] aux = linea.Split(' ');

			for (int x = aux.Length - 1; x >= 0; x--)
			{
				pila.push(aux[x]);
			}
		}
		*/
	}
}
