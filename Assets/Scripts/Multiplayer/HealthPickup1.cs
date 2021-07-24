using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class HealthPickup1 : MonoBehaviour
{
   
    public int healAmount;
    public GameObject heart;
    PhotonView heartPhoton;
    public GameObject sound;
    void Start()
    {
        heart = GameObject.FindGameObjectWithTag("Health");
        heartPhoton = heart.GetComponent<PhotonView>();
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(sound, transform.position, transform.rotation);
            heartPhoton.RPC("Heal", RpcTarget.All, 1);
            Destroy(gameObject);
        }
    }

}
