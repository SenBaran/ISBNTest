using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnQPayWithFun.Logic.Controllers.Business
{
    public static class BookLogic
    {
        public static bool CheckISBNNumber(string isbn)
        {
            int sum = 0;
            if(isbn != null && isbn.Length == 10)
            {
                for (int i = 0; i < isbn.Length - 1; i++)
                {
                    if (char.IsDigit(isbn[i]))
                    {
                        int isbnInt = isbn[i] - '0';

                        sum += (isbnInt * (i + 1));

                    }                
                }

                sum = sum % 11;

                if(sum == 10 && ('X' == isbn[10])){
                    return true;
                } else if (sum == (isbn[9] - '0'))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
