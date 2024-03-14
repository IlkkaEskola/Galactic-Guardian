using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    public GameObject laserPrefab;
    public Transform laserSpawnPoint1, laserSpawnPoint2;

    public float speed = 800f;


   

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootLaser();
        }
    }

    void ShootLaser()
    {
        GameObject laserBeamLeft = Instantiate(laserPrefab, laserSpawnPoint1.position, Quaternion.identity);

        Rigidbody laserLeftRigidbody = laserBeamLeft.GetComponent<Rigidbody>();
        if(laserLeftRigidbody != null )
        {
            laserLeftRigidbody.velocity = laserSpawnPoint1.forward * speed;
        }
        
        Destroy(laserBeamLeft, 2f);

        
        GameObject laserBeamRight = Instantiate(laserPrefab, laserSpawnPoint2.position, Quaternion.identity);

        Rigidbody laserRightRigidbody = laserBeamRight.GetComponent<Rigidbody>();
        if (laserRightRigidbody != null)
        {
            laserRightRigidbody.velocity = laserSpawnPoint2.forward * speed;
        }

        Destroy(laserBeamRight, 2f);

        
    }
}
