using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeperScript : MonoBehaviour {

    public int score = 0;
    public int scorePerHit = 2;
    Text scoretxt;

    void Start(){
        
        scoretxt = GetComponent<Text>();
        Reset();
    }
	public void Score(int points)
    {
        score += points;
        
        scoretxt.text = score.ToString();
    }

    public void Reset()
    {
        score = 0;
        scoretxt.text = "0";
    }
}
