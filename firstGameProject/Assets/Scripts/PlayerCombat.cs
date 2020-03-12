using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public LayerMask enemyLayers;
    public Transform attackPoint;
    public Animator animator;
    public PlayerController controller;

    //Character progression
    public int attackDamage = 30;
    public int maximumHealth = 100;
    public int currentHealth;
    public int level = 1;
    public int xpToNext = 100;
    public int xpCurrent = 0;
    //Attack value
    public float attackRange = 0.3f;
    public float attackSpeed = 2f;
    float nextAttackTime = 0f;

    private void Start()
    {
        currentHealth = maximumHealth;
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackSpeed;
            }
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        //controller.AttackState();

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyCombat>().TakeDamage(attackDamage);
        }
    }

    public void GetExperience(int experience)
    {

        if(xpCurrent >= xpToNext)
        {
            xpCurrent -= xpToNext;
            level++;
            xpToNext = 100 * level;
            attackDamage += 5;
            maximumHealth += 10;
            currentHealth = maximumHealth;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
