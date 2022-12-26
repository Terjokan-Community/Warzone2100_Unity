using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabrikBuilding : BaseBuilding
{
    public FabrikBuilding() : base()
    {
        name = GameManager.Singleton.Language.GetStringWithId("base.building.fabric.name");
        description = GameManager.Singleton.Language.GetStringWithId("base.building.fabric.destription");
    }
}
