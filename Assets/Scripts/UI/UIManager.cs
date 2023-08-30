using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private TextMeshProUGUI lifesText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI xPInfoText;
    [SerializeField] private TextMeshProUGUI currentLevelXPText;

    private void Awake()
    {
        #region Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("Another UI instance is active");
            Destroy(this.gameObject);
        }
        #endregion
        SetupUI();
    }

    private void SetupUI()
    {
        lifesText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
    }

    public void SetScoreText(int updatedScore)
    {
        scoreText.text = "Score: " + updatedScore;
    }

    public void SetLifesText(int updatedLife)
    {
        lifesText.text = "Lifes: " + updatedLife;
    }

    public void SetXPInfoText(int currentXP, int toLevelUpXP)
    {
        xPInfoText.text = currentXP + " / " + toLevelUpXP;
    }

    public void SetPlayerLevelText(int newLevel)
    {
        currentLevelXPText.text = "Level: " + newLevel.ToString();
    }
}
