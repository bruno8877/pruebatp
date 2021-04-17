using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {   /// <summary>
        /// valida que el operador recibido sea +, -, / o*.
        /// </summary>
        /// <param name="Operador">+, -, / o*</param>
        /// <returns>Retorna el operador validado o + </returns>
        private static string ValidarOperador(char Operador)
        {
            string rtn = "+";

            if(Operador == '+' || Operador == '-' || Operador == '/' || Operador == '*')
            {
                rtn = Operador.ToString();
            }
            return rtn;
        }
        
        /// <summary>
        /// Hace el calculo de num1 y num2
        /// </summary>
        /// <param name="Num1">Primer numero a operar</param>
        /// <param name="Num2">Segundo numero a operar</param>
        /// <param name="Operador">+, -, / o*</param>
        /// <returns>Retorna el resultado de dicha operacion</returns>
        public static double Operar(Numero Num1, Numero Num2, string Operador)
        {
            double rtn;
           Operador = ValidarOperador(Convert.ToChar(Operador));//convierte el string a char

            switch (Operador)
            {
                case "/":
                    rtn = Num1 / Num2;
                    break;

                case "*":
                    rtn = Num1 * Num2;
                    break;

                case "-":
                    rtn = Num1 - Num2;
                    break;

                default:
                    rtn = Num1 + Num2;
                    break;
            }
            return rtn;
        }
    }
}
