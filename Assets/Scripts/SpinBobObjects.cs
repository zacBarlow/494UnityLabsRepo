using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinBobObjects : MonoBehaviour
{

    public float bobAmplitude = 0.02f;
    public float bobSpeed = 2f;
    public float spinSpeed = 2f;
    public Vector3 spinAxis = Vector3.up;

    private void Update()
    {
        float bobOffset = Mathf.Sin(Time.time * bobSpeed) * bobAmplitude;
        transform.position = new Vector3(transform.position.x, transform.position.y + bobOffset, transform.position.z);

        float spinAmount = Mathf.Sin(Time.time * spinSpeed);
        transform.Rotate(spinAxis * spinAmount, Space.World);
    }
}
