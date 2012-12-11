using System;
using System.Text.RegularExpressions;

namespace Utilities.Finance
{
    public static class CreditCard
    {
        public static CreditCardType GetCreditCardType(string accountNo)
        {
            CreditCardType cardType = CreditCardType.Unknown;

            try
            {
                string leftChar1 = accountNo.Substring(0, 1);
                string leftChar2 = accountNo.Substring(0, 2);
                string leftChar4 = accountNo.Substring(0, 4);
                string leftChar6 = accountNo.Substring(0, 6);

                if (leftChar1 == "4" && accountNo.Length == 16)
                {
                    cardType = CreditCardType.Visa;
                }
                else if (leftChar1 == "5" && accountNo.Length == 16)
                {
                    cardType = CreditCardType.MasterCard;
                }
                else if ((leftChar2 == "34" || leftChar2 == "37") && accountNo.Length == 15)
                {
                    cardType = CreditCardType.Amex;
                }
                else if ((leftChar4 == "6011" || leftChar2 == "65" || leftChar6 == "622126" || leftChar6 == "622925")
                    && accountNo.Length == 16)
                {
                    cardType = CreditCardType.Discover;
                }
            }
            catch { }

            return cardType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="creditCardNumber"></param>
        /// <returns></returns>
        /// <remarks>http://www.codeproject.com/KB/recipes/ccmod10validation.aspx</remarks>
        public static bool ValidateCreditCardNumber(string creditCardNumber)
        {
            //Replace any character other than 0-9 with ""

            creditCardNumber = Regex.Replace(creditCardNumber, @"[^0-9]", "");

            int cardSize = creditCardNumber.Length;

            //Creditcard number length must be between 13 and 16

            if (cardSize >= 13 && cardSize <= 16)
            {
                int odd = 0;
                int even = 0;
                char[] cardNumberArray = new char[cardSize];

                //Read the creditcard number into an array

                cardNumberArray = creditCardNumber.ToCharArray();

                //Reverse the array

                Array.Reverse(cardNumberArray, 0, cardSize);

                //Multiply every second number by two and get the sum. 

                //Get the sum of the rest of the numbers.

                for (int i = 0; i < cardSize; i++)
                {
                    if (i % 2 == 0)
                    {
                        odd += (Convert.ToInt32(cardNumberArray.GetValue(i)) - 48);
                    }
                    else
                    {
                        int temp = (Convert.ToInt32(cardNumberArray[i]) - 48) * 2;
                        //if the value is greater than 9, substract 9 from the value

                        if (temp > 9)
                        {
                            temp = temp - 9;
                        }
                        even += temp;
                    }
                }
                if ((odd + even) % 10 == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static string GetMaskedCardNumber(string creditCardNumber)
        {
            string maskedCard = string.Empty;
            int maskedCardLength = creditCardNumber.Length - 4;
            maskedCard = creditCardNumber.Substring(maskedCardLength, 4);
            maskedCard = maskedCard.PadLeft(maskedCardLength, 'x');
            return maskedCard;
        }  
    }
}
