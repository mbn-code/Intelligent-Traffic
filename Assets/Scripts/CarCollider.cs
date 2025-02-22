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
            if (IsSouth)
            {
                if(other.gameObject.name.Contains("South"))
                {
                    CollisionController.SetSouthOccupied(true);
                    LightManager.AddToQueue("South");
                }
            }

            if (IsEast)
            {
                if(other.gameObject.name.Contains("East"))
                {
                    CollisionController.SetEastOccupied(true);
                    LightManager.AddToQueue("East");
                }
            }

            if (IsWest)
            {
                if(other.gameObject.name.Contains("West")) {
                    CollisionController.SetWestOccupied(true);
                    LightManager.AddToQueue("West");
                }
            }

            if (IsNorth)
            {
                if(other.gameObject.name.Contains("North")) {
                    CollisionController.SetNorthOccupied(true);
                    LightManager.AddToQueue("North");
                }
            }

            if (IsMiddle)
            {
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
