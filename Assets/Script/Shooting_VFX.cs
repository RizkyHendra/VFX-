using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_VFX : MonoBehaviour
{
    public Transform bullerSpawnPointOne, bullerSpawnPointTwo, bullerSpawnPointThree, bullerSpawnPointFour;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bulletOne = Instantiate(bulletPrefab, bullerSpawnPointOne.position, bullerSpawnPointOne.rotation);
            bulletOne.GetComponent<Rigidbody>().velocity = bullerSpawnPointOne.forward * bulletSpeed;

            var bulletTwo = Instantiate(bulletPrefab, bullerSpawnPointTwo.position, bullerSpawnPointTwo.rotation);
            bulletTwo.GetComponent<Rigidbody>().velocity = bullerSpawnPointTwo.forward * bulletSpeed;

            var bulletThree = Instantiate(bulletPrefab, bullerSpawnPointThree.position, bullerSpawnPointThree.rotation);
            bulletThree.GetComponent<Rigidbody>().velocity = bullerSpawnPointThree.forward * bulletSpeed;

            var bulletFour = Instantiate(bulletPrefab, bullerSpawnPointFour.position, bullerSpawnPointFour.rotation);
            bulletFour.GetComponent<Rigidbody>().velocity = bullerSpawnPointFour.forward * bulletSpeed;
        }
    }
}
