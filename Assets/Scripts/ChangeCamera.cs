using System;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    [SerializeField] private GameObject CameraA;
    [SerializeField] private GameObject CameraB;

    private void OnTriggerEnter(Collider other)
    {
        if (CameraA.activeSelf)
        {
            CameraB.SetActive(true);
            CameraA.SetActive(false);
        }
        else
        {
            CameraA.SetActive(true);
            CameraB.SetActive(false);
        }
    }
}
