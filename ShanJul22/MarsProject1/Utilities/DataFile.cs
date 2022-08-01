
using NPOI.XSSF.UserModel;

namespace MarsProject1.Utilities
{
    internal static class DataFile
    {
        static int rowValue = 0;
        static int posValue = 0;
        static String PathName= "C:/ShanJul22/ShanJul22/MarsProject1/Data/DataBook.xlsx";
        static XSSFWorkbook workbook1 = new XSSFWorkbook(File.Open(path: PathName, FileMode.Open));
        
        public static void openFile() 
        {
            
            rowValue++;

        }
        public static string  getData() 
        {
            DateOnly date = new DateOnly();
            String[] Mon = {"Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec" };
            
            string findMonth(String val) 
            {
                int pos = 1;
                foreach (String s in Mon) 
                { if (s == val) 
                    { 
                        if (pos < 10) {
                            return ("0"+pos.ToString());
                                } 
                        return pos.ToString(); }
                  else { pos++; } 
                }
                
                return pos.ToString();

            }

            var sheet = workbook1.GetSheetAt(0);
            var row = sheet.GetRow(rowValue);
            var cellv = row.GetCell(posValue);

            var value = cellv.ToString(); 
            //Console.WriteLine(value);

            if ((posValue == 2)||(posValue==5)) 
            {
                var value2 = value.Substring(3, 3);

                string value3 = "", month = "";
                
                //Console.WriteLine(value2);
                
                month = findMonth(value2);
                //Console.WriteLine(month);
                var day = value.Substring(0, 2); Console.WriteLine(day);
                var year = value.Substring(7,4); Console.WriteLine(year);
                //Console.WriteLine(day+month+year);
                value = day + month + year;

            }


            
            posValue++;
            
            if (posValue >= 6)      { posValue = 0; } 
           
            return value;


        }


    }
}
