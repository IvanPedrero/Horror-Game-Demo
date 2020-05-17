using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bulletImpact;

    void Start()
    {
        Destroy(this.gameObject, 3f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            print("Hit a " + collision.gameObject.name);
            ContactPoint contact = collision.contacts[0];
            Vector3 pos = contact.point;
            Instantiate(bulletImpact, pos, Quaternion.identity);
            Destroy(this.gameObject);
        }

    }
}
