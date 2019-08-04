using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public Transform player;

    public int health;

    public float speed;

    public float TimeBetweenAttacks;

    public int damage;

    public int PickUpChance;

    public GameObject[] PickUps;

    public int HealthPickUpChance;

    public GameObject HealthPickUp;

    public GameObject deathEffect;


    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if(health <= 0)
        {
            int RandomNumber = Random.Range(0, 101);
            if (RandomNumber < PickUpChance)
            {
                GameObject RandomPickUp = PickUps[Random.Range(0, PickUps.Length)];
                Instantiate(RandomPickUp, transform.position, transform.rotation);
            }
            int RandomHealth = Random.Range(0, 101);
            if (RandomHealth < HealthPickUpChance)
            {
                Instantiate(HealthPickUp, transform.position, transform.rotation);
            }
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            
        }
    }
    // Start is called before the first frame update
    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;


    }

}
