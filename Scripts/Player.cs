using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    public int health;

    private Rigidbody2D rb;
    private Animator anim;

    private Vector2 moveAmount;
    public Image[] hearts;
    public Sprite FullHeart;
    public Sprite EmptyHeart;
    public Animator HurtAnim;


    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveAmount = moveInput.normalized * speed;

        if (moveInput != Vector2.zero)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveAmount*Time.fixedDeltaTime);
    }
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        HurtAnim.SetTrigger("Hurt");
        UpdateHealthUI(health);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void ChangeWeapon(Weapon WeaponToEquip)
    {
        Destroy(GameObject.FindGameObjectWithTag("Weapon"));
        Instantiate(WeaponToEquip, new Vector2(transform.position.x - 32, transform.position.y + 5), transform.rotation, transform);
    }

    public void UpdateHealthUI(int currentHealth)
    {
       for (int i = 0; i < hearts.Length; i++)
        {
            if (i< currentHealth)
            {
                hearts[i].sprite = FullHeart;
            } else
            {
                hearts[i].sprite = EmptyHeart;
            }
        }
    }
    public void Heal(int HealAmount)
    {
        if(health + HealAmount <= 5)
        {
            health += HealAmount;
            UpdateHealthUI(health);
        } else
        {
            health = 5;
            UpdateHealthUI(health);
        }
        
    }
}
