using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplayerCounter : MonoBehaviour
{

    float startingTime = 0f;
    float currentTime = 0f;
    float endTime = 0f;

    public Transform player1;
    float longestTime;

    public Text currentScore;
    public Text highScore;
    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player").transform;
        currentTime = startingTime;
        longestTime = PlayerPrefs.GetFloat("Multiplayer", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (player1 != null)
        {
            if (currentTime < longestTime)
            {
                currentTime += 1 * Time.deltaTime;
                currentScore.text = "Score: " + currentTime.ToString("0");
                highScore.text = "HighScore: " + longestTime.ToString("0");
            }
            else
            {
                currentTime += 1 * Time.deltaTime;
                longestTime += 1 * Time.deltaTime;
                currentScore.text = "Score: " + currentTime.ToString("0");
                highScore.text = "HighScore: " + longestTime.ToString("0");
            }
        }
        else
        {
            endTime = currentTime;
            currentScore.text = "Score: " + endTime.ToString("0");
            highScore.text = "HighScore: " + longestTime.ToString("0");
            if (longestTime <= endTime)
            {
                PlayerPrefs.SetFloat("Multiplayer", endTime);
            }
        }
    }
}


