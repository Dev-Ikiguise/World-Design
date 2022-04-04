using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameObject ui;
    bool canCollect;

    public bool collectOnEnter;

    public AudioSource collectSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (collectOnEnter)
            {
                GetCollected();
            }
            else
            {
                collectSound.Play();
                ui.SetActive(true);
                canCollect = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            ui.SetActive(false);
            canCollect = false;
        }
    }

    void Update()
    {
        if (canCollect && Input.GetKeyDown(KeyCode.E))
        {
            GetCollected();
        }
    }

    public void GetCollected()
    {
        //Add cool effects later
        ui.SetActive(false);
        Destroy(gameObject);
    }

}
