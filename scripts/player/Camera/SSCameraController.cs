using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using rts;
public class SSCameraController : CameraController
{
    public SSCameraController() :base()
    {
        ZoomedInAngle = ResourceManager.ZoomedInAngleSS;
        ZoomedOutAngle = ResourceManager.ZoomedOutAngleSS;
        MinCameraHeight = ResourceManager.MinCameraHeightSS;
        MaxCameraHeight = ResourceManager.MaxCameraHeightSS;

        ScrollSpeedVertical = ResourceManager.ScrollSpeedVerticalSS;
        MinPanSpeed = ResourceManager.MinPanSpeedSS;
        ScrollSpeed = ResourceManager.ScrollSpeedSS;
        MinZoomSpeed = ResourceManager.MinZoomSpeedSS;

        ZoomDampnerpan = ResourceManager.ZoomDampnerpanSS;
        MaxCameraRad = ResourceManager.MaxCameraRadSS;

        MinFieldofView = ResourceManager.MinFieldofViewSS;
        MaxFieldofView = ResourceManager.MaxFieldofViewSS;

    }








}
