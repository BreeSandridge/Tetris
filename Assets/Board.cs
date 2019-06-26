using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Board : MonoBehaviour {
    public static bool paused = false;
    public static bool step = false;
    public static bool log = false;
    public static bool changed = false;
    public static int score = 0;
    public static int totalRowsCleared = 0;
    public static int rowsClearedThisFrame = 0;
    public static bool gameOver = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {  
    }
}
