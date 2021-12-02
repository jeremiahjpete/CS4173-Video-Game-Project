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

    // Start is called before the first frame update
    void Start() {
        enemyRb = GetComponent<Rigidbody>();
        enemyAnim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        Player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update() {
        enemyRb.AddForce((Player.transform.position - transform.position).normalized * movementSpeed);
        transform.LookAt(Player);
        if (Vector3.Distance(transform.position, Player.position) >= 0.5) {
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
            
            if (Vector3.Distance(transform.position, Player.position) <= 0.5) {
                // play attack animation
                enemyAnim.Play("Z_Attack");
                // play voiceSound audio
                enemyAudio.PlayOneShot(voiceSound, 1.0f);
            }
            else {
                enemyAnim.Play("Z_Run_InPlace");
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Weapon")) {
            isDead = true;
            Debug.Log("Enemy Hit!");
            enemyAnim.SetBool("Death_b", true);
            enemyAnim.SetInteger("DeathType_int", 1);
            TakeDamage(1);
            // play death animations and audio sounds
            //deathParticle.Play();
            enemyAudio.PlayOneShot(deathSound, 1.0f);
        }
    }

    private void AttackPlayer() {
        enemyAnim.Play("Z_Attack");
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

        if (health <= 0)
            Invoke(nameof(DestroyOni), 2f);
    }

    private void DestroyOni() {
        enemyAnim.Play("Z_FallingBack");
        Destroy(gameObject);
    }
}

