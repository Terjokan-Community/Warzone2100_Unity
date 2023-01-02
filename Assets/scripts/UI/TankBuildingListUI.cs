using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankBuildingListUI : MonoBehaviour
{
    public BaseObjekt baseObjekt;
    public void SetGUI(BaseObjekt baseObjekt)
    {
        this.baseObjekt = baseObjekt;
        GetComponentInChildren<Image>().sprite = baseObjekt.UIImage;

        GetComponent<Button>().onClick.AddListener(OnCLick);
    }

    public void OnCLick()
    {
        if(baseObjekt.type == BaseObjekt.Type.Building)
            GameManager.Singleton.buildingSystem.currentSelected = (BaseBuilding)baseObjekt;
    }

}
