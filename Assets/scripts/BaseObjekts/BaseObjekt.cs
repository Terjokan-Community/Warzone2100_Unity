using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class BaseObjekt : MonoBehaviour 
{
    public enum Type
    {
        Building,
        TankHead,
        TankBody,
        TankBottum,
        Tank,
        Reserch
    }

    public Type type;
    public string description;

    public bool UI;
    public Sprite UIImage;



}
