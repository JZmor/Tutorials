using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    
    [HideInInspector]
    public float speed;

    public float startHealth = 100;
    private float health;
    public int worth = 50;
    private NavMeshAgent agent;

    public GameObject deathEffect;

    [Header("Unity Stuff")] public Image healthbar;
    
    private bool isDead = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        health = startHealth;
        speed = startSpeed;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthbar.fillAmount = health / startHealth;
        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        agent.speed = startSpeed * (1 - pct);
        speed = startSpeed * (1f - pct);
    }

    void Die()
    {
        isDead = true;
        PlayerStats.Money += worth;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }


}
