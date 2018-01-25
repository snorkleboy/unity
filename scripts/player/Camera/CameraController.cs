using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using rts;
using System.Linq;

public class CameraController {

    public Transform CameraObject;
    public Transform CameraHolder;


    protected Vector3 DefaultCam = Vector3.zero;
    private Vector3 savedposition;
    bool savedpositionset = false;

    public float ZoomedInAngle;
    public float ZoomedOutAngle;
    public float MinCameraHeight;
    public float MaxCameraHeight;

    public float ScrollSpeed;
    public float ScrollSpeedVertical;
    public float MinPanSpeed;
    public float MinZoomSpeed;

    public float ZoomDampnerpan;
    public float MaxCameraRad;
    public float MinFieldofView;
    public float MaxFieldofView;



    public CameraController()
    {
        
        CameraObject = Camera.main.transform;
        CameraHolder = CameraObject.parent.transform;



    }
    public virtual void ResetCamera()
    {
        CameraHolder.position = (DefaultCam + new Vector3(-10, 0, -10));
        CameraObject.position = new Vector3(0, MaxCameraHeight, 0);
        zoomtation();

    }
    public virtual void ResetCamera(Vector3 savedposition)
    {
       // cameraObj.transform.position = (savedposition);
    }
    public virtual void ResetCamera(Star StarbeingViewed)
    {
        CameraObject.position = new Vector3(0, MaxCameraHeight, 0);

        CameraHolder.position=(StarbeingViewed.position + new Vector3(-10,0,-10));

        zoomtation();
       

    }
    public virtual void CameraControl()
    {


        float[] input = new float[] { Input.mousePosition.x, Input.mousePosition.y };

        //edge scroll checks if it should run
        EdgeScroll(input[0], input[1]);

        //if key scrolling then pan
        input[0] = Input.GetAxis("Horizontal");
        input[1] = Input.GetAxis("Vertical");
        if (input[0] != 0 || input[1] != 0) { Pan(input[0], input[1]); }

        //if alt key save position to zoom to. if mousewheel then zoom to
        //else release altkey saved position
        //else if mousewheel just regular scroll
        if ((Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)))
        {
            //set new saved positoin if just pressed alt
            if (savedpositionset == false)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                // create a plane at 0,0,0 whose normal points to +Y:
                Plane hPlane = new Plane(Vector3.up, Vector3.zero);
                // Plane.Raycast stores the distance from ray.origin to the hit point in this variable:
                float distance = 0;
                // if the ray hits the plane...
                if (hPlane.Raycast(ray, out distance))
                {

                    savedposition = ray.GetPoint(distance-10);
                    Debug.Log("altzoom destimation:" + savedposition);

                    savedpositionset = true;
                }
            }
        

