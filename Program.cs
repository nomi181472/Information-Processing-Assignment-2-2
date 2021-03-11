using System;
using System.Net;
using System.Text.RegularExpressions;

namespace k173652_Q1
{
    class Program
    {
        static void Main(string[] args)
        {

            
                string regForUrl= @"^(http|http(s)?://)?([\w-]+\.)+[\w-]+[.com|.in|.org]+(\[\?%&=]*)?";
                 Regex reUrl = new Regex(regForUrl, RegexOptions.IgnoreCase);
                string regForDirectory = @"^(?:[a-zA-Z]\:(\\|\/)|file\:\/\/|\\\\|\.(\/|\\))([^\\\/\:\*\?\<\>\'\|]+(\\|\/){0,1})+$";
                Regex rePath = new Regex(regForDirectory,RegexOptions.IgnoreCase);
            
                if (reUrl.IsMatch((args[0])) && rePath.IsMatch((args[1])))
                {
                    WebClient wc = new WebClient();
                    DateTime today = DateTime.Today;
                    string FileName = "Summary" + today.ToString("ddMMMyy") + ".html";
                    wc.DownloadFile(args[0], args[1] + @"\" + FileName);
                    Console.WriteLine(args[1] + @"\ - will contain a file named " + FileName);
                }
                else
                {
                    Console.WriteLine("URL or Path is uncorrect");
                    return;
                }
            

        }
    }
}
