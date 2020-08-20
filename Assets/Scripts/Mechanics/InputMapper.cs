using Cinemachine;
using UnityEngine;

public class InputMapper : MonoBehaviour
{
    public float TouchSensitivityX = 50f;

    public string TouchXInputMapTo = "Mouse X";

    void Start()
    {
        CinemachineCore.GetInputAxis = GetInputAxis;
    }

    private float GetInputAxis(string axisName)
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (axisName == TouchXInputMapTo && Mathf.Abs(touch.deltaPosition.x) > Mathf.Abs(touch.deltaPosition.y) * 1.5f)
                return touch.deltaPosition.x / TouchSensitivityX;
        }
        return Input.GetAxis(axisName);
    }
}
