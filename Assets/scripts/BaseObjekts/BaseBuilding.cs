using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class BaseBuilding : BaseObjekt
{
    public BaseBuilding()
    {
        type = Type.Building;
    }
}
