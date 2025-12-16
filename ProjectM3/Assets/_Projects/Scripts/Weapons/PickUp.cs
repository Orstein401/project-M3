using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] Gun gunPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Gun gun= Instantiate(gunPrefab, collision.gameObject.transform);
            Destroy(gameObject);
        }
    }
}
