using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float moveSpeed = 3.0f;
    public float padding = 0.5f;
    float xmin;
    float xmax;
	// Use this for initialization
	void Start () {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftMost.x + padding;
        xmax = rightMost.x - padding;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //this.transform.position = new Vector3(this.transform.position.x + moveSpeed * Time.smoothDeltaTime, this.transform.position.y);
            //transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //this.transform.position = new Vector3(this.transform.position.x - moveSpeed * Time.smoothDeltaTime, this.transform.position.y);
            //transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0,0);
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);

        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}
}
