using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject titleScreen;
    public bool isGameActive;

    public void StartGame() {
        titleScreen.gameObject.SetActive(false);
        isGameActive = true;
    }

    public void Options() {
        titleScreen.gameObject.SetActive(false);
    }
}
