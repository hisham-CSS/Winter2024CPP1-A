using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public enum PickupType
    {
        Powerup,
        Life,
        Score
    }

    [SerializeField] PickupType currentPickup;
    [SerializeField] AudioClip pickupSound;
    //[SerializeField] float timeToDestroy = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        { 
            PlayerController pc = collision.GetComponent<PlayerController>();

            switch (currentPickup)
            {
                case PickupType.Powerup:
                    pc.StartJumpForceChange();
                    break;
                case PickupType.Life:
                    GameManager.Instance.lives++;
                    break;
                case PickupType.Score:
                    GameManager.Instance.score++;
                    break; 
            }
            GetComponent<AudioSource>().PlayOneShot(pickupSound);
            GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject, pickupSound.length);
        }

        
    }

    private void OnDestroy()
    {
       
    }
}
