using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
public class PauseMenu1 : MonoBehaviourPunCallbacks
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    PhotonView view;
    
    void Start()
    {
        view = GetComponent<PhotonView>();
    }
    // Update is called once per frame
    void Update()
    {
        //if (PhotonNetwork.IsMasterClient)
        //{
            if (Input.GetKeyDown(KeyCode.P))
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    view.RPC("Pause",RpcTarget.All);
                }
            }
        //}
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        PhotonNetwork.LoadLevel("Menu");
    }

    [PunRPC]
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
