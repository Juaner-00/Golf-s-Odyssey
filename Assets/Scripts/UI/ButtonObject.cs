using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonObject : MonoBehaviour
{
    private Transform cam;

    private void Awake()
    {
        cam = Camera.main.transform;
    }

    private void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }

    public void Place()
    {
        BuildingPlacement.Instance.SetBuild();
    }

    public void Rotate()
    {
        transform.parent.transform.localEulerAngles += new Vector3(0, 90, 0);
    }

    public void Cancel()
    {
        BuildingPlacement.Instance.SetBuild();
        Destroy(transform.parent.gameObject);
    }
}
