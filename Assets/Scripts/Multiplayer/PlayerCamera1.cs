using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera1 : MonoBehaviour
{
    public Transform player1;
    public float speed;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public int count = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (count < 1)
        {
            player1 = GameObject.FindGameObjectWithTag("Player").transform;
            count++;
        }
        if (player1 != null)
        {
            float clampedX = Mathf.Clamp(player1.position.x, minX, maxX);
            float clampedY = Mathf.Clamp(player1.position.y, minY, maxY);
            transform.position = Vector2.Lerp(transform.position, new Vector2(clampedX,clampedY), speed);
        }
    }
}
