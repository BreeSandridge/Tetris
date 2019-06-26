using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// CLASS NOT CALLED GRID BECAUSE OF CONFLICTS WITH GAME ENGINE FILE
public class Lattice : MonoBehaviour {
    
    // The Grid itself
    public static int width = 10;
    public static int height = 24;
    //comma used to make a 2D transformation
    public static Transform[,] grid = new Transform[width, height];

    //rounds the numbers of the vector
    public static Vector2 roundVec2(Vector2 v)
    {
        return new Vector2(Mathf.Ceil(v.x),
                           Mathf.Ceil(v.y));
    }

    //makes sure it is inside the grid
    public static bool insideBorder(Vector2 pos)
    {
        return ((int)pos.x < 10 &&
                (int)pos.x >= 0 &&
                (int)pos.y >= 0);
    }

    //deletes a row (for full entry)
    public static void deleteRow(int y)
    {
        for (int x = 0; x < width; x++) {
            Destroy(grid[x, y].gameObject);
            grid[x, y] = null;
        }
        Board.rowsClearedThisFrame++;
    }

    // makes rows fall down
    public static void decreaseRow(int y)
    {
        for (int x = 0; x < width; ++x)
        {
            if (grid[x, y] != null)
            {
                // Move one towards bottom
                grid[x, y - 1] = grid[x, y];
                grid[x, y] = null;

                // Update Block position
                grid[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

    public static void decreaseRowsAbove(int y)
    {
        for (int i = y; i < height; ++i)
            decreaseRow(i);
    }

    public static bool isRowFull(int y)
    {
        for (int x = 0; x < width; x++)
            if (grid[x, y] == null) {
                return false;
            }
        return true;
    }


    public static bool isPointFull(int x, int y) {
        if (grid[x, y] != null) {
            return true;
        }
        return false;
    }

    public static void deleteFullRows()
    {
        for (int y = 0; y < height; ++y)
        {
            if (isRowFull(y))
            {
                deleteRow(y);
                decreaseRowsAbove(y + 1);
                --y;
            }
        }
    }

    public static void deleteAllRows()
    {
        for (int y = 0; y < height; ++y)
        {

            deleteRow(y);
            decreaseRowsAbove(y + 1);
            --y;
         
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
