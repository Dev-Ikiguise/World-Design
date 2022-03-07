using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{
    public Transform spawnpoint;
    public GameObject ui;
    bool canTeleport;
    Transform transformToTeleport;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ui.SetActive(true);
            canTeleport = true;
            transformToTeleport = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            ui.SetActive(false);
            canTeleport = false;
            transformToTeleport = null;
        }
    }

    void Update()
    {
        if (canTeleport && Input.GetKeyDown(KeyCode.E))
        {
            transformToTeleport.position = spawnpoint.position;
        }
    }
}
