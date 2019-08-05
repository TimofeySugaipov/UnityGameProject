using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int health;
    public Enemy[] Enemies;
    public float SpawnOffSet;
    private int HalfHealth;
    private Animator anim;
    public int damage;
    public GameObject damageEffect;
    private Slider HealthBar;
    private SceneTransition sceneTransitions;

    // Start is called before the first frame update
    void Start()
    {
        HalfHealth = health / 2;
        anim = GetComponent <Animator> ();
        HealthBar = FindObjectOfType<Slider>();
        HealthBar.maxValue = health;
        HealthBar.value = health;
        sceneTransitions = FindObjectOfType<SceneTransition>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        HealthBar.value = health;
        Instantiate(damageEffect, transform.position, Quaternion.identity);
        if (health <= 0)
        {
            HealthBar.gameObject.SetActive(false);
            Destroy(gameObject);
            sceneTransitions.LoadScene("Win");
        }

        if (health <= HalfHealth)
        {
            anim.SetTrigger("Stage2");
        }

        Enemy RandomEnemy = Enemies[Random.Range(0, Enemies.Length)];
        Instantiate(RandomEnemy, transform.position + new Vector3(SpawnOffSet, SpawnOffSet, 1),transform.rotation);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Player>().TakeDamage(damage);
        }
    }
}
