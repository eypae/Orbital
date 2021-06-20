using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup1 : MonoBehaviour
{
    Player1 playerScript;
    public int healAmount;

    private void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player1>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerScript.Heal(healAmount);
            Destroy(gameObject);
        }
    }

}
