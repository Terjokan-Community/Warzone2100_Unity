using CodeMonkey.Utils;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{
    private GridXZ<GridObject> grid;

    public BaseBuilding currentSelected;
    public GameObject prevew;
    public List<BuildCheck> buildChecks = new List<BuildCheck> ();

    public void GenerateGrid(int width, int height, float cellSize,string Mapname)
    {
        
        grid = new GridXZ<GridObject>(width, height, cellSize, Vector3.zero, (GridXZ<GridObject> g, int x, int z) => new GridObject(g, x, z));

        

        buildChecks = JsonConvert.DeserializeObject<List<BuildCheck>>(File.ReadAllText(Application.streamingAssetsPath + "/Json/Maps/" + Mapname + ".json"));
        foreach (BuildCheck item in buildChecks)
        {
            grid.GetValue(item.x, item.z).Canplace = false;
        }
    }
    public void CurrentPreIsNotOk(GameObject gm)
    {
        if(prevew != null)
        {
            Debug.Log("test");
            grid.GetValue(gm.transform.position).Canplace = false;
        }
    }

    private void Update()
    {
        

        if (Input.GetMouseButtonDown(1))
        {
            currentSelected = null;
            Destroy(prevew);
            /*
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                int x = grid.GetValue(hit.point).x;
                int z = grid.GetValue(hit.point).z;
                buildChecks.Add(new BuildCheck(x, z));
                TextMesh t = UtilsClass.CreateWorldText(grid.GetValue(x, z).x.ToString(), null, grid.GetWorldPosition(x, z) + new Vector3(1,0, 1) , 5, Color.white, TextAnchor.MiddleCenter);
                t.transform.rotation = new Quaternion(90 , 0, 0, 90);
                t.fontSize = 60;
                t.characterSize = 0.18f;
                File.WriteAllText(Application.streamingAssetsPath + "/Json/Maps/" + "TestMap" + ".json", JsonConvert.SerializeObject(buildChecks));
            }
            */
            
        }
        if(currentSelected != null && prevew == null)
        {
            prevew = Instantiate(currentSelected.gameObject, gameObject.transform);
            prevew.GetComponent<BaseBuilding>().enabled = false;
            MeshRenderer renderer = prevew.GetComponentInChildren<MeshRenderer>();
            renderer.material.color = Color.green;
            prevew.transform.localScale += new Vector3(0.05f ,0.05f ,0.05f);
        }
        if(prevew != null )
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                int x = grid.GetValue(hit.point).x;
                int z = grid.GetValue(hit.point).z;
                prevew.transform.position = new Vector3(x * grid.cellSize, hit.point.y, z * grid.cellSize);
                MeshRenderer renderer = prevew.GetComponentInChildren<MeshRenderer>();
                renderer.material.color = Color.green;

                if(currentSelected != null)
                for (int x1 = x; x1 < x + currentSelected.width; x1++)
                {
                    for (int y1 = z; y1 < z + currentSelected.height; y1++)
                    {
                        if(!grid.GetValue(x1, y1).isPlayseble())
                        {
                            renderer.material.color = Color.red;
                        }
                    }
                }
            }
        }
        if (Input.GetMouseButtonDown(0) && currentSelected != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                int x = grid.GetValue(hit.point).x;
                int z = grid.GetValue(hit.point).z;


                if (grid.GetValue(x, z).isPlayseble()) {
                    BaseBuilding gm = Instantiate(currentSelected.gameObject, gameObject.transform).GetComponent<BaseBuilding>();
                    
                    for (int x1 = x; x1 < x + gm.width ; x1++)
                    {
                        for (int y1 = z; y1 < z + gm.height ; y1++)
                        {
                            if(!grid.GetValue(x1, y1).isPlayseble())
                            {
                                for (int x2 = x; x2 < x + gm.width; x2++)
                                {
                                    for (int y2 = z; y2 < z + gm.height; y2++)
                                    {
                                        if (grid.GetValue(x2, y2).Building == gm)
                                        {
                                            grid.GetValue(x2, y2).isBuilding = false;
                                            grid.GetValue(x2, y2).Building = null;
                                        }
                                    }
                                }
                                Destroy(gm.gameObject);
                                return; // skips the rest of the funktion
                            }
                            grid.GetValue(x1, y1).isBuilding = true;
                            grid.GetValue(x1, y1).Building = gm;
                        }
                    }
                    

                    GameManager.Singleton.CurrentGameData.buildings.Add(gm);

                    gm.gameObject.transform.position = new Vector3(x * grid.cellSize , hit.point.y , z * grid.cellSize);

                    gm.OnPlaced(gm.transform.position);

                    currentSelected = null;
                    Destroy(prevew);
                }
            }
        }
    }
}
public class GridObject
{
    private GridXZ<GridObject> grid;
    public int x, z;
    public Vector3 position;

    public bool Canplace = true;

    public bool isBuilding;
    public GameObject BuildingObjekt;
    public BaseBuilding Building;

    public GridObject(GridXZ<GridObject> grid, int x, int z)
    {
        this.grid = grid;
        this.x = x;
        this.z = z;

    }
    public void SpawnTest(GameObject test)
    {

    }

    public bool isPlayseble()
    {
        return (Canplace && !isBuilding);
    }
}

public class BuildCheck
{
    public int x, z;
    public BuildCheck(int x, int z)
    {
        this.x = x;
        this.z = z;
    }
}

