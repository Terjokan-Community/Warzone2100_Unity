using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;


namespace Mods.ModCore
{
    public class ModParameters
    {
        public DbConnection con { get; set; } = null;
        public HashSet<object> Context { get; set; } = new HashSet<object>();
    }
}
