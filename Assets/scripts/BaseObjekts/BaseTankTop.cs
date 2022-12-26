using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data Objekt", menuName = "Warzone2100/Base/Tank/Top", order = 1)]
[System.Serializable]
public class BaseTankTop : ScriptableObject
{
    public BaseBullet bullet;

    public GameObject Moddel;

    public BaseReserch NessesaryReserch;

    public BaseObjekt.Type type;

    public BaseTankTop()
    {
        type = BaseObjekt.Type.TankHead;
    }

}
