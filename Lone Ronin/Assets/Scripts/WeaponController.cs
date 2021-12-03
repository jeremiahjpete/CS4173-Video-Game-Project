using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    Animator anim;
    private AudioSource swordSound;
    public AudioClip swordSwing;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        swordSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // swing/attack animation trigger
        if (Input.GetKeyDown(KeyCode.R)) {
            anim.SetBool("isAttacking", true);
            swordSound.PlayOneShot(swordSwing, 1.0f);
        } else if (Input.GetKeyUp(KeyCode.R))
            anim.SetBool("isAttacking", false);
    }
}
