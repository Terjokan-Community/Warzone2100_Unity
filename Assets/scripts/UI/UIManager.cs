using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameManager GM;

    public GameObject List;
    public GameObject ListObjectPrefab;

    public GameObject ListBottum;


    void Start()
    {
        List.transform.parent.parent.parent.parent.gameObject.SetActive(false);
        ListBottum.transform.parent.parent.parent.parent.gameObject.SetActive(false);
    }


    public void OnButtonPressed(int id)
    {
        if (id == 0)
        {
            List.transform.parent.parent.parent.parent.gameObject.SetActive(false);
            ListBottum.transform.parent.parent.parent.parent.gameObject.SetActive(false);
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
            //TODO: tank building system
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
