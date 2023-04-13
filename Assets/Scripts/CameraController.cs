using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform followTransform;
    public Transform topLeft;
    public Transform bottomRight;

    private float xMin, xMax, yMin, yMax;
    private float camY,camX;
    private float camOrthsize;
    private float cameraRatio;
    private Camera mainCam;

    private void Start()
    {
        xMin = topLeft.position.x;
        xMax = bottomRight.position.x;
        yMin = topLeft.position.y;
        yMax = bottomRight.position.y;
        mainCam = GetComponent<Camera>();
        camOrthsize = mainCam.orthographicSize;
        cameraRatio = (xMax + camOrthsize) / 2.0f;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        camY = Mathf.Clamp(followTransform.position.y, yMin + 0.5f*camOrthsize, yMax - 0.5f*camOrthsize);
        camX = Mathf.Clamp(followTransform.position.x, xMin + 0.5f*cameraRatio, xMax - 0.5f*cameraRatio);
        this.transform.position = new Vector3(camX, camY, this.transform.position.z);
        
        
    }
}