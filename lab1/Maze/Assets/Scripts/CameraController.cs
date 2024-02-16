using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 shift = new Vector3(0, 0.45f, -0.33f);

    void Start()
    {
        transform.position = player.transform.position + shift;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + shift;
        transform.rotation = player.transform.rotation;
    }
}
