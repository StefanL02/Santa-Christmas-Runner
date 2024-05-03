using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    public float rotateSpeed = 1.5f;

    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0 , Space.World);
    }
}
