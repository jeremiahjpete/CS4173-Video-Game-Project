using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    private Rigidbody enemyRb;
    private Animator enemyAnim;
    private AudioSource enemyAudio;
    public float movementForce = 1.0f;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool isDead = false;
    public ParticleSystem deathParticle;
    public AudioClip voiceSound;
    public AudioClip deathSound;

    // Start is called before the first frame update
    void Start() {
        enemyRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        enemyAnim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        enemyRb.AddForce(Vector3.forward * movementForce, ForceMode.Impulse);
        isOnGround = false;
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

