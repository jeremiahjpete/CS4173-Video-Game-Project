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
            anim.SetBool("isAttacking", true);
        } else if (Input.GetKeyUp(KeyCode.R))
            anim.SetBool("isAttacking", false);
    }

    //void OnCollisionEnter(Collision collision) {
        //if (collision.gameObject.tag == "Oni") {
          //  Destroy(collision.gameObject);
        //}
    //}
}
