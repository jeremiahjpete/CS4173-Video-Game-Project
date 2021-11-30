using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseScene;
    public static bool isPaused = false;

    // Update is called once per frame
    private void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            if (isPaused) {
                Play();
            }
            else {
                Pause();
            }
        }
    }

    // function to pause the game
    public void Pause() {
        isPaused = true;
        pauseScene.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("Pause Button Pushed");
    }

    // function to resume playing game
    public void Play() {
        pauseScene.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    // function to return to main menu
    public void ReturnMenu(int ID) {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(ID);
    }
}
