using Cinemachine;
using UnityEngine;

public class InputMapper2 : MonoBehaviour
{
    [SerializeField] float sensitivityX = 30f;

    [SerializeField] string TouchXInputMapTo = "Mouse X";

    Touch touch;

    void Start()
    {
        CinemachineCore.GetInputAxis = GetInputAxis;
    }

    private float GetInputAxis(string axisName)
    {

        if (Input.touchCount > 0)
            touch = Input.GetTouch(0);

        // if (InputManager.CanShoot)
        // {
        if (Input.touchCount > 0)
            return InputManager2.DistTurn * sensitivityX / 100;
        else if (Input.GetMouseButton(0))
            return InputManager2.DistTurn * sensitivityX / 100;
        // }
        // else if (!InputManager.InRange)
        // {
        //     if (Input.touchCount > 0)
        //         return touch.deltaPosition.x / Screen.height * sensitivityX / 10;
        //     else if (Input.GetMouseButton(0))
        //         return InputManager.DeltaMousePos.x / Screen.height * sensitivityX / 10;

        // }
        return 0;
    }
}
