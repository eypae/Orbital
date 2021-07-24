using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class WeaponSpeedUp : MonoBehaviour
{
  //  public GameObject sound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
         ///   Instantiate(sound, transform.position, transform.rotation);
            collision.GetComponent<Player1>().UpWeaponSpeed();
            Destroy(gameObject);

        }
    }

}