            if (Input.GetAxis("Mouse ScrollWheel") != 0f)
            {
                AltZoom(Input.GetAxis("Mouse ScrollWheel"));
            }
            if (Input.GetMouseButton(1))
            {
                RotateAround(Input.GetAxis("Mouse X"));
            }
        }
        //release saved ppsition from zoom

        else if ((Input.GetKeyUp(KeyCode.LeftAlt) || Input.GetKeyUp(KeyCode.RightAlt)))
        { savedpositionset = false; }

        //if middle mouse button scroll then zoom
        else if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
                Zoom(Input.GetAxis("Mouse ScrollWheel"));
        }

        //if alt right click or middle mouse button rotate by mouse x position*rotatespeed
        if ( Input.GetMouseButton(1))
        {
            RotateCamera(Input.GetAxis("Mouse X"));
        }


        //CameraController.CameraClamp(player.GalaxyView);

    }

    public void SetCamera(Vector3 pos)
    {
       // cameraObj.transform.position = pos;
    }



    public void EdgeScroll(float xpos, float ypos)
    {
        //horizontal scroll
        if (xpos >= 0 && xpos < ResourceManager.ScrollWidth)
        {
            Pan(-1,0);
        }
        else if (xpos <= Screen.width && xpos > Screen.width - ResourceManager.ScrollWidth)
        {
            Pan(1,0);
        }

        //vertical scroll
        if (ypos >= 0 && ypos < ResourceManager.ScrollWidth)
        {
            Pan(0, -1);
        }
        else if (ypos <= Screen.height && ypos > Screen.height - ResourceManager.ScrollWidth)
        {
            Pan(0, 1);
        }
    }

    //pan
    public virtual void Pan(float horizontal, float vertical)
    {
        //key scroll
        //panobj.rotation = rotationobj.rotation;
        //Vector3 positionnew= panobj.localPosition;
        //positionnew.x += horizontal * ResourceManager.ScrollSpeed;
        //positionnew.z += vertical * ResourceManager.ScrollSpeed;
        //panobj.transform.localPosition = CameraClamp((positionnew));

        //Vector3 move = new Vector3(horizontal* ScrollSpeed, 0, vertical * ScrollSpeed );
        CameraHolder.Translate(Vector3.forward * vertical * Panfactor());
        CameraHolder.Translate(Vector3.right * horizontal * Panfactor());
    }




    public virtual float getZoomLevel()
    {
        return ((CameraObject.transform.localPosition.y - MinCameraHeight) / MaxCameraHeight);
    }

    public virtual void RotateCamera(float rotInput)
    {
        float Yrot= CameraHolder.localRotation.eulerAngles.y + (rotInput * ResourceManager.RotateAmount);
        CameraHolder.localRotation = Quaternion.Euler(CameraHolder.localRotation.eulerAngles.x, Yrot, CameraHolder.localRotation.eulerAngles.z);
        //CameraObject.RotateAround(CameraObject.position, CameraObject.up, rotInput * ResourceManager.RotateAmount);
       


    }
    public virtual void RotateAround(float Mousex)
    {
        Vector3 copy = new Vector3(savedposition.x, CameraHolder.position.y, savedposition.z) ;
        
        CameraHolder.RotateAround(copy, Vector3.up, Mousex * ResourceManager.RotateAmount);

    }
    public virtual void CameraClamp()
    {

    }


    public virtual Vector3 CameraClamp(Vector3 newpos)
    {

        newpos.x = Mathf.Clamp(newpos.x, -MaxCameraRad, MaxCameraRad);
        newpos.z = Mathf.Clamp(newpos.z, -MaxCameraRad, MaxCameraRad);
        newpos.y = Mathf.Clamp(newpos.y, MinCameraHeight, MaxCameraHeight);

        return newpos;
    }

    public virtual float HeightClamp(float newypos)
    {
        return Mathf.Clamp(newypos, MinCameraHeight, MaxCameraHeight);
    }
    public virtual float Panfactor()
    {

        if (getZoomLevel()<.2f)
        {
            return (Mathf.Clamp((ScrollSpeed * CameraObject.position.y) / (100), MinPanSpeed, ScrollSpeed));

        }
        else
        {
            return  ScrollSpeed;

        }
    }
    public virtual float ZoomFactor()
    {

        return (Mathf.Clamp((ScrollSpeedVertical * CameraObject.position.y/100) , MinZoomSpeed, ScrollSpeedVertical));
    }

    public virtual void setZoomlevel(float zoomleveln)
    {
        CameraObject.transform.localPosition = new Vector3(CameraObject.transform.position.x, Mathf.Lerp(MinCameraHeight, MaxCameraHeight, zoomleveln), CameraObject.transform.position.z);
        zoomtation();
    }

    public virtual void AltZoom(float ScrollwheelInput)
    {


        //pan to mouse position relative to floor;
        if (ScrollwheelInput > 0)
        {
            
            Vector3 newposition = Vector3.MoveTowards(CameraHolder.position, savedposition, Panfactor());
            newposition.y = 0;
            CameraHolder.position = newposition;

            newposition = Vector3.MoveTowards(CameraObject.position, savedposition, ZoomFactor());
            newposition.x = 0;
            newposition.z = 0;
            newposition.y = HeightClamp(newposition.y);
            CameraObject.localPosition = newposition;

            zoomtation();

        }
        else
        {
            Vector3 newpsition = CameraObject.localPosition;
            newpsition.y = HeightClamp(newpsition.y + (newpsition.y * (ScrollSpeedVertical * -ScrollwheelInput) / 100));
            CameraObject.localPosition = newpsition;
            zoomtation();

        }
    }
    public virtual void Zoom(float ScrollwheelInput)
    {
        
            Vector3 newpsition = CameraObject.localPosition;
            newpsition.y = HeightClamp(newpsition.y + ((ZoomFactor() * -ScrollwheelInput) ));
            CameraObject.localPosition = newpsition;
            zoomtation();

    }



    public virtual void zoomtation()
    {
        CameraObject.localRotation = Quaternion.Euler(Mathf.Lerp(ZoomedInAngle, ZoomedOutAngle, getZoomLevel()), 0, 0);
        Camera.main.fieldOfView=Mathf.Lerp(MinFieldofView, MaxFieldofView, getZoomLevel());

    }

    public virtual void zoomtation(float zoomlvl)
    {
        CameraObject.transform.localRotation = Quaternion.Euler(Mathf.Lerp(ZoomedInAngle, ZoomedOutAngle, zoomlvl), 0, 0);
    }
}
