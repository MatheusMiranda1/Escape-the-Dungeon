using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieVanish : MonoBehaviour
{
    public string playerTag = "Player";
    public GameObject Zombie1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            Destroy(Zombie1);
            Destroy(gameObject);
        }
    }
}
