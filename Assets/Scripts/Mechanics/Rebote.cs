using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rebote : MonoBehaviour
{
    [SerializeField]
    float forceMultY = 1f, forceMultX = 1f, forceMultZ = 1f;

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 vel = rb.velocity;
            rb.AddForce(new Vector3(vel.x * forceMultX, vel.y * forceMultY, vel.z * forceMultZ), ForceMode.Impulse);
            AudioManager.instance.Play("Escudo Jump");
        }
    }
}
