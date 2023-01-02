using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class BaseBuilding : BaseObjekt
{
    public int width;
    public int height;

    public BaseBuilding()
    {
        type = Type.Building;
    }

    public virtual void OnPlaced(Vector3 position) { }


}
