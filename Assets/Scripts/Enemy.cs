using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int maxHealth;
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
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] GameObject combatTrigger;
    AudioSource source;
    [SerializeField] private AudioClip death;
    EnemyCombatTrigger enemyCombatTrigger;
    
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        currentHealth = maxHealth;
        enemyCombatTrigger = combatTrigger.GetComponent<EnemyCombatTrigger>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCombatTrigger.inCombat)
        {
            if (Time.time >= attackTime)
            {
                Attack();
                attackTime = Time.time + 1f / attackRate;
            }
        }
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
        //Play death sound
        source.clip = death;
        source.Play();
        //Die animation
        animator.SetBool("isDead", true);
        //Disable Enemey
        GetComponent<Collider2D>().enabled = false;
        enabled = false;
        Debug.Log("Enemy Died.");
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        Debug.Log("Attack anim set.");
        //Detect Enemies in Front of Attack
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        Debug.Log("Collider2D set up.");

        //Damage Enemy
        foreach (Collider2D player in hitPlayer)
        {
            attackDamage = Random.Range(1, 40);
            Debug.Log("Player Hit.");
            player.GetComponent<PlayerCombat>().TakeDamage(attackDamage);

        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
