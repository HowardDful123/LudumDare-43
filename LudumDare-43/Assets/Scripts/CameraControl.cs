using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    [SerializeField]
    private float offset;
    [SerializeField]
    private float xMax;
    [SerializeField]
    private float yMax;
    [SerializeField]
    private float xMin;
    [SerializeField]
    private float yMin;

    public Transform player;

    void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(player.position.x, xMin, xMax), Mathf.Clamp(player.position.y, yMin, yMax), transform.position.z);
    }
}
