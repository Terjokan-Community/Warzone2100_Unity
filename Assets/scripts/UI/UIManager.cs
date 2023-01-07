using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameManager GM;

    public GameObject List;
    public GameObject ListObjectPrefab;

    public GameObject ListBottum;

    
    [Space]
    [Header("Tank Building System")]
    [Space]
    public GameObject ListOtherSide;
    public GameObject TankBuilder;
    [Space]
    public int TankBuildingState;
    public GameObject BuldingState2Button;
    public GameObject BuldingState3Button;
    public GameObject BuldingState4Button;
    public GameObject Shooting;
    public GameObject NotShooting;
    [Space]
    public BaseTankBody buildingS1;
    public BaseTankBottum buildingS2;
    public BaseTankTop buildingS3;
    public BaseTankTop buildingS4;
    public void OnBuildingStateClick(int id)
    {
        TankBuildingState = id;
        UpdateBuldingState(true);
    }

    public void SetCurrentTank(BaseObjekt bs)
    {
        if(bs.type == BaseObjekt.Type.TankBottum)
        {
            buildingS2 = (BaseTankBottum)((BaseOtherObjekts)bs).Original;
        }
        if (bs.type == BaseObjekt.Type.TankHead)
        {
            if (TankBuildingState == 3)
                buildingS3 = (BaseTankTop)((BaseOtherObjekts)bs).Original;
            else
                buildingS4 = (BaseTankTop)((BaseOtherObjekts)bs).Original;
        }
        if (bs.type == BaseObjekt.Type.TankBody)
        {
            buildingS1 = (BaseTankBody)((BaseOtherObjekts)bs).Original;
        }
        UpdateBuldingState();
    }

    public void UpdateBuldingState(bool SetUversprung = false)
    {
        

        if (buildingS1 != null) { TankBuildingState = SetUversprung == false ? 2 : TankBuildingState; BuldingState2Button.SetActive(true); }
        if (buildingS2 != null) { TankBuildingState = SetUversprung == false ? 3 : TankBuildingState; BuldingState3Button.SetActive(true); }
        if (buildingS3 != null && buildingS1.CanHold2Cannons) { TankBuildingState = SetUversprung == false ? 4 : TankBuildingState; BuldingState3Button.SetActive(true); }
        
        if(buildingS1 == null)
            BuldingState2Button.SetActive(false);
        if (buildingS2 == null)
            BuldingState3Button.SetActive(false);
        if (buildingS3 == null)
            BuldingState4Button.SetActive(false);
        int i = TankBuildingState;
        if (i == 1)
        {
            List<BaseObjekt> list = new List<BaseObjekt>();
            foreach (BaseTankBody item in GM.ReserchedData.tankBodies)
            {
                list.Add(item.ToBase());
            }
            GenerateList(list, ListOtherSide);
        }
        if (i == 2)
        {
            List<BaseObjekt> list = new List<BaseObjekt>();
            foreach (BaseTankBottum item in GM.ReserchedData.tankBottum)
            {
                list.Add(item.ToBase());
            }
            GenerateList(list, ListOtherSide);
        }
        if (i == 3 || i == 4)
        {
            List<BaseObjekt> list = new List<BaseObjekt>();
            foreach (BaseTankTop item in GM.ReserchedData.tankTop)
            {
                list.Add(item.ToBase());
            }
            GenerateList(list, ListOtherSide);
        }
    }
    void Start()
    {
        List.transform.parent.parent.parent.parent.gameObject.SetActive(false);
        ListBottum.transform.parent.parent.parent.parent.gameObject.SetActive(false);
        TankBuilder.SetActive(false);
    }


    public void OnButtonPressed(int id)
    {
        if (id == 0)
        {
            List.transform.parent.parent.parent.parent.gameObject.SetActive(false);
            ListBottum.transform.parent.parent.parent.parent.gameObject.SetActive(false);
            TankBuilder.SetActive(false);
        }
        if(id == 1)
        {
            ListBottum.transform.parent.parent.parent.parent.gameObject.SetActive(true);
            List<BaseObjekt> list = new List<BaseObjekt>();
            foreach (var item in GM.CurrentGameData.buildings)
            {
                if (item.type == BaseObjekt.Type.Building && item.GetType() == typeof(FabrikBuilding))
                    list.Add(item);
            }
            GenerateList(list, ListBottum);

            List.transform.parent.parent.parent.parent.gameObject.SetActive(true);
            list = new List<BaseObjekt>();
            foreach (var item in GM.ReserchedData.tanks)
            {
                if (item.type == BaseObjekt.Type.Tank)
                    list.Add(item);
            }
            GenerateList(list, List);
        }
        if(id == 2)
        {
            List.transform.parent.parent.parent.parent.gameObject.SetActive(true);
            List<BaseObjekt> list = new List<BaseObjekt>();
            foreach (BaseReserch item in GM.ReserchedData.reserch)
            {
                if (item.type == BaseObjekt.Type.Building)
                    list.Add(item.ToBase());
            }
            GenerateList(list, List);
        }
        if (id == 3)
        {
            List.transform.parent.parent.parent.parent.gameObject.SetActive(true);
            List<BaseObjekt> list = new List<BaseObjekt>();
            foreach (BaseBuilding item in GM.ReserchedData.buildings)
            {
                if (item.type == BaseObjekt.Type.Building)
                    list.Add(item);
            }
            GenerateList(list, List);
        }
        if(id == 4)
        {
            TankBuilder.SetActive(true);
            TankBuildingState = 1;
        }
        if (id == 5)
        {
            //TODO: 
        }
        if (id == 6)
        {
            //TODO: Commandoturm
        }
    }

    public void GenerateList(List<BaseObjekt> list, GameObject List)
    {
        for (int i = 0; i < List.transform.childCount; i++)
        {
            Destroy(List.transform.GetChild(i).gameObject);
        }

        foreach (BaseObjekt item in list)
        {
            GameObject gm = Instantiate(ListObjectPrefab, List.transform);
            gm.GetComponent<TankBuildingListUI>().SetGUI(item);
            gm.SetActive(true);
        }
    }

}
