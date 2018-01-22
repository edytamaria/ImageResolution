using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace ImageResolution
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("Podaj ścieżkę do katalogu: ");
            string _inputDir = Console.ReadLine();
            if (!Directory.Exists(_inputDir))
            {
                _inputDir = Directory.GetCurrentDirectory();
                Console.WriteLine("niepoprawna ścieżka");
            }
            else
                Console.WriteLine("poprawna ścieżka");

            Console.WriteLine("Podaj docelową ścieżkę do katalogu: ");
            string _outputDir = Console.ReadLine();
            if (!Directory.Exists(_outputDir))
            {
                _outputDir = _inputDir + "\\copy";
                int counter = 1;
                while (Directory.Exists(_outputDir))
                {
                    _outputDir = _outputDir + counter;
                    counter++;
                }
                Directory.CreateDirectory(_outputDir);
            }
            else
                Console.WriteLine("poprawny");

            Console.WriteLine("Podaj nową rozdzielczość: ");
            string res = Console.ReadLine();

            //string resPattern = "([0-9])\\w([0-9])";
            int[] newResolution = new int[2];
            newResolution[0] =Int32.Parse( res.Split(' ')[0]);
            newResolution[1] = Int32.Parse(res.Split(' ')[1]);


            Image image = new Image();
            image.CreateImagesWithNewResolution(_inputDir, _outputDir, newResolution);

            Console.ReadKey();
            

        }
    }
}
