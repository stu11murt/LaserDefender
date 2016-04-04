using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public float health = 150f;
    public GameObject enemyProjectile;
    public float projectileSpeed = 10f;
    public int scoreValue = 150;
    ScoreKeeperScript scoreScript;

    private float fireTime = 0.00001f;
    private float fireRate = 1f;
    public float shotsPerSecond = 0.5f;

    public AudioClip enemyZap;
    public AudioClip enemyDeath;

    void Start()
    {
       
        scoreScript = GameObject.Find("HighScore").GetComponent<ScoreKeeperScript>();
        
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
                scoreScript.Score(scoreValue);
                AudioSource.PlayClipAtPoint(enemyDeath, transform.position);
                Destroy(gameObject);
            }
             
        }
        
    }

    void Update()
    {
        float probability = Time.deltaTime * shotsPerSecond;
        if (Random.value < probability)
        {
            Fire();
        }
        
    }

    void Fire()
    {
        Vector3 startPosition = transform.position + new Vector3(0, 0, 0);
        GameObject enemyLaser = Instantiate(enemyProjectile, startPosition, Quaternion.identity) as GameObject;
        Rigidbody2D enemyRigid = enemyLaser.GetComponent<Rigidbody2D>();
       
        //Debug.Log(enemyRigid);
        enemyRigid.velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(enemyZap, transform.position);
    }

    
}
