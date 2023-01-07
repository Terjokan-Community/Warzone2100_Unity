using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data Objekt", menuName = "Warzone2100/Base/Tank/Bottum", order = 3)]
[System.Serializable]
public class BaseTankBottum : ScriptableObject
{
    public int MaxHealth;

    public float Speet;
    public float TurnSpeed;
    public float weight;

    public GameObject Moddel;

    public BaseReserch NessesaryReserch;

    public BaseObjekt.Type type;

    public BaseTankBottum()
    {
        type = BaseObjekt.Type.TankHead;
    }
}
