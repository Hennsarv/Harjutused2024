using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EsimeneVeeb.Helpers
{
    public abstract class BaseViewPage<TModel> : WebViewPage<TModel>
    {
        public string HennuNimi = "Henn";

        dynamic _tempBag;
        public dynamic TempBag =>
            _tempBag ?? (_tempBag = new Bag(TempData));

        dynamic _paramsBag;
        public dynamic ParamsBag =>
            _paramsBag ?? (_paramsBag = new Bag(Request.Params));
        
        public override void Execute()
        {
            // CommonData on kättesaadav kõigis vaadetes
            // Kasuta seda siin
        }
    }
}