using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Vector3 RotationVector;
    public Space RelativeTo;

    // Update is called once per frame
    void Update()
    {
        // No need 
        transform.Rotate(RotationVector, RelativeTo);
    }
}
