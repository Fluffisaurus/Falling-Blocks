using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //for public text variable
using UnityEngine.SceneManagement; //for SceneManager

public class GameOver : MonoBehaviour {

    public GameObject gameOverScreen;
    public Text secondsSurvivedUI;
    bool gameOver;

	// Use this for initialization
	void Start () {
        FindObjectOfType<PlayerController>().OnPlayerDeath += OnGameOver; //subscribes this onto event
	}
	
	// Update is called once per frame
	void Update () {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0); //default = 0
            }
        }
	}

    void OnGameOver()
    {
        gameOverScreen.SetActive(true);
        secondsSurvivedUI.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
        gameOver = true;
    }
}
