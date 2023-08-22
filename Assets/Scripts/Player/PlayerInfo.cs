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

    [SerializeField] private int lives = 3;
    [SerializeField] private float playerVelocity = 10;

    private SpriteRenderer spriteRenderer;
    private Transform playerTransform;
    private bool isHurt;
    public bool isMoving;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        LifeHandler();
    }

    private void LifeHandler()
    {
        isHurt = true;
        lives--;
        if(lives <= 0)
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
}
