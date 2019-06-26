using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayRowsCleared : MonoBehaviour {

    TextMesh txt;

    // Use this for initialization
    void Start()
    {
        txt = gameObject.GetComponent<TextMesh>();
        txt.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "" + Board.totalRowsCleared;
    }
}
