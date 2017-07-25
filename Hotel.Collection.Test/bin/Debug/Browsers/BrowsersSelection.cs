using Hotel.Framework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Hotel.Framework.Browsers
{
    class BrowsersSelection
    {
        public String SelectBrowser(String browserToRun, String filename)
        {
            try
            {
                String configDirectory = AppDomain.CurrentDomain.BaseDirectory + "\\Browser\\" + filename;

                XmlTextReader reader = new XmlTextReader(configDirectory);
                XmlDocument document = new XmlDocument();
                document.Load(reader);

                XmlNode parentNode = document.SelectSingleNode("browsers");

                XmlNode browser = parentNode.SelectSingleNode(browserToRun);

                String selectedBrowser = browser.InnerText.Trim();

                reader.Close();
                reader.Dispose();

                return selectedBrowser;
                  

            }
            catch (Exception e)
            {
                Logger.log.Error(e);
                return null;

            }
        }
    }
}
