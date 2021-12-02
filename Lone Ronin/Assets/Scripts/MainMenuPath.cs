using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuPath : MonoBehaviour
{
    private void Start() {
        // Give player control over mouse back
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ExitToMain() {
        SceneManager.LoadScene(0);
    }
}
