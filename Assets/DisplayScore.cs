using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class DisplayScore : MonoBehaviour
{

    TextMesh txt;
    private int newScore = 0;

    // Use this for initialization
    void Start()
    {
        txt = gameObject.GetComponent<TextMesh>();
        txt.text = "" + newScore;
    }

    // Update is called once per frame
    void Update()
    {
        if (Board.rowsClearedThisFrame == 1) {
            newScore += 40;
        }
        if (Board.rowsClearedThisFrame == 2)
        {
            newScore += 100;
        }
        if (Board.rowsClearedThisFrame == 3)
        {
            newScore += 300;
        }
        if (Board.rowsClearedThisFrame == 4)
        {
            newScore += 1200;
        }
        if (newScore != 0)
        {
            Board.score += newScore;
            newScore = 0;
            txt.text = "" + Board.score;
            Board.rowsClearedThisFrame = 0;
        }
    }
}