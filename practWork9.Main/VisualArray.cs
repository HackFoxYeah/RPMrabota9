using System.Collections.Generic;
using System.Data;

namespace Пример_таблицы_WPF
{    
    static class VisualArray
    {        
        //Метод для зубчатого массива
        public static DataTable ToDataTable<T>(this T[][] matrix)
        {
            var res = new DataTable();

            res.Columns.Add("Тип процессора", typeof(T));
            res.Columns.Add("Объём ОЗУ", typeof(T));
            res.Columns.Add("Объём жёсткого диска", typeof(T));
            res.Columns.Add("Объём видеопамяти", typeof(T));

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var row = res.NewRow();

                for (int j = 0; j < matrix[i].GetLength(0); j++)
                {
                    row[j] = matrix[i][j];
                }

                res.Rows.Add(row);
            }

            return res;
        }

        /// <summary>
        /// Реализует визуализацию даннных на DataGrid из передаваемого списка структуры PcInfo.
        /// </summary>
        /// <param name="pcList">Список содержащий экземпляры структуры PcInfo.</param>
        /// <returns>Представление таблицы.</returns>
        public static DataTable ToDataTable(this List<PcInfo> pcList)
        {
            var tempDataGrid = new DataTable();

            tempDataGrid.Columns.Add("Номер компьютера", typeof(int));
            tempDataGrid.Columns.Add("Тип процессора", typeof(float));
            tempDataGrid.Columns.Add("Объём ОЗУ", typeof(float));
            tempDataGrid.Columns.Add("Объём жёсткого диска", typeof(float));
            tempDataGrid.Columns.Add("Объём видеопамяти", typeof(float));

            tempDataGrid.Columns[0].AutoIncrementSeed = 1;
            tempDataGrid.Columns[0].AutoIncrement = true;

            for (int i = 0; i < pcList.Count; i++)
            {
                DataRow row = tempDataGrid.NewRow();

                row[1] = pcList[i].processorType;
                row[2] = pcList[i].memorySize;
                row[3] = pcList[i].hardDriveSize;
                row[4] = pcList[i].videoMemorySize;

                tempDataGrid.Rows.Add(row);
            }

            return tempDataGrid;
        }
    }
}
