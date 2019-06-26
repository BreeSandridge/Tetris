using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Group : MonoBehaviour {

    public float lastFall = 0.0f;
    //public static float x_pos = 0;
    //public static float y_pos = 0;
    


    bool isValidGridPos() {
        foreach (Transform child in transform)
        {
            Vector2 v = Lattice.roundVec2(child.position);

            // Not inside Border?
            if (!Lattice.insideBorder(v)) {
                return false;
            }
            // Block in grid cell (and not part of same group)?
            if (Lattice.grid[(int)v.x, (int)v.y] != null &&
                Lattice.grid[(int)v.x, (int)v.y].parent != transform) {
                return false;
            }
        }
        return true;
    }

    void updateGrid()
    {
        // Remove old children from grid
        for (int y = 0; y < Lattice.height; ++y)
            for (int x = 0; x < Lattice.width; ++x)
                if (Lattice.grid[x, y] != null)
                    if (Lattice.grid[x, y].parent == transform)
                        Lattice.grid[x, y] = null;

        // Add new children to grid
        foreach (Transform child in transform) {
            Vector2 v = Lattice.roundVec2(child.position);
            Lattice.grid[(int)v.x, (int)v.y] = child;
        }
    }




    // Use this for initialization
    void Start () {
        // Default position not valid? Then it's game over
        if (!isValidGridPos()) {
            
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }





    // Update is called once per frame
    void Update() {
        //x_pos = transform.position.x;
        //y_pos = transform.position.y;
        // Move Left
        for (int i = 0; i < 10; i++) {
            if (Lattice.grid[i, 23] != null)
            {
                SceneManager.LoadScene("GameOver");
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Modify position
            transform.position += new Vector3(-1, 0, 0);

            // See if valid
            if (isValidGridPos()) {
                // It's valid. Update grid.
                updateGrid();
            } else {
                // It's not valid. revert.
                transform.position += new Vector3(1, 0, 0);
            }
            Board.changed = true;
        }
        // Move Right
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // Modify position
            transform.position += new Vector3(1, 0, 0);

            // See if valid
            if (isValidGridPos())
            {
                // It's valid. Update grid.
                updateGrid();
            }
            else
            {
                // It's not valid. revert.
                transform.position += new Vector3(-1, 0, 0);
            }

            Board.changed = true;
        }



        // Rotate
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            transform.Rotate(0, 0, -90);

            // See if valid
            if (isValidGridPos()) {
                // It's valid. Update grid.
                updateGrid();
            } else {
                // It's not valid. revert.
                transform.Rotate(0, 0, 90);
            }
            Board.changed = true;
        }

        // Move Downwards and Fall
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - lastFall > .5 && !Board.step && !Board.paused) {
            // Modify position
            transform.position += new Vector3(0, -1, 0);

            // See if valid
            if (isValidGridPos()) {
                // It's valid. Update grid.
                updateGrid();
            } else {
                // It's not valid. revert.
                transform.position += new Vector3(0, 1, 0);

                // Clear filled horizontal lines
                Lattice.deleteFullRows();

                // Spawn next Group
                FindObjectOfType<Spawner>().spawnNext();

                // Disable script
                enabled = false;
            }

            lastFall = Time.time;
            Board.changed = true;
        }
        // Steps through the falling
        else if (Input.GetKeyDown(KeyCode.DownArrow) && Board.step) {
            // Modify position
            transform.position += new Vector3(0, -1, 0);

            // See if valid
            if (isValidGridPos()) {
                // It's valid. Update grid.
                updateGrid();
            } else {
                // It's not valid. revert.
                transform.position += new Vector3(0, 1, 0);

                // Clear filled horizontal lines
                Lattice.deleteFullRows();

                // Spawn next Group
                FindObjectOfType<Spawner>().spawnNext();

                // Disable script
                enabled = false;
            }
            Board.changed = true;
        }
        // Hard Drop
        else if (Input.GetKeyDown(KeyCode.B)) {
            bool dropping = true;
            while (dropping) {
                // Modify position
                transform.position += new Vector3(0, -1, 0);

                // See if valid
                if (isValidGridPos())
                {
                    // It's valid. Update grid.
                    updateGrid();
                }
                else
                {
                    // It's not valid. revert.
                    transform.position += new Vector3(0, 1, 0);

                    // Clear filled horizontal lines
                    Lattice.deleteFullRows();

                    // Spawn next Group
                    FindObjectOfType<Spawner>().spawnNext();

                    // Disable script
                    enabled = false;

                    dropping = false;
                }
            }

        }

        if (Board.log && Board.changed) {
            // Add new children to grid
            foreach (Transform child in transform)
            {
                Vector2 v = Lattice.roundVec2(child.position);

            }
        }


        //pauses game
        if (Input.GetKeyDown(KeyCode.Space)) {
            Board.paused = !Board.paused;
        }else if (Input.GetKeyDown(KeyCode.P)) {
            Board.step = !Board.step;
        }
        if (Input.GetKeyDown(KeyCode.L)) {
            Board.log = !Board.log;
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        Board.changed = false;

        Board.totalRowsCleared += Board.rowsClearedThisFrame;
    }
}
