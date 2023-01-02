using CodeMonkey.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridXZ<TGridObjekt> : MonoBehaviour
{
    public int width;
    public int height;
    public float cellSize;
    Func<GridXZ<TGridObjekt>, int, int, TGridObjekt> returnfunk;

    public Vector3 origenPosition;

    public TGridObjekt[,] gridArray;
    public GridXZ(int width, int height, float cellSize, Vector3 origenPosition, Func<GridXZ<TGridObjekt>, int, int, TGridObjekt> creatGridObjekt)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.origenPosition = origenPosition;
        returnfunk = creatGridObjekt;

        gridArray = new TGridObjekt[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                gridArray[x, y] = creatGridObjekt(this, x, y);
            }
        }


        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                //Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                //Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
                //UtilsClass.CreateWorldText(gridArray[x, y].ToString(), null, GetWorldPosition(x, y) + new Vector3(cellSize, cellSize) * .5f, 20, Color.white, TextAnchor.MiddleCenter);
            }
        }
        //Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        //Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
    }

    public Vector3 GetWorldPosition(int x, int z)
    {
        return new Vector3(x, 0 ,z) * cellSize + origenPosition;
    }

    public void GetXZ(Vector3 worldPosition, out int x, out int z)
    {
        x = (int)((worldPosition - origenPosition).x / cellSize);
        z = (int)((worldPosition - origenPosition).z / cellSize);
    }

    private void SetValue(Vector3 worldPosition, TGridObjekt Value)
    {
        int x, z;
        GetXZ(worldPosition, out x, out z);
        SetValue(x, z, Value);
    }
    public void SetValue(int x, int z, TGridObjekt Value)
    {
        if (x >= 0 && z >= 0 && x < width && z < height)
        {
            gridArray[x, z] = Value;
        }
    }

    public TGridObjekt GetValue(int x, int z)
    {
        if (x >= 0 && z >= 0 && x < width && z < height)
        {
            return gridArray[x, z];
        }
        else
        {
            Debug.Log("fail");
            return returnfunk(this, x, z );
        }
    }
    public TGridObjekt GetValue(Vector3 worldPosition)
    {
        int x, z;
        GetXZ(worldPosition, out x, out z);
        return GetValue(x, z);
    }
}
