using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name)
    {
        Debug.Log(name + " is the levle requested");
        Application.LoadLevel(name);
    }

    public void QuitRequest()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }


    public void ReturnToStart(){
        Application.LoadLevel("Start");
    }

    public void LoadNextLevel(){
        Application.LoadLevel(Application.loadedLevel + 1);
    }

	
}
