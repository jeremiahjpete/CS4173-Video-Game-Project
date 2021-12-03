using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Transform parent;
    public GameObject baseSword;
    public GameObject watermelonSword;
    public bool isCheat;
    private CheatCode cheatCode;

    // Start is called before the first frame update
    void Start()
    {
        if (isCheat == true) {
            Instantiate(watermelonSword, parent, false);
            Debug.Log("isCheat: " + isCheat);
        } else {
            Instantiate(baseSword, parent, false);
            Debug.Log("isCheat: " + isCheat);
        }
    }

    public void ChooseSword(bool cheat) {
        if (cheat == true) {
            Instantiate(watermelonSword, parent, false);
            Debug.Log("isCheat: " + isCheat);
        } 
        else {
            Instantiate(baseSword, parent, false);
            Debug.Log("isCheat: " + isCheat);
        }
    }
}
