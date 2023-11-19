using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private GameObject otherTeleport;
    [SerializeField] private Vector3 offset = new Vector3(1, 0, 0);
    [SerializeField] private bool isRightTeleport;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ghost"))
        {
            if (isRightTeleport)
            {
                collision.gameObject.transform.position = otherTeleport.transform.position + offset;
            }
            else
            {
                collision.gameObject.transform.position = otherTeleport.transform.position - offset;
            }
            
        }
    }
}
