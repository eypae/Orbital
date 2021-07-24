using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;

    public GameObject explosion;
    public Transform player;
    public int damage;

    public GameObject shootsound;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Invoke("DestroyProjectile", lifeTime);
        Instantiate(shootsound, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
      
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        
    }


    void DestroyProjectile()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Decoy")
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
            player.GetComponent<Player>().TakeDamage(1);

            DestroyProjectile();
        }
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
            DestroyProjectile();
        }
        if (collision.tag == "Boss")
        {
            collision.GetComponent<Boss>().TakeDamage(damage);
            DestroyProjectile();
        }
    }
}
