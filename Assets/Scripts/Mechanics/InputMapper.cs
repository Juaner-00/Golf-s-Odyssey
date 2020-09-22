using Cinemachine;
using UnityEngine;

public class InputMapper : MonoBehaviour
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
            return InputManager.DistTurn * TouchSensitivityX / 100;
        }
        else if (Input.GetMouseButton(0))
            return InputManager.DistTurn * TouchSensitivityX / 100;

        return 0;
    }
}
