using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    GameObject gObj = null;
    Plane objPlane;
    Vector3 mO;

    Ray GenerateTouchRay()
    {
        Vector3 touchPosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 touchPosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        Vector3 touchPosF = Camera.main.ScreenToWorldPoint(touchPosFar);
        Vector3 touchPosN = Camera.main.ScreenToWorldPoint(touchPosNear);

        Ray mr = new Ray(touchPosN, touchPosF - touchPosN);
        return mr;
    }

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray touchRay = GenerateTouchRay();
            RaycastHit hit;

            if (Physics.Raycast(touchRay.origin, touchRay.direction, out hit))
            {
                gObj = hit.transform.gameObject;
                objPlane = new Plane(Camera.main.transform.forward * -1, gObj.transform.position);

                //cal touch Offset
                Ray tRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                float rayDistance;
                objPlane.Raycast(tRay, out rayDistance);
                mO = gObj.transform.position - tRay.GetPoint(rayDistance);
            }
        }
        else if (Input.GetMouseButton(0) && gObj)
        {
            Ray tRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float rayDistance;
            if (objPlane.Raycast(tRay, out rayDistance))
            {
                gObj.transform.position = tRay.GetPoint(rayDistance) + mO;
            }
        }
        else if(Input.GetMouseButtonUp(0) && gObj)
        {
            gObj = null;
        }
    }
}
