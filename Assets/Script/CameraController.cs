using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 50.0f;

    private Touch initTouch = new Touch();

    public Transform lookAt;
    public Transform CamTransform;

    private Camera cam;

    private float distance = 15.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensivityX = 4.0f;
    private float sensivityY = 1.0f;

    // Start is called before the first frame update
    private void Start()
    {
        CamTransform = transform;
        cam = Camera.main;    
    }

    
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began)
            {
                initTouch = touch;
            }
            else if(touch.phase == TouchPhase.Moved)
            {
                //swipe
                float currentX = initTouch.position.x + touch.position.x;
                float currentY = initTouch.position.y - touch.position.y;

                currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
                Vector3 dir = new Vector3(0, 0, -distance);
                Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
                CamTransform.position = lookAt.position + rotation * dir;
                CamTransform.LookAt(lookAt.position);

            }
            else if(touch.phase == TouchPhase.Ended)
            {
                initTouch = new Touch();
            }
        }
    }
    

}
