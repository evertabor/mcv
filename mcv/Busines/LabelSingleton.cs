using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mcv.Busines
{
    public class LabelSingleton
    {
        private static LabelSingleton instance = null;

        public string texto1 = "";
        public string texto2 = "";
        public string texto3 = "";

        private LabelSingleton()
        {
            using (Models.MYDBEntities1 db = new Models.MYDBEntities1())
            {
                var lisLabel = db.label.ToList();
                texto1 = lisLabel.Where(d => d.id == 1).First().text;
                texto2 = lisLabel.Where(d => d.id == 2).First().text;
                texto3 = lisLabel.Where(d => d.id == 3).First().text;
            }
        }
        public static LabelSingleton Instance
        {
            get
            {
                if (instance == null)
                    instance = new LabelSingleton();
                return instance;
            }
        }
    }
}