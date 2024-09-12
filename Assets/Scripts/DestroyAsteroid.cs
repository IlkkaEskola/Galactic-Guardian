using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAsteroid : MonoBehaviour
{
    public ParticleSystem explosionParticle;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            Instantiate(explosionParticle, transform.position, transform.rotation);
            Destroy(gameObject);
            //explosionParticle.Play();
        }
    }
}
