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

    void OnCollisionEnter (Collision collisionInfo) {
        if (collisionInfo.collider.CompareTag ("Escudo")) {
            Instantiate (waterSpill, ballSpill.GetComponent<GameObject>().transform.position + offset, Quaternion.identity);
        }
    }
}