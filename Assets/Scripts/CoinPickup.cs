using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSFX;
    [SerializeField] int pointsForCoinPickup = 100;
    bool wasCollected = false;

    //void Start()
    //{

    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);
            Destroy(gameObject);
            FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);

        }
    }


    // Update is called once per frame
    //void Update()
    //{

    //}
}
