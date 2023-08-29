using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int gameScore = 0;
    private int playerLifes;

    private void Awake()
    {
        #region Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        #endregion
    }

    public Vector3 GetMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0;
        return mousePosition;
    }

    public int GetGameScore()
    {
        return gameScore;
    }

    public void SetGameScore(int score)
    {
        gameScore += score;
        UIManager.Instance.SetScoreText(gameScore);
    }

    public void SetPlayerLife(int life)
    {
        playerLifes = life;
        UIManager.Instance.SetLifesText(playerLifes);
    }
}