using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class WeaponMultiplayer : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotPoint;
    public float timeBetweenShots;
    private float shotTime;
    PhotonView view;

    void Start()
    {
        view = GetComponent<PhotonView>();
    }
    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {

            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            transform.rotation = rotation;

            if (Input.GetMouseButton(0))
            {
                if (Time.time >= shotTime)
                {
                    PhotonNetwork.Instantiate(projectile.name, shotPoint.position, transform.rotation);
                    shotTime = Time.time + timeBetweenShots;
                }
            }
        }
    }
}
