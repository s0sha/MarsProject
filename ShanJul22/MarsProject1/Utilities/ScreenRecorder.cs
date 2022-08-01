using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Expression.Encoder.ScreenCapture;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MarsProject1.Utilities
{
    internal class ScreenRecorder
    {
        
        private ScreenCaptureJob screenCaptureJob = new ScreenCaptureJob();


        public void SetVideoOutputLocation(string testName = "")
        {
            try
            {

                if (string.IsNullOrEmpty(testName))
                { testName = "AutomationTest"; }

                // string path1 = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\Recorder");
                string path1 = "C://ShanJul22/";
                string path2 = path1 + testName + ".wmv";

                screenCaptureJob.OutputScreenCaptureFileName = path2;
            }

            catch (Exception ex) { Console.WriteLine(ex); }

        }

        public void StartRecording()
        {
            screenCaptureJob.Start();
        }
        public void StopRecording()
        {
            screenCaptureJob.Stop();
            screenCaptureJob.Dispose();
        }


    }
}
