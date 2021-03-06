using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] public Transform player;
    [SerializeField] public Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        player.transform.position = respawnPoint.transform.position;
    }
}
