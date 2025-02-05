using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollider : MonoBehaviour
{
    bool IsSouth = false;
    bool IsEast = false;
    bool IsWest = false;
    bool IsNorth = false;
    bool IsMiddle = false;

    [SerializeField] private CollisionController CollisionController;
    [SerializeField] private LightManager LightManager;

    void Start()
    {
        IsSouth = this.gameObject.name.Contains("South");
        IsEast = this.gameObject.name.Contains("East");
        IsWest = this.gameObject.name.Contains("West");
        IsNorth = this.gameObject.name.Contains("North");
        IsMiddle = this.gameObject.name.Contains("Middle");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Car"))
        {
            Debug.Log("Car Collided");
            if (IsSouth)
            {
                Debug.Log("Set South Occupied");
                CollisionController.SetSouthOccupied(true);
                LightManager.AddToQueue("South");
                Debug.Log("South");
            }

            if (IsEast)
            {
                Debug.Log("Set East Occupied");
                CollisionController.SetEastOccupied(true);
                LightManager.AddToQueue("East");
                Debug.Log("East");
            }

            if (IsWest)
            {
                Debug.Log("Set West Occupied");
                CollisionController.SetWestOccupied(true);
                LightManager.AddToQueue("West");
                Debug.Log("West");
            }

            if (IsNorth)
            {
                Debug.Log("Set North Occupied");
                CollisionController.SetNorthOccupied(true);
                LightManager.AddToQueue("North");
                Debug.Log("North");
            }

            if (IsMiddle)
            {
                Debug.Log("Set Middle Occupied");
                CollisionController.SetMiddleOccupied(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Car"))
        {
            if (IsSouth)
            {
                CollisionController.SetSouthOccupied(false);
            }

            if (IsEast)
            {
                CollisionController.SetEastOccupied(false);
            }

            if (IsWest)
            {
                CollisionController.SetWestOccupied(false);
            }

            if (IsNorth)
            {
                CollisionController.SetNorthOccupied(false);
            }

            if (IsMiddle)
            {
                CollisionController.SetMiddleOccupied(false);
            }
        }
    }
}
