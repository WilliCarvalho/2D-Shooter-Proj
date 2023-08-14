using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float velocity;
    private Vector3 targetPosition;

    void Update()
    {
        targetPosition = Player.instance.playerTransform.position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, velocity * Time.deltaTime);
    }
}
