using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        #region METODOS
        /// <summary>
        ///  validará y realizará la operación pedida entre ambos números.
        /// </summary>
        /// <param name="num1">Operando numero 1</param>
        /// <param name="num2">Operando numero 2</param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double rtn=0;

            switch(ValidarOperador(operador))
            {
                case '/':
                    rtn = num1 / num2;
                    break;

                case '*':
                    rtn = num1 * num2;
                    break;

                case '-':
                    rtn = num1 - num2;
                    break;

                default:
                    rtn = num1 + num2;
                    break;
            }
            return rtn;

        }
        /// <summary>
        /// Deberá validar que el operador recibido sea +, -, / o *. 
        /// </summary>
        /// <param name="operador">Variable char con el operador</param>
        /// <returns>Caso contrario retornará +</returns>
        private static char ValidarOperador(char operador)
        {
            char rtn = '+';

            if (operador == '+' || operador == '-' || operador == '/' || operador == '*')
            {
                rtn = operador;
            }

            return rtn;
        }
        #endregion
    }
}
