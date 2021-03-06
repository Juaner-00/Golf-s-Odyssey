﻿using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class RayBeam : MonoBehaviour
{
    [SerializeField] int reflections;
    [SerializeField] float maxLenght;
    [SerializeField] LayerMask bouncers;
    [SerializeField] bool alwaysVisible = false;
    [SerializeField] GameObject ball;

    private LineRenderer lineRenderer;
    private Ray ray;
    private RaycastHit hit;
    private Vector3 direction;

    public float MaxLenght { get => maxLenght; set => maxLenght = value; }

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        
        if (!LevelClearManager.Instance.HasClear)
        {
            ray = new Ray(ball.transform.position, InputManager.Direction);

            lineRenderer.positionCount = 1;
            lineRenderer.SetPosition(0, transform.position);

            float remainingLength = MaxLenght;

            if (!alwaysVisible)
                lineRenderer.enabled = (InputManager.CanShoot) ? true : false;

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
    
}
