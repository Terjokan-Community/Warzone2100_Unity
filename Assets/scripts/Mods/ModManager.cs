using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Mods.ModCore
{
    public class ModManager 
    {
        private HashSet<string> DirectoryPaths = new HashSet<string>();
        public HashSet<IModBase>CurrentMods = new HashSet<IModBase>();
        public ModManager(String DirectoryPath)
        {
            DirectoryPaths.Add(DirectoryPath);
            LoadMods();
        }
        public ModManager(List<String> DirectoryPaths)
        {
            this.DirectoryPaths = new HashSet<string>(DirectoryPaths);
            LoadMods();
        }

        public void LoadMods()
        {
            CurrentMods = new HashSet<IModBase>();
            foreach (var ele in DirectoryPaths)
            {
                DirectoryInfo dir = new DirectoryInfo(ele);
                foreach (FileInfo file  in dir.GetFiles("*.dll"))
                {
                    Assembly ass = Assembly.LoadFrom(file.FullName);
                    foreach(Type l in ass.GetTypes())
                    {
                        if((l.IsSubclassOf(typeof(IModBase)) || l.GetInterfaces().Contains(typeof(IModBase))) && l.IsAbstract == false)
                        {
                            IModBase h = l.InvokeMember(null,BindingFlags.CreateInstance,null,null,null) as IModBase;

                            ModResponse r = h.Initialize(new ModParameters());
                            if(r.HasError)
                            {
                                Debug.LogError(r.Message);
                                continue;
                            }
                            Debug.Log(r.Message);

                            CurrentMods.Add(h);
                        }
                    }
                }
            }
        }
    }
}
