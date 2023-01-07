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

    public BaseTankBottum()
    {
    }

    public string NameId;
    public string DescriptionId;

    public BaseObjekt ToBase()
    {
        BaseOtherObjekts t = new BaseOtherObjekts(BaseObjekt.Type.TankBottum);
        t.name = GameManager.Singleton.Language.GetStringWithId(NameId);
        t.description = GameManager.Singleton.Language.GetStringWithId(DescriptionId);
        t.Original = this;

        return t;
    }
}
