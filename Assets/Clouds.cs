using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
   
    public float speed;
    //[SerializeField]
    GameObject initialPos;

    private void Awake()
    {
        initialPos = GameObject.Find("Initial cloud position");
    }


    private void Update()
    {
        transform.position = new Vector3(transform.position.x * speed * Time.deltaTime, transform.position.y, transform.position.z);
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Cloud"))
        {
            
            transform.position = new Vector3(initialPos.transform.position.x, transform.position.y, transform.position.z);
        }
    }

}
