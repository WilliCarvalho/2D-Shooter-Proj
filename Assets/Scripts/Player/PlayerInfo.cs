using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;
using UnityEngine;

//Responsible for taking care of general information that the player has
//(Life, Position in the map, if is getting hurt, etc.)
public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo instance;

    [SerializeField] private int lifes = 3;
    [SerializeField] private float playerVelocity = 10;

    private SpriteRenderer spriteRenderer;
    private Transform playerTransform;
    private bool isHurt;
    public bool isMoving;

    private int playerLevel;
    private int currentPlayerXP = 0;
    private int toLevelUpXp = 10;

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
        playerTransform = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        GameManager.instance.SetPlayerLife(lifes);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            LifeHandler();
        }
    }

    private void LifeHandler()
    {
        isHurt = true;
        lifes--;
        GameManager.instance.SetPlayerLife(lifes);
        if (lifes <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public Vector2 GetPlayerPosition()
    {
        return playerTransform.position;
    }

    public float GetPlayerVelocity()
    {
        return playerVelocity;
    }

    public bool CheckPlayerVelocity()
    {
        return isMoving;
    }

    public bool CheckPlayerHurt() => isHurt;

    public void SetPlayerHurt(bool value)
    {
        isHurt = value;
    }

    public SpriteRenderer GetSpriteRenderer()
    {
        return spriteRenderer;
    }

    public int GetPlayerLevel()
    {
        return playerLevel;
    }

    public void SetCurrentXP(int xpToAdd)
    {
        currentPlayerXP += xpToAdd;
        print(currentPlayerXP);
        CheckLevelUp();
    }

    private void CheckLevelUp()
    {
        if (currentPlayerXP >= toLevelUpXp)
        {
            playerLevel++;
            currentPlayerXP -= toLevelUpXp;
            toLevelUpXp += 5;            
        }
        GameManager.instance.SetNewXPInfo(playerLevel, currentPlayerXP, toLevelUpXp);
    }
}
