using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameWorthWatching.Models
{
    public class NBA_internalModel
    {
        public NBA_internalModel() { }

        public DateTime pubDateTime { get; set; }

        public string xslt { get; set; }

        public string eventName { get; set; }
    }
}