using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int enemyCount;
    public TextMeshProUGUI countText;

    void Start() {
        countText.text = "Enemies Remaining: " + enemyCount;
    }
}
