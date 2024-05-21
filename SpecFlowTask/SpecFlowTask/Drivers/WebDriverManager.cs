using OpenQA.Selenium.Edge;

namespace SpecFlowTask.Drivers

{
    public class WebDriverManager
    {
        private static readonly EdgeDriver driver = new EdgeDriver();

        public static EdgeDriver Driver
        {
            get => driver;
        }
    }

}
