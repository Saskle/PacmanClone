using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public int points = 10;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //add points
        Destroy(gameObject);
    }
}
