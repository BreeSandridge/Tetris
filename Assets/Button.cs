using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {

    public void OnStart() {
        SceneManager.LoadScene("Game");
        Debug.Log("sprite clicked");
    }


    public void OnQuit()
    {
        Application.Quit();
    }

    public void OnReset()
    {
        SceneManager.LoadScene("Game");
    }
}
