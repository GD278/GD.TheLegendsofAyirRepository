using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    //Adapted from Brackey's Tutorial which can be found here: https://www.youtube.com/watch?v=sPiVz1k-fEs
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public int attackDamage = 40;
   [SerializeField] private float attackRate;
    private float attackTime;
    [SerializeField]
   [Range(0, 10)]
    private float attackRange = 0.5f;
    // Update is called once per frame
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
            Debug.Log("Enemy Hit.");
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
