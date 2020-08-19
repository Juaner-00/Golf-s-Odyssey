using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salpicadura : MonoBehaviour
{
    [SerializeField] private GameObject waterSpill;

    [SerializeField] private Vector3 offset = new Vector3(0, 0, 0);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(waterSpill, other.transform.position + offset, Quaternion.identity);
        }
    }
}