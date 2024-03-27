using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private GameObject camera;

    private void OnTriggerEnter(Collider other)
    {
        Camera cameraatual = Camera.main;
        cameraatual.gameObject.SetActive(false);
        camera.SetActive(true);
        
    }
}
