using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salpicadura : MonoBehaviour {
    [SerializeField]
    private GameObject waterSpill;
    [SerializeField]

    Vector3 offset = new Vector3 (0, 0, 0);

    [SerializeField]

    GameObject ballSpill;

  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(waterSpill, ballSpill.transform.position + offset, Quaternion.identity);
        }
    }
}