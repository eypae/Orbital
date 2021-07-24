using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmount;
    public GameObject sound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(sound, transform.position, transform.rotation);
            collision.GetComponent<Player>().Heal(healAmount);
            Destroy(gameObject);
        }
    }
}
