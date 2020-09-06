using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelClearManager : MonoBehaviour
{
    [SerializeField] GameObject levelDialog;
    [SerializeField] TextMeshProUGUI levelClear;    
    [SerializeField] TextMeshProUGUI countStrikes;   


    public void ShowLevelDialog(string status, string cStrikes)
    {
        levelDialog.SetActive(true);
        levelClear.text = status;        
        countStrikes.text = cStrikes;
    }
}
