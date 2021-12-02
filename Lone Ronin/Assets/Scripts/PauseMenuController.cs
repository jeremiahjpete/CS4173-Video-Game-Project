using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) {
            if(!isPaused) {
                Pause();
            }
        }
    }

    // function to resume playing the game
    public void Play() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    // function to pause the game
    void Pause() {
        // Give player control over mouse back
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        // Show pause screen
        pauseMenu.SetActive(true);
        // remove movement
        Time.timeScale = 0f;
        isPaused = true;
        Debug.Log("Pause Button Pressed");
    }

    // function to quit game
    public void QuitGame(int scene) {
        // Make mouse visible
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene);
    }
}
