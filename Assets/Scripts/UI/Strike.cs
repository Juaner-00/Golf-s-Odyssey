using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Strike : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI strikeText;

    PlayerController playerController;


    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void OnEnable()
    {
        playerController.OnStrike += UpdateStrikeUI;
    }
    void OnDisable()
    {
        playerController.OnStrike -= UpdateStrikeUI;
    }
    void UpdateStrikeUI(int counterText)
    {
        strikeText.text = counterText.ToString();
    }
}
