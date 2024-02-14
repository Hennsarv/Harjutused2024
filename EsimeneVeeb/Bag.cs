using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace EsimeneVeeb
{
    class Bag : DynamicObject
    {
        dynamic bag;

        public Bag() => bag = new Dictionary<string, dynamic>();
        public Bag(dynamic dict) => bag = dict;

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            switch (bag)
            {
                case IDictionary<string, object> d:
                    result = d.ContainsKey(binder.Name) ? d[binder.Name] : null;
                    return true;
                default:
                    result = bag[binder.Name];
                    return true;
            }


        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            bag[binder.Name] = value;
            return true;
        }

        public override string ToString()
        {
            if (bag == null || !(bag is IDictionary<string, object>)) return null;
            Dictionary<string, dynamic>.KeyCollection keys = bag.Keys;

            return "{" +
            string.Join(", ",
            keys.Select(key => $"{key}={bag[key]}"))
            + "}";
            ;
        }
    }


 


    

}