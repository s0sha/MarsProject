using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace MarsProject1.Utilities
{
    internal static class MScreenPrint
    {

        public static string SavePath = "C://ShanJul22/ShanJul22/MarsProject1/ScreenPrints/";
        public static string[] Prints = new string[50];

        public static int cnt = 0, cntPrint=0;

        public static string GetPath()
        {
            return SavePath;
           
        }

        public static void TakePrint(IWebDriver driver,string fileN) 
        {

            cntPrint++;
            string screenPath = SavePath + fileN + cntPrint.ToString() + ".png";
            Screenshot screenPrint = ((ITakesScreenshot)driver).GetScreenshot();
            screenPrint.SaveAsFile(screenPath, ScreenshotImageFormat.Png);
            Prints[cntPrint]=(screenPath);

            
        }

        public static string GetPrintPath() 
        {
            cnt ++;
            return Prints[cnt];
        }

    }
}
