using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Numpad : Interaction
{
    [SerializeField] private GameObject lampadaA;
    [SerializeField] private GameObject lampadaB;
    [SerializeField] private GameObject gira;
    [SerializeField] private Color newColor;
    [SerializeField] private float newRotation;
    public override void Interact()
    {
        CorrectPassword();
    }

    private void CorrectPassword()
    {
        Debug.Log("Numpad foi");
        PlayerPrefs.SetInt("Reator",1);
        
        gira.GetComponent<Spin>().rotationSpeed = newRotation;
        ChangeLightColor();
    }
    
    
    private void ChangeLightColor()
    {
        lampadaA.GetComponent<Light>().color = newColor;
        lampadaB.GetComponent<Light>().color = newColor;
    }
}
