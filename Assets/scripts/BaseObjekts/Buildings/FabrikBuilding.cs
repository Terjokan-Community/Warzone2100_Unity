using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabrikBuilding : BaseBuilding
{
    public FabrikBuilding() : base() { }
    void Start()
    {
        name = GameManager.Singleton.Language.GetStringWithId("base.building.fabric.name");
        description = GameManager.Singleton.Language.GetStringWithId("base.building.fabric.destription");

        width = 2;
        height = 2;
    }
    public BaseTank CurrentTank;
}
