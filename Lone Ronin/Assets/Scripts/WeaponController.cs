using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // swing/attack animation trigger
        if (Input.GetKeyDown(KeyCode.R)) {
            //anim.Play("Sword_Swing");
            anim.SetBool("isAttacking", true);
        } else if (Input.GetKeyUp(KeyCode.R))
            anim.SetBool("isAttacking", false);
    }
}
