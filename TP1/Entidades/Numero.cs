using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Entidades
{
    public class Numero
    {
        private double numero; //atributo numero privado

        /// <summary>
        /// comprobará que el valor recibido sea numérico
        /// </summary>
        /// <param name="StrNumero"></param>
        /// <returns>lo retornará en formato double</returns>
        private double ValidarNumero(string StrNumero)
        {
            double rtn;

            double.TryParse(StrNumero, out rtn);

            return rtn;
        }
        /// <summary>
        /// asignará un valor al atributo número
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(Convert.ToString(value));
            }
        }

        #region Constructores

        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double num)
        {
            this.numero = num;
        }

        public Numero(string StrNum)
        {
            this.SetNumero = StrNum;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// validará que se trate de un binario
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>Devolvera true si es binario, o false si no lo es</returns>
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
        /// convertirá el número binario a decimal, en caso de ser posible.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>caso contrario retornará "Valor inválido".</returns>
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
        /// convertirá un número decimal a binario, en caso de ser posible.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Retorna el numero en binario en formato string</returns>
        public string DecimalBinario(double numero)
        {
            string binario = "";
            int num =(int)numero;
            
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
        /// convertirá un número decimal a binario, en caso de ser posible.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Caso contrario retornará "Valor inválido".</returns>
        public string DecimalBinario(string numero)
        {
            string rtn;
            double num;

            if(double.TryParse(numero, out num))
            {
                rtn = DecimalBinario(num);
            }
            else
            {
                rtn = "Valor Invalido";
            }

            return rtn;
        }


        #endregion

        //Sobrecarga de operadores
        #region Operadores
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            if(n2.numero == 0)
            {
                return double.MinValue;
            }
            else
            {
                return n1.numero / n2.numero;
            }
        }

        #endregion
    }
}   
