using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float explosionDelay = 2f;
    public float explosionRadius = 3f;
    public int explosionDamage = 50;
    public GameObject explosionEffect;

    void Start()
    {
        Invoke("Explode", explosionDelay);
    }

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (Collider2D enemy in enemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                // Aquí puedes aplicar daño al enemigo
            }
        }

        Destroy(gameObject);
    }
}
