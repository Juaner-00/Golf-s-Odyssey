using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class RayBeam : MonoBehaviour
{

    public int reflections;
    public float maxLenght;

    private LineRenderer lineRenderer;
    private Ray ray;
    private RaycastHit hit;
    private Vector3 direction;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }


    private void Update()
    {
        ray = new Ray(transform.position, transform.forward);

        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);

        float remainingLength = maxLenght;

        // lineRenderer.enabled = (Input.GetMouseButton(0) || Input.touchCount > 0) ? true : false;
        if (Physics.Raycast(ray.origin, ray.direction, out hit, remainingLength))
        {
            for (int i = 0; i < reflections; i++)
            {
                lineRenderer.SetPosition(lineRenderer.positionCount, hit.point);
                lineRenderer.positionCount += 1;

                if (Physics.Raycast(ray.origin, ray.direction, out hit, remainingLength))
                {
                    if (hit.collider.CompareTag("Bouncers"))
                    {
                        remainingLength -= Vector3.Distance(ray.origin, hit.point);
                        ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));
                        lineRenderer.SetPosition(lineRenderer.positionCount, ray.origin + ray.direction * remainingLength);
                        lineRenderer.positionCount += 1;
                    }
                    else
                        break;
                }
                else
                    break;

            }
        }
        else
        {
            lineRenderer.positionCount = 2;
            lineRenderer.SetPositions(new Vector3[] { transform.position, ray.origin + ray.direction * maxLenght });
        }


    }
}
