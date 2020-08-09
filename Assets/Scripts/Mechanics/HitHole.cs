using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitHole : MonoBehaviour
{

    public ParticleSystem starCelebration;

    private void Start()
    {
        starCelebration = GetComponent<ParticleSystem>();
    }
    private void OnTriggerEnter(Collider other)
    {

        
        if (gameObject.CompareTag("Player"))
        {
            starCelebration.Play();
        }
    }
}
