using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelClearManager : MonoBehaviour
{
    [SerializeField] GameObject levelDialog;
    [SerializeField] TextMeshProUGUI levelClear;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI countStrikes;


    public void ShowLevelDialog(string status, string score, string cStrikes)
    {
        levelDialog.SetActive(true);
        levelClear.text = status;
        scoreText.text = score;
        countStrikes.text = cStrikes;
    }
}
