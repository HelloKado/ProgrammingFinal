using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Final Exam #3
 * 
 *  Make this script inherit the PickUp Class.
 * Attach this script to the yellow arrow that is on the track
 * Override the Activate() method to:
 *      - Save the original speed of the player
 *      - increase the speed of the car to 5
 *      - Wait for 2 seconds (Write a coroutine)
 *      - Change the speed back to the originalSpeed
 * 
 */
using UnityEngine;

public class SpeedPickup : PickUp
{
    public float originalSpeed;
    public float boostedSpeed;

    public override void Activate()
    {
        base.Activate();

        GameObject[] playerGameObjects = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject playerGameObject in playerGameObjects)
        {
            Car playerCar = playerGameObject.GetComponent<Car>();
            if (playerCar != null)
            {
                originalSpeed = playerCar.moveSpeed;
                playerCar.moveSpeed = boostedSpeed;
                StartCoroutine(ResetSpeedAfterDelay(playerCar));
            }
        }
    }

    private IEnumerator ResetSpeedAfterDelay(Car car)
    {
        yield return new WaitForSeconds(2f);
        car.moveSpeed = originalSpeed;
    }
}
