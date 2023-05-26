using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUp : MonoBehaviour
{
    public Car player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject.GetComponent<Car>();
            Activate();
            MakeThisPickupInvisible();
            Invoke(nameof(DelayedDestroy), 5);
        }
    }

    public virtual void Activate()
    {
        
    }


    
    public void MakeThisPickupInvisible()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }

   
    public void DelayedDestroy()
    {
        Destroy(gameObject);
    }

}
