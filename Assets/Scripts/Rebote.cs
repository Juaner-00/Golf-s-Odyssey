using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rebote : MonoBehaviour
{

    public int yForce;
    public int xForce;
    public Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        
            if (collision.gameObject.tag == "Escudo")
            {
                rb.AddForce(new Vector3(xForce, yForce, 0), ForceMode.Impulse);

                
            }
    }
}
