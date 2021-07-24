using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroymusic : MonoBehaviour
{
    public Transform player;

   void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            Destroy(gameObject);
        }
        
    }
}
