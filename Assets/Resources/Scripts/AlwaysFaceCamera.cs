using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AlwaysFaceCamera : MonoBehaviour
{
    Camera arCamera;
    GameObject Nährwert;
    // Start is called before the first frame update
    void Start()
    {
        arCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = arCamera.transform.rotation;
    }
}
