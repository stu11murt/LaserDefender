using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D coll)
    {
        Projectile proj = coll.gameObject.GetComponent<Projectile>();
        if (proj)
        {
            Debug.Log("Hit by a projecteile");    
        }
        
    }
}
