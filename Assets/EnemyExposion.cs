using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExposion : MonoBehaviour
{
    public GameObject explo;
    public Vector3 offset;
  
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(explo, transform.position + offset, Quaternion.identity);
            Invoke("DeathEnemy", 0);
        }
      
    }

    void DeathEnemy()
    {
        Destroy(gameObject);
    }
}
