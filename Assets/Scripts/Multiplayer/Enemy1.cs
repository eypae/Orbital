using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Enemy1 : MonoBehaviour
{
    public int health;
    [HideInInspector]
  
    public GameObject[] players;

    public float speed;
    public float timeBetweenAttacks;
    public int damage;

    public int pickupChance;
    public GameObject[] pickups;

    public PhotonView view;
    
    public virtual void Start()
    {
        view = GetComponent<PhotonView>();
        //players = GameObject.FindGameObjectsWithTag("Player");
    }

    public virtual void Update()
    {
       
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    
    public void TakeDamage(int playerDamage)
    {
        if (view.IsMine)
        {
            health -= playerDamage;
            if (health <= 0)
            {
                int randomNumber = Random.Range(0, 101);
                if (randomNumber < pickupChance)
                {
                    GameObject randomPickup = pickups[Random.Range(0, pickups.Length)];
                    PhotonNetwork.Instantiate(randomPickup.name, transform.position, transform.rotation);
                }
                PhotonNetwork.Destroy(gameObject);
            }
        }
    }
}
