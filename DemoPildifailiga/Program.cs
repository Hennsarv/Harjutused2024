using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace DemoPildifailiga
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo di = new DirectoryInfo(@"..\..\");
            foreach (FileInfo fi in di.GetFiles()) { Console.WriteLine(fi.Name); }

            Console.ReadLine();

            string filename = "..\\..\\640px-Scarabaeus_sacerkropp.jpg";

            Form f = new Form { Height = 500, Width = 500 };
            Label lbl = new Label { Text = "Tere!" };

            PictureBox pictureBox = new PictureBox { Height = 400, Width = 400, Top = 50, Left = 50  };
            //            pictureBox.Image = Image.FromFile(filename);

            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                pictureBox.Image = Image.FromStream(fs);
            }


            f.Controls.Add(lbl);
            f.Controls.Add(pictureBox);
            f.ShowDialog();
        }
    }
}
