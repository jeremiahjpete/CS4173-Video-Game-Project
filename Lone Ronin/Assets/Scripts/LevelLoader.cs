using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f; // creating public variables for the transition phases
    public Button startButton; // start button to test and implement scene transition
    
    void Start()
    {
        startButton.onClick.AddListener(TaskOnClick); // when the start button is clicked, add a listener

    }
    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.N))
        {
            LoadNextLevel();
        } 
    }
    

    void TaskOnClick() // when the 'play' button is clicked
    {
        LoadNextLevel(); // load the next level by loading the next scene
    }

    public void LoadNextLevel() // function for when the next level needs to be loaded
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1)); // start a coroutine to transition to the next scene in the scene index
    }

    IEnumerator LoadLevel(int levelIndex) // function that will load the next level in the scene index
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime); // wait for one second of transition time so the menu can be unloaded and the next level can be loaded
        SceneManager.LoadScene(levelIndex); // load the next scene in the scene index

    }
}
