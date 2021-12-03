using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheatCode : MonoBehaviour
{
    public WeaponManager weapon;
    public InputField input;
    public TextMeshProUGUI text;

    void Start() {
        text.gameObject.SetActive(false);
        input.gameObject.SetActive(true);
    }

    public void CheckCheat()
    {
        if (input.text == "watermelon" || input.text == "Watermelon") {
            Debug.Log("Cheat Code Successful!");
            weapon.isCheat = true;
        }
    }
}
