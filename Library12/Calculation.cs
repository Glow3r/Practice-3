using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoubleDimensionArrayManager;

namespace Library12
{
    public static class Calculation
    {
        public static string MinimalNumber(this MyArray myarray)
        {
            List<int> biggestColumnValues = new List<int> { };

            for (int i = 0; i < myarray.ColumnLength; i++)
            {
                int maxValue = 1;

                for (int j = 0; j < myarray.RowLength; j++)
                {
                    if (myarray[j, i] > maxValue)
                    {
                        maxValue = myarray[j, i];
                    }

                    if (j == myarray.RowLength - 1)
                    {
                        biggestColumnValues.Add(maxValue);
                    }
                }
            }
            return biggestColumnValues.Min().ToString();
        }
    }
}
