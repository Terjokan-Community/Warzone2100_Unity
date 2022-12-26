using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameManager GM;

    public GameObject List;
    public GameObject ListObjectPrefab;

    public 

    void Start()
    {
        List.SetActive(false);
    }


    public void OnButtonPressed(int id)
    {
        if (id == 0)
            List.SetActive(false);
        if(id == 1)
        {
            List.SetActive(true);

        }

    }
    public void GenerateList(List<BaseObjekt> list)
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
