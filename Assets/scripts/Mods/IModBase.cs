using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;


namespace Mods.ModCore
{
    public interface IModBase
    {
        public String Name { get; set; }
        public String Description { get; set; }

        public ObservableCollection<object> DynamicValues { get; set; }

        public ModResponse Initialize(ModParameters parameters);
        public ModResponse Execute(ModParameters parameters);
    }
}
