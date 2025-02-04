using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    private bool SouthOccupied = false;
    private bool EastOccupied = false;
    private bool WestOccupied = false;
    private bool NorthOccupied = false;
    private bool MiddleOccupied = false;

    public void SetSouthOccupied(bool value)
    {
        SouthOccupied = value;
    }

    public void SetEastOccupied(bool value)
    {
        EastOccupied = value;
    }

    public void SetWestOccupied(bool value)
    {
        WestOccupied = value;
    }

    public void SetNorthOccupied(bool value)
    {
        NorthOccupied = value;
    }

    public void SetMiddleOccupied(bool value)
    {
        MiddleOccupied = value;
    }

    public bool IsSouthOccupied()
    {
        return SouthOccupied;
    }

    public bool IsEastOccupied()
    {
        return EastOccupied;
    }

    public bool IsWestOccupied()
    {
        return WestOccupied;
    }

    public bool IsNorthOccupied()
    {
        return NorthOccupied;
    }

    public bool IsMiddleOccupied()
    {
        return MiddleOccupied;
    }
}
