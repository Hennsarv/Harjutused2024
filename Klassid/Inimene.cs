using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Klassid
{
	class Inimene
	{
        // klass members
        // private class-Variables
        private string _nimi;
        private int vanus;
        // public class-Variables
        public int KingaNUmber = 0;

        // public properties
        public string Nimi
        {
            get => _nimi;  
            // lühike vorm AINULT siis, kui su funktsioon koosneb ühest lausest return;
        //    set => _nimi = value.Substring(0, 1).ToUpper() + value.Substring(1); 
        
             set => _nimi = string.Join(" ", 
                 value.Replace("-", "- ")
                 .Split(' ')
                 .Select(x => x.Substring(0,1).ToUpper() + x.Substring(1).ToLower()))
                .Replace("- ","-");

        }




        public int Vanus 
        {
            get { return vanus; }
            set { vanus = value < 18 ? 18 : value; }
        }

        #region MyRegion
        // public getters and setters
        public string getNimi() { return _nimi; }
        public void setNimi(string nimi)
        {
            this._nimi = nimi.Substring(0, 1).ToUpper() + nimi.Substring(1);
        }

        public int getVanus() { return vanus; }
        public void setVanus(int vanus)
        {
            this.vanus = vanus < 18 ? 18 : vanus;
        } 
        #endregion

        // public class functions and Methods
        public override string ToString()
           => $"Inimene nimega {_nimi} vanusega {vanus}";
        
    }

}
