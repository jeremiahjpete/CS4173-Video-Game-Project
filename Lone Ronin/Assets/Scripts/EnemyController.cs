using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    private Rigidbody enemyRb;
    private GameObject player; // for enemies to follow player
    private Animator enemyAnim;
    private AudioSource enemyAudio;

    public float speed;
    //public float gravityModifier;
    public bool isDead = false;
    public ParticleSystem deathParticle;
    public AudioClip voiceSound;
    public AudioClip deathSound;

    // Start is called before the first frame update
    void Start() {
        enemyRb = GetComponent<Rigidbody>();
        //Physics.gravity *= gravityModifier;
        enemyAnim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update() {
        enemyRb.AddForce((player.transform.position - transform.position).normalized * speed);
        // play voiceSound audio
        //enemyAudio.PlayOneShot(voiceSound, 1.0f);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Weapon")) {
            isDead = true;
            Debug.Log("Game Over!");
            enemyAnim.SetBool("Death_b", true);
            enemyAnim.SetInteger("DeathType_int", 1);
            // play death animations and audio sounds
            //deathParticle.Play();
            //enemyAudio.PlayOneShot(deathSound, 1.0f);
        }
    }
}

