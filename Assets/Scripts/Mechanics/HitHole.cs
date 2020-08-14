using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitHole : MonoBehaviour
{
    [SerializeField]

    GameObject obStar;

    [SerializeField]

    Vector3 offset = new Vector3(0, 0, 0);
    [SerializeField]
    float time;
    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Player"))
        {
            Instantiate(obStar, transform.position + offset, Quaternion.identity);
            Invoke("Reset", time);
        }
    }

    private void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
