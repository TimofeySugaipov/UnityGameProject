using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    Player PlayerScript;

    public int HealAmount;
    public GameObject pickUpEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerScript.Heal(HealAmount);
            Instantiate(pickUpEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    private void Start()
    {
        PlayerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
