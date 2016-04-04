using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float moveSpeed = 3.0f;
    public float padding = 0.5f;
    float xmin;
    float xmax;
    public GameObject projectile;
    public float projectileSpeed;
    public float health = 250f;

    public float fireTime = 0.00001f;
    public float fireRate = 0.2f;

    public AudioClip zap;

	// Use this for initialization
	void Start () {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftMost.x + padding;
        xmax = rightMost.x - padding;
        
	}

    void Fire()
    {
        Vector3 offset = new Vector3(0, 1, 0);
        GameObject beam = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        Rigidbody2D rigiBeam = beam.GetComponent<Rigidbody2D>();
        rigiBeam.velocity = new Vector3(0, projectileSpeed, 0);
        AudioSource.PlayClipAtPoint(zap, transform.position);
    }

	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Space))
	    {

	        InvokeRepeating("Fire", fireTime, fireRate);
	    }

	    if (Input.GetKeyUp(KeyCode.Space))
	    {
	        CancelInvoke("Fire");
	    }

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

    void OnTriggerEnter2D(Collider2D coll)
    {

        Projectile proj = coll.gameObject.GetComponent<Projectile>();
        if (proj)
        {
            health -= proj.GetDamage();
            if (health <= 0)
            {
                proj.Hit();
                Destroy(gameObject);
            }

        }

    }
}
