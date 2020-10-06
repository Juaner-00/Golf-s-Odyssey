using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class InputMapper3 : MonoBehaviour
{
    [SerializeField] float sensitivityX = 30f;
    [SerializeField] string TouchXInputMapTo = "Mouse X";

    public static int Mult { get; set; }

    Touch touch;

    void Start()
    {
        CinemachineCore.GetInputAxis = GetInputAxis;
    }

    private float GetInputAxis(string axisName)
    {
        return sensitivityX * Mult / 100;
    }

}
