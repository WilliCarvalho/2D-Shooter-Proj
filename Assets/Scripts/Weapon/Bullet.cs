using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletVelocity;
    [SerializeField] private float bulletLifeTime = 3f;

    private void Start()
    {
        StartCoroutine(LifeSpan());
    }

    private void Update()
    {
        transform.Translate(Vector3.right * bulletVelocity * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }

    private IEnumerator LifeSpan()
    {
        yield return new WaitForSeconds(bulletLifeTime);
        Destroy(gameObject);
    }

}