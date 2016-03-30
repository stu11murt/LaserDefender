using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public float damage = 100f;

    void Hit()
    {
        Destroy(gameObject);

    }

    float GetDamage()
    {
        return damage;
    }
}
