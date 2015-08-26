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
*/

namespace Programmer_Calc
{
    class BasicCalculator
    {
        private double storedValue;
        private double currentOnScreen;
        private enum sign { plus, minus, multi, div, none };
        private sign lastSign;

        private bool justPressedSign;

        private string result;


        public BasicCalculator()
        {
            currentOnScreen = 0;            // indicates the value of the content on display
            lastSign = sign.none;           // no previous operation
            justPressedSign = false;        // it would be the first time to press a sign button
        }

        public string Result
        {
            get { return result; }
            set { result = value; }
        }

        public void UpdateCurrent(string input)
        {
            currentOnScreen = Convert.ToDouble(input);          // if doesn't work, use tryParse
            justPressedSign = false;
        }

        public string Equals()
        {
            string tempResult = "";
            // TODO: Check if result in double makes a difference
            // TODO: Specifically if all the ".000" is kept in the box

            switch(lastSign)
            {
                case sign.none:
                    // do nothing
                    break;
                case sign.plus:
                    tempResult = (storedValue + currentOnScreen).ToString();
                    break;
                case sign.minus:
                    tempResult = (storedValue - currentOnScreen).ToString();
                    break;
                case sign.multi:
                    tempResult = (storedValue * currentOnScreen).ToString();
                    break;
                case sign.div:
                    tempResult = (storedValue / currentOnScreen).ToString();
                    break;
            }

            lastSign = sign.none;

            return tempResult;
        }

        public string Add()
        {
            if (lastSign == sign.none)
            {
                storedValue = currentOnScreen;
                currentOnScreen = 0;
                lastSign = sign.plus;
                justPressedSign = true;

                return "+";
            }
            else
            {
                switch (lastSign)
                {
                    case sign.plus:

                        break;
                    case sign.minus:

                        break;
                    case sign.multi:

                        break;
                    case sign.div:

                        break;
                }
                
                return "0";                      //TODO: To be deleted
            }
        }

        private char charAt(string str, int i)
        {
            char ch;
            char[] array = str.ToCharArray();

            try
            {
                ch = array[i];
            }
            catch (Exception e)
            {
                return '0';
            }
    
            return ch;
        }
    }
}
