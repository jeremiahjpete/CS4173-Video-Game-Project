using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatCode : MonoBehaviour
{
    private string[] cheatCode;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        // cheat code is "watermelon"
        cheatCode = new string[] { "w","a","t","e","r","m","e","l","o","n" };
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) {
            if (Input.GetKeyDown(cheatCode[index]))
                index++;
            else 
                index = 0;
        }
    }
}
