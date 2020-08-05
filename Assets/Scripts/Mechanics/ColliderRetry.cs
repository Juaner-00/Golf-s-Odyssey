using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderRetry : MonoBehaviour
{
    _SceneManager sceneManager;

    private void Awake()
    {
        sceneManager = FindObjectOfType<_SceneManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sceneManager.Reset();
        }
    }
}
