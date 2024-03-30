using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField] public float rotationSpeed;
    [SerializeField] private Transform transformToRotate;
    void Update()
    {
        transformToRotate.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime));
    }
}
