using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseOtherObjekts : BaseObjekt
{
    public object Original;
    public BaseOtherObjekts(Type type) : base()
    {
        base.type = type;
    }

}
