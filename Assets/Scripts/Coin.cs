// Created by Binh Bui on 07, 14, 2021


using UnityEngine;

public class Coin : MonoBehaviour, IFall
{
    public Rigidbody2D rb;
    public float speed = 1.5f;
    private void FixedUpdate()
    {
        Fall();
    }

    public void Fall()
    {
        rb.MovePosition(transform.position + Vector3.down * (speed * Time.fixedDeltaTime));
    }
}