using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public float health = 150f;
    public Projectile projectile;
    public float projectileSpeed = 2f;

    private float fireTime = 0.00001f;
    private float fireRate = 0.2f;

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
