using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleManager : MonoBehaviour
{
    [SerializeField] GameObject[] floors;
    [SerializeField] GameObject hole;

    System.Random rand = new System.Random();

    private void Start()
    {
        int ind = rand.Next(0, floors.Length);
        hole.SetActive(true);
        GameObject floor = floors[ind];
        Vector3 pos = floor.transform.position;
        hole.transform.position = pos;
        floor.SetActive(false);

        print("Grass " + pos);
        print("Hole " + hole.transform.position);
    }
}
