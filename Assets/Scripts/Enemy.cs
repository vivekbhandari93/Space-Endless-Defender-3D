using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Collider boxCollider;

    [SerializeField] GameObject deathVFX;

    DamageDealer damageDealer;
    Health health;


    private void Start()
    {
        AddCollider();
        damageDealer = GetComponent<DamageDealer>();
        health = GetComponent<Health>();
    }

    private void AddCollider()
    {
        boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {

        if (!damageDealer) { return; }
        if (!health) { return; }
        health.ReduceHealth(damageDealer.GetDamage());

        if (health.GetHealth() <= 0)
        {
            FindObjectOfType<ScoreBoard>().AddScores();
            Killed();
        }
    }

    private void Killed()
    {
        Instantiate(deathVFX, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
