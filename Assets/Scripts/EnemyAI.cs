using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    private Transform target;
    private NavMeshAgent ai;
    private Health enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        ai = GetComponent<NavMeshAgent>();
        ai.updateRotation = false;
        ai.updateUpAxis = false;
        target = GameObject.FindWithTag("Player").transform;
        enemyHealth = GetComponentInChildren<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        ai.SetDestination(target.position);
        if(enemyHealth.hp <= 0)
        {

            Destroy(gameObject);
            ScoreManager.instance.AddScore();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

      if (collision.gameObject.CompareTag("Projectile"))
        {
            enemyHealth.TakeDamage(Random.Range(10f, 20f));
        }

      if (ScoreManager.instance.score >= 3000)
        {
            enemyHealth.TakeDamage(Random.Range(75f, 100f));
        }
        }

    }
