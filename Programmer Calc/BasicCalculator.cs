using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Methods:
/*
	- void UpdateCurrent (string input)
	
	- string Add(void)
		* performs the same function as the add button pushed on a real calculator
		* returns the value to be shown in UI
	
	- string Sub(void)
		* performs the same function as the subtract button pushed on a real calculator
		* returns the value to be shown in UI

	- string Mul(void)
		* performs the same function as the multiply button pushed on a real calculator
		* returns the value to be shown in UI
		
	- string Div(void)
		* performs the same function as the div button pushed on a real calculator
		* returns the value to be shown in UI
	
	- string Equals(void)
		* calculates the result of the operation as the equals button on a real calculator
		* returns the value to be shown in UI
	
	- void ClearAll(void)
		* set everything back to original state
		
	- char charAt(string str, int i)
		* returns the character at index i of string str
        * this function later was proved to be replaceable by "String[index]"
*/

namespace Programmer_Calc
{
    class BasicCalculator
    {
        private double storedValue;
        private double currentOnScreen;
        public enum sign { plus, minus, multi, div, none };
        private sign lastSign;

        //private string result;


        public BasicCalculator()
        {
            currentOnScreen = 0;            // indicates the value of the content on display
            storedValue = 0;
            LastSign = sign.none;           // no previous operation
        }

        public sign LastSign
        {
            get { return lastSign; }
            set { lastSign = value; }
        }

        //public string Result
        //{
        //    get { return result; }
        //    set { result = value; }
        //}

        public void UpdateCurrent(string input)
        {
            bool canParse = Double.TryParse(input, out currentOnScreen);          // if doesn't work, use tryParse
        }

        public string Equals()
        {
            switch(LastSign)
            {
                case sign.none:
                    storedValue = currentOnScreen;
                    break;
                case sign.plus:
                    storedValue = storedValue + currentOnScreen;
                    break;
                case sign.minus:
                    storedValue = storedValue - currentOnScreen;
                    break;
                case sign.multi:
                    storedValue = storedValue * currentOnScreen;
                    break;
                case sign.div:
                    storedValue = storedValue / currentOnScreen;
                    break;
            }

            LastSign = sign.none;
            currentOnScreen = storedValue;

            return storedValue.ToString();
        }

        public string Add(out string processText)
        {
            if (LastSign == sign.none)
            {
                // store currently on-screen value and don't do anything

                storedValue = currentOnScreen;

                processText = storedValue.ToString();

                LastSign = sign.plus;
                return "+";
            }
            else
            {
                switch (LastSign)
                {
                    case sign.plus:
                        storedValue = storedValue + currentOnScreen;
                        break;
                    case sign.minus:
                        storedValue = storedValue - currentOnScreen;
                        break;
                    case sign.multi:
                        storedValue = storedValue * currentOnScreen;
                        break;
                    case sign.div:
                        storedValue = storedValue / currentOnScreen;
                        break;
                }
            }
            currentOnScreen = 0;
            processText = storedValue.ToString();
            LastSign = sign.plus;

            return "+";
        }

        public string Sub(out string processText)
        {
            if (LastSign == sign.none)
            {
                storedValue = currentOnScreen;

                processText = storedValue.ToString();

                LastSign = sign.minus;
                return "-";
            }
            else
            {
                switch (LastSign)
                {
                    case sign.plus:
                        storedValue = storedValue + currentOnScreen;
                        break;
                    case sign.minus:
                        storedValue = storedValue - currentOnScreen;
                        break;
                    case sign.multi:
                        storedValue = storedValue * currentOnScreen;
                        break;
                    case sign.div:
                        storedValue = storedValue / currentOnScreen;
                        break;
                }
            }
            currentOnScreen = 0;
            processText = storedValue.ToString();
            LastSign = sign.minus;

            return "-";
        }

        public string Multi(out string processText)
        {
            if (LastSign == sign.none)
            {
                storedValue = currentOnScreen;

                processText = storedValue.ToString();

                LastSign = sign.multi;
                return "×";
            }
            else
            {
                switch (LastSign)
                {
                    case sign.plus:
                        storedValue = storedValue + currentOnScreen;
                        break;
                    case sign.minus:
                        storedValue = storedValue - currentOnScreen;
                        break;
                    case sign.multi:
                        storedValue = storedValue * currentOnScreen;
                        break;
                    case sign.div:
                        storedValue = storedValue / currentOnScreen;
                        break;
                }
            }
            currentOnScreen = 0;
            processText = storedValue.ToString();
            LastSign = sign.multi;

            return "×";
        }

        public string Div(out string processText)
        {
            if (LastSign == sign.none)
            {
                storedValue = currentOnScreen;

                processText = storedValue.ToString();

                LastSign = sign.div;
                return "÷";
            }
            else
            {
                switch (LastSign)
                {
                    case sign.plus:
                        storedValue = storedValue + currentOnScreen;
                        break;
                    case sign.minus:
                        storedValue = storedValue - currentOnScreen;
                        break;
                    case sign.multi:
                        storedValue = storedValue * currentOnScreen;
                        break;
                    case sign.div:
                        storedValue = storedValue / currentOnScreen;
                        break;
                }
            }
            currentOnScreen = 0;
            processText = storedValue.ToString();
            LastSign = sign.div;

            return "÷";
        }

        public void Initialise()
        {
            storedValue = 0;
            currentOnScreen = 0;
            LastSign = sign.none;
        }

        //public char charAt(string str, int i)
        //{
        //    char ch;
        //    char[] array = str.ToCharArray();

        //    try
        //    {
        //        ch = array[i];
        //    }
        //    catch (Exception)
        //    {
        //        return '0';
        //    }
    
        //    return ch;
        //}
    }
}
