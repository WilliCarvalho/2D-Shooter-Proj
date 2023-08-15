using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Player : MonoBehaviour
{
    public static Player instance;

    [SerializeField] private float velocity = 10;
    [SerializeField] private int lives = 3;

    private Transform playerTransform;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        playerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal") * velocity * Time.deltaTime;
        float moveY = Input.GetAxisRaw("Vertical") * velocity * Time.deltaTime;
        transform.Translate(moveX, moveY, 0);
        print(lives);
        if(lives <= 0)
        {
            Destroy(gameObject);
        }
    }

    public Vector3 GetPlayerPosition()
    {
        return playerTransform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        lives--;
    }
}
