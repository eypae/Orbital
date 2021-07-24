using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    public GameObject sound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(sound, transform.position, transform.rotation);
            collision.GetComponent<Player>().SpeedUp();
            Destroy(gameObject);
        }
    }
}
