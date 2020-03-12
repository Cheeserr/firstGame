using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public Animator animator;

    public int maximumHealth = 100;
    public int currentHealth;
    public int healthRegen = 10;

    public float healthRegenRatio = 0.5f;
    public float healthRegenTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maximumHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= healthRegenTime)
        {
            currentHealth += healthRegen;
            healthRegenTime = Time.time + 1f / healthRegenRatio;
        }

    }

    public void TakeDamage(int damage)
    {
        animator.SetTrigger("Hurt");
        currentHealth -= damage;
        healthRegenTime = Time.time + 2f / healthRegenRatio;
        if (currentHealth <= 0)
            Die();
    }

    void Die()
    {
        animator.SetBool("IsDead", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

    }
}
