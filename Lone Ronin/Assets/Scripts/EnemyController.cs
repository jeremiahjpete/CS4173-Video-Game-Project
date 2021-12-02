using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    private Rigidbody enemyRb;
    private Animator enemyAnim;
    private AudioSource enemyAudio;
    private Transform Player; // for enemies to follow player
    public float movementSpeed;
    public float attackDelay = 1f;
    public float health;
    public bool isDead = false;
    bool hasAttacked = false;
    public ParticleSystem deathParticle;
    public AudioClip voiceSound;
    public AudioClip deathSound;
    private SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start() {
        enemyRb = GetComponent<Rigidbody>();
        enemyAnim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        Player = GameObject.FindWithTag("Player").transform;
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update() {
        enemyRb.AddForce((Player.transform.position - transform.position).normalized * movementSpeed);
        transform.LookAt(Player);
        if (Vector3.Distance(transform.position, Player.position) >= 0.25 && isDead == false) {
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
            
            if (Vector3.Distance(transform.position, Player.position) <= 0.25 && isDead == false) {
                AttackPlayer();
            }
            else if (isDead == true) {
                enemyAnim.Play("Z_FallingBack");
            }
            else {
                enemyAnim.Play("Z_Run_InPlace");
            }
        }
        
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Weapon") {
            TakeDamage(1);
        }
    }

    private void AttackPlayer() {
        // play attack animation
        enemyAnim.Play("Z_Attack");
        // play voiceSound audio
        enemyAudio.PlayOneShot(deathSound, 1.0f);
        transform.LookAt(Player);

        if (!hasAttacked) {
            hasAttacked = true;
            Invoke(nameof(ResetAttack), attackDelay);
        }
    }

    private void ResetAttack() {
        hasAttacked = false;
    }

    public void TakeDamage(int damage) {
        health -= damage;
        Debug.Log("Enemy Hit!");

        if (health == 0) {
            isDead = true;
            enemyAnim.Play("Z_FallingBack");
            Invoke(nameof(DestroyOni), 2f);
        }
    }

    private void DestroyOni() {
        Destroy(gameObject);
        spawnManager.UpdateCount(1);
        // play death animations and audio sounds
        //deathParticle.Play();
        //enemyAudio.PlayOneShot(deathSound, 1.0f);
    }
}

