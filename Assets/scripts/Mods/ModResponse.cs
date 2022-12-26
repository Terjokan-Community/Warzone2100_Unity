using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mods.ModCore
{
    public class ModResponse 
    {
        public String Message { get; set; } = "";
        public Boolean HasError { get; set; } = false;
        public String MessageID { get; set; } = "";
    }
}
