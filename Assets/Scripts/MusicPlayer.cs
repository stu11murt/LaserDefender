using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
    static MusicPlayer instance = null;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
        Debug.Log("Music Player Awake - id code: " + GetInstanceID());
    }
	// Use this for initialization
    void Start()
    {
        Debug.Log("Music Player Start - id code: " + GetInstanceID());
        

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
