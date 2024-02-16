using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace TestXmlToDocx
{
    internal class Program
    {
        static void Main(string[] args)
        {


            // Sinu dokumendi faili nimi
            string folder = @"c:\testDoc";
            string docxFile = "TestXml.docx";
            string docxInFolder = Path.Combine(folder, docxFile);

            // Sinu XML ja XSD failide nimed
            string xmlFile = "Kontakt.xml";
            string xsdFile = "Kontakt.xsd";
            string xmlInFolder = Path.Combine(folder, xmlFile);
            string xsdInFolder = Path.Combine(folder, xsdFile);



            // Ava ZIP-fail
            using (ZipArchive docxZip = ZipFile.Open(docxInFolder, ZipArchiveMode.Update))
            {
                // Lisa XML ja XSD failid customXml kausta
                docxZip.CreateEntryFromFile(xmlInFolder, $"customXml/{xmlFile}");
                docxZip.CreateEntryFromFile(xsdInFolder, $"customXml/{xsdFile}");
            }
        }
    }
}
