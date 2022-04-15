using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Entidades
{
    public class Operando
    {
        #region ATRIBUTO
        private double numero;
        #endregion

        /// <summary>
        /// Valida que el valor recibido sea numerico
        /// </summary>
        /// <param name="strNumero">Dato tipo string al cual se le realiza la validacion</param>
        /// <returns></returns>
        private static double ValidarOperando(string strNumero)
        {
            double aux;

            if (!double.TryParse(strNumero, out aux))
            {
                return 0;
            }

            else {
                return aux;
                 }
        }
        /// <summary>
        /// Valida antes de de asignar el valor
        /// </summary>
        private string Numero
        {
            set
            {
                
                this.numero = ValidarOperando(value);
            }
        }
        /// <summary>
        /// se valida que sea 0 o 1
        /// </summary>
        /// <param name="binario">cadena a validar</param>
        /// <returns>return true o false</returns>
        private static bool EsBinario(string binario)
        {
            bool rtn = true;

            foreach (char bin in binario)
            {
                if (Regex.IsMatch(binario, "[^01]")) //se valida que la cadena se ajuste al patron 
                {
                    rtn = false;
                }

            }
            return rtn;
        }
        /// <summary>
        /// convert de binario a decimal
        /// </summary>
        /// <param name="binario">num bin a convert</param>
        /// <returns>retorna decimal convert. en tipo strin o valor invalido </returns>
        public string BinarioDecimal(string binario)
        {
            double num = 0;
            if (EsBinario(binario))
            {
                char[] array = binario.ToCharArray();
                Array.Reverse(array);//se invierte el array

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == '1')
                    {
                        num += (int)Math.Pow(2, i);
                    }
                }
                return num.ToString();
            }

            else
            {
                return "Valor Invalido";
            }
        }
        /// <summary>
        /// convierte de decimal a bin
        /// </summary>
        /// <param name="numero">numero a convert</param>
        /// <returns>retorna num binario en string</returns>
        public string DecimalBinario(double numero)
        {
            string binario = "";
            int num = (int)numero;

            while (num > 0)
            {
                if (num % 2 == 0)
                {
                    binario = "0" + binario;
                }
                else
                {
                    binario = "1" + binario;
                }
                num = (int)(num / 2);
            }

            return binario;
        }
        /// <summary>
        /// Convierte el numero de Decimal a Binario
        /// </summary>
        /// <param name="numero">num a convertir</param>
        /// <returns>retorna el string convert a bin</returns>
        public string DecimalBinario(string numero)
        {
            string rtn;
            double num;

            if (double.TryParse(numero, out num))
            {
                rtn = DecimalBinario(num);
            }
            else
            {
                rtn = "Valor invalido";
            }

            return rtn;
        }

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor por defecto que asigna valor 0 al atributo numero
        /// </summary>
        public Operando()
        {
            this.numero = 0;
        }
        /// <summary>
        /// Contructor que guarda el numero en la variable
        /// </summary>
        /// <param name="numero"></param>
        public Operando(double numero)
        {
            this.numero = numero;
        }
        /// <summary>
        /// Constructor que guarda el numero validado
        /// </summary>
        /// <param name="strNumero">numero a guardar de tipo string</param>
        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }
        #endregion

        //Sobrecarga de operadores
        #region OPERADORES
        /// <summary>
        /// Sobrecarga del operador +
        /// </summary>
        /// <param name="n1">obj 1</param>
        /// <param name="n2">obj 2</param>
        /// <returns>retorna la suma de los atributos num1 y num2</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador -
        /// </summary>
        /// <param name="n1">obj 1</param>
        /// <param name="n2">obj 2</param>
        /// <returns>retorna la resta de los atributos num1 y num2</returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador *
        /// </summary>
        /// <param name="n1">obj 1</param>
        /// <param name="n2">obj 2</param>
        /// <returns>retorna la multiplicacion de los atributos num1 y num2</returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador /
        /// </summary>
        /// <param name="n1">obj 1</param>
        /// <param name="n2">obj 2</param>
        /// <returns>retorna la division de los atributos num1 y num2</returns>
        public static double operator /(Operando n1, Operando n2)
        {
            double rtn;
            if (n2.numero == 0)
            {
                rtn= double.MinValue;
            }
            else
            {
                rtn= n1.numero / n2.numero;
            }
            return rtn;
        }

        #endregion

    }
}
