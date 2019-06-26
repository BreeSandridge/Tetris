using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    // Groups (Tetriminos
    public GameObject[] groups;
    public GameObject[] noScriptGroups;



    // Method that spawns next tetrimino
    public void spawnNext() {
        int i = Random.Range(0, groups.Length);
        // Spawn random tetramino
        Instantiate(groups[i], transform.position, Quaternion.identity);
        //Instantiate(noScriptGroups[i], transform.position, Quaternion.identity);

        //i = Random.Range(0, groups.Length);
        //FindObjectOfType<NextSpawner>().SpawnNext(i);
    }

    private void spawnFirst()
    {
        // Gets a random number to index
        int i = Random.Range(0, groups.Length);

        // Spawn random tetramino
        Instantiate(groups[i], transform.position, Quaternion.identity);
        //Instantiate(noScriptGroups[i], transform.position, Quaternion.identity);

        // gets next for placeHolder
        i = Random.Range(0, groups.Length);

    }





    // Use this for initialization
    void Start () {
        // spawn initail tetrimino
        spawnFirst();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
