using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnManager : MonoBehaviour
{
    public GameObject playerPrefab;
    //public GameObject SceneCamera;
    public GameObject Canvas;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
        Canvas.SetActive(true);
    }

    // Update is called once per frame
    void SpawnPlayer()
    {
        PhotonNetwork.Instantiate(playerPrefab.name, playerPrefab.transform.position, playerPrefab.transform.rotation);
        Canvas.SetActive(false);
        //SceneCamera.SetActive(false);
    }
}
