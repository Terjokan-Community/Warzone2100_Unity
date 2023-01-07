using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data Objekt", menuName = "Warzone2100/Base/Tank/Top", order = 1)]
[System.Serializable]
public class BaseTankTop : ScriptableObject
{
    public int MaxHealth;
    public float weight;

    public float ReloadTime;
    public BaseBullet bullet;

    public GameObject Moddel;

    public BaseReserch NessesaryReserch;


    public BaseTankTop()
    {

    }
    public string NameId;
    public string DescriptionId;

    public BaseObjekt ToBase()
    {
        BaseOtherObjekts t = new BaseOtherObjekts(BaseObjekt.Type.TankHead);
        t.name = GameManager.Singleton.Language.GetStringWithId(NameId);
        t.description = GameManager.Singleton.Language.GetStringWithId(DescriptionId);
        t.Original = this;

        return t;
    }

}
