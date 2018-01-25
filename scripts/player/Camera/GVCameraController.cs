using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using rts;

public class GVCameraController : CameraController
{
    public GVCameraController() : base()
    { 
        ZoomedInAngle= ResourceManager.ZoomedInAngleGV;
        ZoomedOutAngle= ResourceManager.ZoomedOutAngleGV;
        MinCameraHeight= ResourceManager.MinCameraHeightGV;
        MaxCameraHeight= ResourceManager.MaxCameraHeightGV;
        ScrollSpeedVertical = ResourceManager.ScrollSpeedVerticalGV;
        ScrollSpeed = ResourceManager.ScrollSpeedGV;
        MinPanSpeed = ResourceManager.MinPanSpeedGV;
        MinZoomSpeed = ResourceManager.MinZoomSpeedGV;

        MinFieldofView = ResourceManager.MinFieldofViewGV;
        MaxFieldofView=ResourceManager.MaxFieldofViewGV;

    MaxCameraRad = ResourceManager.MaxCameraRadGV;
        ZoomDampnerpan = ResourceManager.ZoomDampnerpanGV;
    }

    public override void ResetCamera(Star StarbeingViewed)
    {
        //cameraObj.transform.localPosition = StarbeingViewed.position;
        //cameraObj.transform.Translate(new Vector3(0, 0, -30));

    }


}