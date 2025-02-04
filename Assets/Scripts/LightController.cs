using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private GameObject GreenLight;
    [SerializeField] private GameObject YellowLight; 
    [SerializeField] private GameObject RedLight; 

    void Start()
    {
        YellowLight.SetActive(false);
        RedLight.SetActive(true);
        GreenLight.SetActive(false);
    }

    public void SetYellowLight()
    {
        GreenLight.SetActive(false);
        YellowLight.SetActive(true);
        RedLight.SetActive(false);
    }
    
    public void SetRedLight()
    {
        GreenLight.SetActive(false);
        YellowLight.SetActive(false);
        RedLight.SetActive(true);
    }
    
    public void SetGreenLight()
    {
        GreenLight.SetActive(true);
        YellowLight.SetActive(false);
        RedLight.SetActive(false);
    }

    public bool IsGreen()
    {
        return GreenLight.activeSelf;
    }

    public bool IsYellow()
    {
        return YellowLight.activeSelf;
    }

    public bool IsRed()
    {

        return RedLight.activeSelf;
    }
}
