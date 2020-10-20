using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonObject : MonoBehaviour
{
    private Camera cam;
    private GameObject canvas;

    private bool isPlaced;

    private void Awake()
    {
        cam = Camera.main;
        canvas = transform.GetChild(0).gameObject;
    }

    private void OnEnable()
    {
        isPlaced = false;
    }

    private void LateUpdate()
    {
        canvas.transform.LookAt(transform.position + cam.transform.forward);

    }

    public void Place()
    {
        if (BuildingPlacement.Instance.CanPlace(transform.position))
        {
            BuildingPlacement.Instance.SetBuild(transform.position, transform.gameObject);
            canvas.SetActive(false);
            isPlaced = true;
        }
    }

    public void Rotate()
    {
        transform.transform.localEulerAngles += new Vector3(0, 90, 0);
    }

    public void Cancel()
    {
        BuildingPlacement.Instance.DeleteBuild(transform.position, transform.gameObject);

        Destroy(transform.gameObject);
    }

    private void Update()
    {
        if (isPlaced)
        {
            if (Input.GetMouseButtonDown(0))
                CheckClick(Input.mousePosition);

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                    CheckClick(touch.position);
            }
        }
    }

    private void CheckClick(Vector3 pos)
    {
        Ray rayCast = cam.ScreenPointToRay(pos);
        RaycastHit hit;

        if (Physics.Raycast(rayCast, out hit, 100, BuildingPlacement.Instance.LayerPlaceable))
            if (!BuildingPlacement.Instance.IsBuilding)
            {
                canvas.SetActive(true);
                BuildingPlacement.Instance.SetObject(transform.position, gameObject);
            }
    }
}
