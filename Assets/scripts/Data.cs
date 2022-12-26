using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data Objekt", menuName = "Warzone2100/Data", order = 2)]
[System.Serializable]
public class Data : ScriptableObject
{
    public List<BaseBuilding> buildings;
    public List<BaseTankBody> tankBodies;
    public List<BaseTankBottum> tankBottum;
    public List<BaseTankTop> tankTop;
    public List<BaseTank> tanks;
    public List<BaseReserch> reserch;
}
