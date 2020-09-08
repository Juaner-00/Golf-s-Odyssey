using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Strike : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI strikeText;


    void OnEnable()
    {
        PlayerController.OnStrike += UpdateStrikeUI;
    }

    void OnDisable()
    {
        PlayerController.OnStrike -= UpdateStrikeUI;
    }

    void UpdateStrikeUI(int counterText)
    {
        strikeText.text = counterText.ToString();
    }
}
