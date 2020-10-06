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
            if (InputManager2.SwipeType == SwipeType.Horizontal)
                return touch.deltaPosition.x * TouchSensitivityX / 1000;
        }
        else if (Input.GetMouseButton(0) && InputManager2.SwipeType == SwipeType.Horizontal)
            return InputManager2.DeltaMousePos.x * TouchSensitivityX / 1000;

        return 0;
    }
}