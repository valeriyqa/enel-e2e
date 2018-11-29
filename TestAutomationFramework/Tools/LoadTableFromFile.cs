using ExcelDataReader;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace TestAutomationFramework.Tools
{
    class LoadTableFromFile
    {
        public static DataTable LoadDataTable(string filePath, string sheetName = "Sheet1")
        {
            string fileExtension = Path.GetExtension(filePath);
            switch (fileExtension.ToLower())
            {
                case ".xlsx":
                case ".xls":
                    return ConvertExcelToDataTable(filePath, sheetName);
                case ".csv":
                    return ConvertCsvToDataTable(filePath);
                default:
                    return new DataTable();
            }
        }

        public static DataTable ConvertExcelToDataTable(string filePath, string sheetName)
        {
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateOpenXmlReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (data) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    //Get all tables
                    DataTableCollection table = result.Tables;

                    //Store it in DataTable
                    DataTable resultTable = table[sheetName];

                    return resultTable;
                }
            }
        }

        public static DataTable ConvertCsvToDataTable(string filePath)
        {
            DataTable dt = new DataTable();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string[] headers = sr.ReadLine().Split(',');
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(',');
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dr[i] = rows[i];
                    }
                    dt.Rows.Add(dr);
                }

            }
            return dt;
        }

        public static Dictionary<string, object> GetDictionary(DataTable dataTable, string dictKey, string dictValue)
        {
            return dataTable.AsEnumerable()
              .ToDictionary(row => row.Field<string>(dictKey),
                            row => row.Field<object>(dictValue));
        }
    }
}
