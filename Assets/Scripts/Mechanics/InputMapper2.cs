using Cinemachine;
using UnityEngine;

public class InputMapper2 : MonoBehaviour
{
    [SerializeField] float TouchSensitivityX = 50f;

    [SerializeField] string TouchXInputMapTo = "Mouse X";


    void Start()
    {
        CinemachineCore.GetInputAxis = GetInputAxis;
    }

    private float GetInputAxis(string axisName)
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (axisName == TouchXInputMapTo && InputManager2.SwipeType == SwipeType.Horizontal)
                return touch.deltaPosition.x / TouchSensitivityX;
        }
        else if (Input.GetMouseButton(0) && InputManager2.SwipeType == SwipeType.Horizontal)
            return Input.GetAxis(axisName);

        return 0;
    }
}