using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class RayBeam2 : MonoBehaviour
{
    [SerializeField] int reflections;
    [SerializeField] float maxLenght;
    [SerializeField] LayerMask bouncers;
    [SerializeField] bool alwaysVisible = false;

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
        ray = new Ray(transform.position, InputManager2.Direction);

        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);

        float remainingLength = maxLenght;

        if (!alwaysVisible)
            lineRenderer.enabled = (InputManager2.CanShoot) ? true : false;

        for (int i = 0; i <= reflections; i++)
        {
            if (Physics.Raycast(ray.origin, ray.direction, out hit, remainingLength, bouncers))
            {
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit.point);

                if (hit.collider.CompareTag("Bouncers"))
                {
                    remainingLength -= Vector3.Distance(ray.origin, hit.point);
                    ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));
                }
                else
                    break;
            }
            else
            {
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, ray.origin + ray.direction * remainingLength);
            }
        }

    }
}
