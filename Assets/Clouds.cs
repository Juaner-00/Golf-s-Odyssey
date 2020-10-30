using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
   Transform cloud;
    public float speed;


    private void Start()
    {
        cloud = GetComponent<Transform>();
    }
    private void Update()
    {
        cloud.transform.position = new Vector3(cloud.transform.position.x + speed * Time.deltaTime, cloud.transform.position.y, cloud.transform.position.z);    
    }

}
