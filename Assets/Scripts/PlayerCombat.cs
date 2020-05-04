using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    //Adapted from Brackey's Tutorial which can be found here: https://www.youtube.com/watch?v=sPiVz1k-fEs
    [SerializeField] public int maxHealth;
    PlayerController controller;
    int currentHealth;
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public int attackDamage;
   [SerializeField] private float attackRate;
    private float attackTime;
    [SerializeField]
   [Range(0, 10)]
    private float attackRange = 0.5f;
    // Update is called once per frame
    private void Start()
    {
        currentHealth = maxHealth;
        controller = GetComponent<PlayerController>();
        animator.enabled = true;
    }
    void Update()
    {
        if (Time.time >= attackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                attackTime = Time.time + 1f / attackRate;
            }
            
        }
        else if (Time.time >= attackTime)
        {
            if (Input.GetMouseButtonDown(1))
            {
                BowAim();
                attackTime = Time.time + 1f / attackRate;
            }

        }
    }
    public void TakeDamage(int damage)
    {
        animator.SetTrigger("Hurt");
        currentHealth -= damage;
        Debug.Log("Player Damaged");
        //play hurt animation

        if (currentHealth <= 0)
        {

            Die();
        }
    }
    void Attack()
    {
        //Play an attack animation:
        animator.SetTrigger("Attack");
        Debug.Log("Attack anim set.");
        //Detect Enemies in Front of Attack
        Collider2D [] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        Debug.Log("Collider2D set up.");

        //Damage Enemy
        foreach(Collider2D enemy in hitEnemies)
        {
            attackDamage = Random.Range(1, 40);
            Debug.Log("Enemy Hit.");
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            
        }
    }
    private void BowAim()
    {


    }
    private void Die()
    {
        //Die animation
        animator.SetTrigger("isDead");
        controller.enabled = false;
        
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
