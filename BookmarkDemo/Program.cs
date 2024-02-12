using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W = Microsoft.Office.Interop.Word;
using System.IO;

namespace BookmarkDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filename = @"..\..\BookmarkDemo.docx";
            string docname = Path.GetFullPath(filename);

            W.Application app = new W.Application();
            try
            {

                W.Document doc = app.Documents.Open(docname);

                if (doc.Bookmarks.Count > 0)
                {
                    foreach (W.Bookmark item in doc.Bookmarks) Console.WriteLine(item.Name);
                }
                else { Console.WriteLine("pole"); }

                W.Range range = doc.Bookmarks["Nimi"].Range;
                range.Text = "Bookmargi doc sai siisa samasse";
                doc.Bookmarks.Add("Nimi", range);
                doc.Save();
            }
            finally
            {
                app.Quit();
            }


        }
    }
}
