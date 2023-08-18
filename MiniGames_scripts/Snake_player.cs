using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake_player : MonoBehaviour
{
    Rigidbody2D rb;
    public float ForceMag;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            rb.AddForce(transform.up * ForceMag, ForceMode2D.Force);
        }
    }
}
