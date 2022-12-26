using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data Objekt", menuName = "Warzone2100/Base/Reserch", order = 2)]
[System.Serializable]
public class BaseReserch : ScriptableObject
{
    public enum TechStufe
    {
        Tier1,
        Tier2,
        Tier3,
        Tier4
    }

    public BaseReserch NessesaryReserch;
    public TechStufe techStufe;
    public BaseObjekt.Type type;

    public List<BaseObjekt> freigeschaltet;

    public BaseReserch()
    {
        type = BaseObjekt.Type.Reserch;
    }
}
