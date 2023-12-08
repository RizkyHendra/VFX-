using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_VFX : MonoBehaviour
{
    public Transform bullerSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(bulletPrefab, bullerSpawnPoint.position, bullerSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bullerSpawnPoint.forward * bulletSpeed;
        }
    }
}
