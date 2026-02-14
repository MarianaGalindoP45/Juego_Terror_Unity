using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirCamara : MonoBehaviour
{

    void Update()
    {
        transform.forward = Camera.main.transform.forward;
    }
}
