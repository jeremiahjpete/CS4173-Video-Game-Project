using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleButtons : MonoBehaviour
{
    private Button button; // for assigning button objects
    private GameManager gameManager;

    public int buttonChoice;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ButtonChosen);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // create listener to help distinguish which button is chosen
    void ButtonChosen()
    {
        Debug.Log(gameObject.name + " was clicked");
    }
}
