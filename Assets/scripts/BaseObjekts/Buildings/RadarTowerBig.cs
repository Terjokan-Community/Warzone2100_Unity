using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarTowerBig : BaseBuilding
{
    public RadarTowerBig() : base() { }
    private void Start()
    {
        name = GameManager.Singleton.Language.GetStringWithId("base.building.radar_big.name");
        description = GameManager.Singleton.Language.GetStringWithId("base.building.radar_big.destription");
    }
}
