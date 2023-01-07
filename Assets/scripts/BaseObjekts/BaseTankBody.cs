using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data Objekt", menuName = "Warzone2100/Base/Tank/Body", order = 2)]
[System.Serializable]
public class BaseTankBody : ScriptableObject
{
    public int MaxHealth;
    public float weight;

    public bool CanHold2Cannons;

    public string NameId;
    public string DescriptionId;

    public BaseObjekt ToBase()
    {
        BaseOtherObjekts t = new BaseOtherObjekts(BaseObjekt.Type.TankBody);
        t.name = GameManager.Singleton.Language.GetStringWithId(NameId);
        t.description = GameManager.Singleton.Language.GetStringWithId(DescriptionId);
        t.Original = this;

        return t;
    }
}
