using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практос_номер_2
{
    static class VisualArray
    {
        //Метод для одномерного массива
        public static DataTable ToDataTable<T>(this T[] arr)
        {
            var res = new DataTable();
            for (int i = 0; i < arr.Length; i++)
            {
                res.Columns.Add("col" + (i + 1), typeof(T));
            }
            var row = res.NewRow();
            for (int i = 0; i < arr.Length; i++)
            {
                row[i] = arr[i];
            }
            res.Rows.Add(row);
            return res;
        }
    }
}
