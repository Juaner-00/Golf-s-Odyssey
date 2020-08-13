using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExposion : MonoBehaviour
{
    public GameObject explo;

    private void Start()
    {
        explo = GetComponent<GameObject>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag( "Player"))
        {
            Invoke("explo",0);
            
            Destroy(gameObject);
        }
    }
}
