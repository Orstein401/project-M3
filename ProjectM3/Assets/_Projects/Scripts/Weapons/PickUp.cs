using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] Gun gunPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerController>(out var player))
        {
            Gun gun = Instantiate(gunPrefab, collision.gameObject.transform);
            Destroy(gameObject);
        }

    }
}
