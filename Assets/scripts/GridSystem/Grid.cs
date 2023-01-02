using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using System;

public class Grid <TGridObjekt>
{
    public int width;
    public int height;
    public float cellSize;

    public Vector3 origenPosition;

    public TGridObjekt[,] gridArray;
    public Grid(int width, int height, float cellSize, Vector3 origenPosition, Func<Grid<TGridObjekt>, int ,int, TGridObjekt>creatGridObjekt)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.origenPosition = origenPosition;

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
                //UtilsClass.CreateWorldText(gridArray[x, y]?.ToString(), null, GetWorldPosition(x, y) + new Vector3(cellSize, cellSize) * .5f, 20, Color.white, TextAnchor.MiddleCenter);
            }
        }
        //Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        //Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
    }

    Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize + origenPosition;
    }

    private void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - origenPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - origenPosition).y / cellSize);
    }

    private void SetValue(Vector3 worldPosition, TGridObjekt Value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, Value);
    }
    public void SetValue(int x, int y, TGridObjekt Value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = Value;
        }
    }

    public TGridObjekt GetValue(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }
        else
        {
            return default(TGridObjekt);
        }
    }
    public TGridObjekt GetValue(Vector3 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetValue(x, y);
    }


}
