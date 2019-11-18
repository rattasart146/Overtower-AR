using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform lookAt;
    public Transform CamTransform;

    private Camera cam;

    private float distance = 10.0f;
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
}
