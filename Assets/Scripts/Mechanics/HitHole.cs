﻿using System.Collections;
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

    [SerializeField]

    _SceneManager nextScene;

    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Player"))
        {
            Instantiate(obStar, transform.position + offset, Quaternion.identity);
            Invoke("SceneChanger", time);
        }
    }

    private void SceneChanger()
    {
        nextScene.LoadLevel();

    }
}
