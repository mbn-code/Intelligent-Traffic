using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField] private LightController SouthLight;
    [SerializeField] private LightController NorthLight;
    [SerializeField] private LightController EastLight;
    [SerializeField] private LightController WestLight;
    [SerializeField] private CollisionController CollisionController;
    private Dictionary<string, LightController> LightQueue = new();

    public bool IsSouthGood()
    {
        return NorthLight.IsRed() && EastLight.IsRed() && WestLight.IsRed();
    }

    public bool IsNorthGood()
    {
        return SouthLight.IsRed() && EastLight.IsRed() && WestLight.IsRed();
    }

    public bool IsEastGood()
    {
        return SouthLight.IsRed() && NorthLight.IsRed() && WestLight.IsRed();
    }

    public bool IsWestGood()
    {
        return SouthLight.IsRed() && NorthLight.IsRed() && EastLight.IsRed();
    }

    public void SetSouthGreen()
    {
        SouthLight.SetGreenLight();
        NorthLight.SetRedLight();
        EastLight.SetRedLight();
        WestLight.SetRedLight();
    }

    public void SetNorthGreen()
    {
        SouthLight.SetRedLight();
        NorthLight.SetGreenLight();
        EastLight.SetRedLight();
        WestLight.SetRedLight();
    }

    public void SetEastGreen()
    {
        SouthLight.SetRedLight();
        NorthLight.SetRedLight();
        EastLight.SetGreenLight();
        WestLight.SetRedLight();
    }

    public void SetWestGreen()
    {
        SouthLight.SetRedLight();
        NorthLight.SetRedLight();
        EastLight.SetRedLight();
        WestLight.SetGreenLight();
    }

    public void AddToQueue(string Direction)
    {
        switch (Direction)
        {
            case "South":
                LightQueue.Add(Direction, SouthLight);
                break;
            case "North":
                LightQueue.Add(Direction, NorthLight);
                break;
            case "East":
                LightQueue.Add(Direction, EastLight);
                break;
            case "West":
                LightQueue.Add(Direction, WestLight);
                break;
        }
    }

    void Update()
    {
        if (LightQueue.Count > 0)
        {
            foreach (var key in new List<string>(LightQueue.Keys))
            {
                if (LightQueue[key].IsRed() && !CollisionController.IsMiddleOccupied())
                {
                    bool setGreen = false;

                    switch (key)
                    {
                        case "South":
                            if(!CollisionController.IsNorthOccupied() && !CollisionController.IsEastOccupied() && !CollisionController.IsWestOccupied())
                            {
                                SetSouthGreen();
                                setGreen = true;
                            }
                            break;
                        case "North":
                            if(!CollisionController.IsSouthOccupied() && !CollisionController.IsEastOccupied() && !CollisionController.IsWestOccupied())
                            {
                                SetNorthGreen();
                                setGreen = true;
                            }
                            break;
                        case "East":
                            if(!CollisionController.IsSouthOccupied() && !CollisionController.IsNorthOccupied() && !CollisionController.IsWestOccupied())
                            {
                                SetEastGreen();
                                setGreen = true;
                            }
                            break;
                        case "West":
                            if(!CollisionController.IsSouthOccupied() && !CollisionController.IsNorthOccupied() && !CollisionController.IsEastOccupied())
                            {
                                SetWestGreen();
                                setGreen = true;
                            }
                            break;
                    }

                    if (setGreen) {
                        LightQueue.Remove(key);
                    }
                }
            }
        }
    }
}
