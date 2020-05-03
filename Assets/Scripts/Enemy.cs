using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int maxHealth;
    int currentHealth;
    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        animator.SetTrigger("Hurt");
        currentHealth -= damage;
        Debug.Log("Enemy Damaged");
        //play hurt animation

        if (currentHealth <= 0)
        {
            
            Die();
        }
    }

    void Die()
    {
        //Die animation
        animator.SetBool("isDead", true);
        //Disable Enemey
        GetComponent<Collider2D>().enabled = false;
        enabled = false;
        Debug.Log("Enemy Died.");
    }
}
