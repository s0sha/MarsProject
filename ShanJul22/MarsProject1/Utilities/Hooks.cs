using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Gherkin.Model;
using MarsProject1.Utilities;
using MarsProject1.StepDefinitions;
using MarsProject1.Pages;


namespace MarsProject1.Utilities
{
    [Binding]
    internal sealed class Hooks
    {

        private static ExtentTest? featureName;
        private static ExtentTest? scenario;
        private static AventStack.ExtentReports.ExtentReports? extent;


        public static string path = MScreenPrint.GetPath();
        public static string path2 = "" + "C://MVP Project/MarsProject/ShanJul22/MarsProject1/ScreenPrints/";
   
        public static int cnt = 0;


        [BeforeTestRun]
        public static void BeforeTestRun() 
        {
            

            ExtentHtmlReporter mReport = new(path2);
            //ExtentXReporter xReporter = new("localhost");

            mReport.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(mReport);
            




        }

        [BeforeFeature]
        
        public static void BeforeFeature() 
        {
            featureName = extent?.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
            Console.WriteLine("Before Feature");
        }

        [BeforeScenario]
        
        public static void BeforeScenario()
        {
            Console.WriteLine("Before Scenario");
            
                scenario = featureName?.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);

        }

        [AfterStep]
        public static void InsertReportingSteps() 
        {
            
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                {
                    
                    scenario?.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                    
                }
                else if (stepType == "When")
                {
                    cnt++;
                    scenario?.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                    
                    
                }
                else if (stepType == "Then")
                {
                    cnt++;
                    scenario?.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                    
                }
            }
            else if (ScenarioContext.Current.TestError != null)
            {
                if (stepType == "Given")
                {
                    scenario?.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                }
                else if (stepType == "When")
                {
                    scenario?.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                }
                else if (stepType == "Then")
                {
                    scenario?.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                }

            }
            


        }

        [AfterScenario]
        public static void AfterScenario() 
        {
            Console.WriteLine("AfterScenario");
        }


        [AfterTestRun]
        public static void AfterTestRun() 
        { 
          
            
            extent.Flush();
        }

    }
}
