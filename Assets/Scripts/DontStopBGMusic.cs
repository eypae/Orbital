using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontStopBGMusic : MonoBehaviour
{
   void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject); 
    }

    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Game")
        {
            Destroy(gameObject);
        }


        if (currentScene.name == "Multiplayer")
        {
            Destroy(gameObject);
        }


        if (currentScene.name == "GameOver")
        {
            Destroy(gameObject);
        }


        if (currentScene.name == "GameOver1")
        {
            Destroy(gameObject);
        }

    }
}
