using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ImageResolution
{
    class Image
    {
        public Image(){}
        
        public void NewResolution(string file, string outputDir, int[] resolution)
        {
            string fname = FindFileName(file);            
           
            using (Bitmap bitmap = (Bitmap)System.Drawing.Image.FromFile( file, true))
            {
                using (Bitmap newBitmap = new Bitmap(bitmap))
                {
                    int counter = 1;
                    newBitmap.SetResolution(resolution[0], resolution[1]);
                    // --------- check if the same name exists --------------
                    while(File.Exists(outputDir + "\\" + fname + counter + ".jpg"))
                    {
                        var cooo = outputDir + "\\" + fname + counter + ".jpg";
                        counter++;
                    }
                    var newdirectory = outputDir + "\\" + fname + counter + ".jpg";
                    newBitmap.Save(newdirectory, ImageFormat.Jpeg);
                }
            }
            Console.WriteLine("Opracja udana.");
        }

        public void CreateImagesWithNewResolution(string inputDir, string outputDir, int[] resolution)
        {
            var files = Directory.GetFiles(inputDir, "*", SearchOption.TopDirectoryOnly);
            int fCount = files.Length;
            foreach (string file in Directory.EnumerateFiles(inputDir, "*.jpg"))
            {
                NewResolution(file, outputDir, resolution);
            }
        }

        public string FindFileName(string file)
        {
            var findname = file.Split('\\');
            string fname = findname[findname.Length - 1].Split('.')[0];
            return fname;
        }
    }
}
