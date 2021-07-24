using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Pickup1 : MonoBehaviour
{
    public GameObject weaponToEquip;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player1>().ChangeWeapon(weaponToEquip);
            Destroy(gameObject);
        }

    }
}
