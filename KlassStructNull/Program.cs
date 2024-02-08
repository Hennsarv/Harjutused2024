using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.CompilerServices;
using System.Data.SqlTypes;

namespace KlassStructNull
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            int[] arvud = {1,2,3, };
            var max =
                arvud.Skip(4).DefaultIfEmpty()?.Count()??-1 ;

            // ?. conditional member call - kui punkti ees on null, siis ära täida

            // if (event != null) event.Invoke
            // event?.Invoke

            // (avaldis) ?? (asendus)
            // (avaldis) == null ? (asendus) ? (avaldis)

            int? arv = null;
            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday) arv = 100;
            var maksta = arv??0 ;

            DateTime? date = null;

            // kui me ei tea väärtust - las olla 2000
            var aasta = date?.Year ?? 2000;



            
        }

        

    }

    // teeme selle viimase classide asja ka ära, siis saam ehomme rahulikult andmetega tegelda

   

}
