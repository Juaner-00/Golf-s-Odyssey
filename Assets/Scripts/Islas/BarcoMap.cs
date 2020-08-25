using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BarcoMap : MonoBehaviour
{
    private float speed = 0.5f;

    private Vector3 targetPosition;
    private bool isMoving = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButton(0))
       {
            setTargetPosition();
       }
       if (isMoving)
       {
            Move();
       }

        /*if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(+0.001f, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-0.001f, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, +0.001f, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -0.03f, 0);
        }*/
    }
    void setTargetPosition()
    {
        targetPosition = Camera.main.ViewportToScreenPoint(Input.mousePosition);
        targetPosition.z = transform.position.z;
        isMoving = true;

    }
    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if(transform.position == targetPosition)
        {
            isMoving = false;
        }
    }
}
