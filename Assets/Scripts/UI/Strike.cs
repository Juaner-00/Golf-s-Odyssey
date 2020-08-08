using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Strike : MonoBehaviour
{
    [SerializeField]
    Text strikeText;

    PlayerController playerController;


    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Start()
    {
        playerController.OnStrike += UpdateStrikeUI;
    }

    void UpdateStrikeUI(int counterText)
    {
        strikeText.text = counterText.ToString();
    }
}
