using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTrajectory : MonoBehaviour
{
    public int rayCount = 2;
    public LineRenderer line;


    private void Start()
    {
        line = GetComponent<LineRenderer>();
    }
    private void Update()
    {
        CastRay(transform.position, transform.forward);
    }
    
    void CastRay(Vector3 position, Vector3 direction)
    {
        for(int i = 0; i< rayCount; i++)
        {
            Ray ray = new Ray(position, direction);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 10, 1))
            {
               

                if (Input.GetMouseButton(0))
                {
                    line.enabled = true;
                }
                else
                {
                    line.enabled = false;
                }
                
                Debug.DrawLine(position, hit.point, Color.red);
                position = hit.point;
                direction = hit.normal;
                line.SetPosition(0, transform.position);
                line.SetPosition(i, hit.point);
            }
            else
            {
                Debug.DrawLine(position, hit.point, Color.red);
                break;
            }
        }
    }
}