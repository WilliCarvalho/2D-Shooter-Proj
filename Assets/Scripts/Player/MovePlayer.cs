using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Responsible for taking care of player movemente based on user's input
public class MovePlayer : MonoBehaviour
{
    private float velocity;
    private void Start()
    {
        velocity = PlayerInfo.instance.GetPlayerVelocity();
    }
    void Update()
    {
        MoveHandler();
    }

    private void MoveHandler()
    {
        float moveX = Input.GetAxisRaw("Horizontal") * velocity * Time.deltaTime;
        float moveY = Input.GetAxisRaw("Vertical") * velocity * Time.deltaTime;
        transform.Translate(new Vector2(moveX, moveY).normalized * velocity * Time.deltaTime);
        PlayerInfo.instance.isMoving = moveX != 0 || moveY != 0;
    }
}
