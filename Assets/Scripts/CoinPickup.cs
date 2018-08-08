using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

    [SerializeField] AudioClip coinPickupSFX;
    [SerializeField] int pointsToAdd = 30;
    bool addedToScore = false;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!addedToScore)
        {
            addedToScore = true;
            FindObjectOfType<GameSession>().AddToScore(pointsToAdd);
            AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
