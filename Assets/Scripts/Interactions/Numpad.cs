using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Numpad : Interaction
{
    [SerializeField] private GameObject lampadaA;
    [SerializeField] private GameObject lampadaB;
    [SerializeField] private GameObject gira;
    public override void Interact()
    {
        Debug.Log("Numpad foi");
        PlayerPrefs.SetInt("Reator",1);

        gira.GetComponent<Spin>().rotationSpeed = 125;
        lampadaA.GetComponent<Light>().color = Color.blue;
        lampadaB.GetComponent<Light>().color = Color.blue;
        //#008000
    }
}
