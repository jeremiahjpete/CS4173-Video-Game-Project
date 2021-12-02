using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float attackRange = 2f;
    public float speed, health;
    public float damage = 1;
    public float attackSpeed = 1f;
    float attackAgain = 0;

    public GameObject Oni;
    Rigidbody oniRb;
    public Transform player;
    public Transform attackPoint;
    public SpawnManager spawn;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start() {
        oniRb = GetComponent<Rigidbody>();
        oniRb.useGravity = false;
        oniRb.isKinematic = true;

        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = attackRange;
        agent.speed = speed;
    }

    // Update is called once per frame
    void Update() {
        if (agent.remainingDistance - attackRange < 0.5f) {
            if (Time.time > attackAgain) {
                attackAgain = Time.time + attackSpeed;
                // Have Oni attack player
                RaycastHit hit;
                if (Physics.Raycast(attackPoint.position, attackPoint.forward, out hit, attackRange)) {
                    if (hit.transform.CompareTag("Player")) {
                        Debug.DrawLine(attackPoint.position, attackPoint.position + attackPoint.forward * attackRange, Color.cyan);
                        GiveDamage(damage);
                    }
                }
            }
        }

        // move towards the player
    }

    public void GiveDamage(float value) {

    }
}
