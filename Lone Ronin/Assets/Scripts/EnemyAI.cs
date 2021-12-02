using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent Oni; // for navigating through map
    public Transform player;
    public LayerMask isGround, isPlayer;

    // variables for Oni to walk through map
    public Vector3 walk;
    bool walkCheck; // to check if Oni is walking or not
    public float walkRange; // range Oni have to walk

    // variables for Oni to attack player
    public float attackDelay; // time it takes between attacks
    bool hasAttacked; // check if Oni has attacked or not

    // variables to determine which state the Oni are in
    public float attackRange, viewRange;
    public bool playerInAttack, playerInView; // check if player is in attack or view range
    public float health;

    void Start() {
        player = GameObject.FindWithTag("Player").transform;
        Oni = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        // constantly check to see if player is in range
        playerInAttack = Physics.CheckSphere(transform.position, attackRange, isPlayer);
        playerInView = Physics.CheckSphere(transform.position, viewRange, isPlayer);

        // determine which course of action to take depending on how far away player is from Oni
        if (!playerInAttack && !playerInView)
            Walking();
        if (!playerInAttack && playerInView)
            Chase();
        if (playerInAttack && playerInView)
            Attack();
    }

    // function to have Oni walk
    void Walking() {
        float randomX;
        float randomZ;
        if(!walkCheck) {
            // create a random point
            randomX = Random.Range(-walkRange, walkRange);
            randomZ = Random.Range(-walkRange, walkRange);

            walk = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

            if (Physics.Raycast(walk, -transform.up, 2f, isGround))
                walkCheck = true;
        }
        else
            Oni.SetDestination(walk);

        Vector3 distanceToPoint = transform.position - walk;

        // once the point is reached, set walkCheck to false
        if (distanceToPoint.magnitude < 1f)
            walkCheck = false;
            
    }

    // function to chase the player when they come within range
    void Chase() {
        Oni.SetDestination(player.position);
    }

    // function to attack the player
    void Attack() {
        Oni.SetDestination(transform.position); // ensure Oni is stationary while attacking
        transform.LookAt(player);

        if(!hasAttacked) {
            hasAttacked = true;
            Invoke(nameof(ResetAttack), attackDelay);
        }

    }

    void ResetAttack() {
        hasAttacked = false;
    }

    // function for Oni to take damage 
    public void Damage(int damage) {
        health -= damage;

        if (health <= 0)
            Invoke(nameof(DestroyOni), 0.5f);
    }

    private void DestroyOni() {
        Destroy(gameObject);
    }
}
