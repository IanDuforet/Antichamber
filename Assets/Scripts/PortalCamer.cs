using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamer : MonoBehaviour
{
    public Transform PlayerCamera;
    public Transform Portal;
    public Transform OtherPortal;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerOffsetPortal = PlayerCamera.position - OtherPortal.position;
        transform.position = Portal.position + playerOffsetPortal;

        float angleDifferencePortals = Quaternion.Angle(Portal.rotation, OtherPortal.rotation);

        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angleDifferencePortals, Vector3.up);
        Vector3 newCameraDirection = portalRotationalDifference * PlayerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection);

    }
}
