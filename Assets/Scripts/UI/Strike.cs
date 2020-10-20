using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Strike : MonoBehaviour
{
    TextMeshProUGUI strikeText;

    private void Awake()
    {
        strikeText = GameObject.FindGameObjectWithTag("StrikeText").GetComponent<TextMeshProUGUI>();
    }

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
