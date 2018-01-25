using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using rts;
using UnityEngine.UI;

public class UserInput : MonoBehaviour {
    private Player player;

    public GameManager gameManager;

    public UIManager UImanager;
    public CameraController CameraController;
    public GVCameraController gvcameraController;
    public SSCameraController sscameraController;

    //public GVCameraController gvcameraController;
    //public SSCameraController sscameraController;

    public bool selectOn=false;
    //public Button galaxyviewbutton;

    // Use this for initialization
    void Start () {
        player = GetComponent<Player>();
        gvcameraController = new GVCameraController();
        sscameraController = new SSCameraController();
        CameraController = gvcameraController;
    }

    // Update is called once per frame
    void Update()
    {

        if (player.human)
        {
            CheckHit();
            CameraControl();
        }
    }

    public void CameraControl()
    {
        //camera control

        //make sure proper camera ctronoller is being used
        if (player.GalaxyView && !(CameraController is GVCameraController))
        {
            Debug.Log("switching to GVcamera controller in userinput   galview:"+ player.GalaxyView);
            CameraController = gvcameraController;
        }
        else if (!(player.GalaxyView) && !(CameraController is SSCameraController))
        {
            Debug.Log("switching to SScamera controller in userinput     galview:" + player.GalaxyView);
            CameraController = sscameraController;
        }

        CameraController.CameraControl();
    }
    public void CameraReset()
    {
        //make sure proper camera ctronoller is being used
        if (player.GalaxyView && !(CameraController is GVCameraController))
        {
            Debug.Log("switching to GVcamera controller in userinput   galview:" + player.GalaxyView);
            CameraController = gvcameraController;
        }
        else if (!(player.GalaxyView) && !(CameraController is SSCameraController))
        {
            Debug.Log("switching to SScamera controller in userinput     galview:" + player.GalaxyView);
            CameraController = sscameraController;
        }
        CameraController.ResetCamera();
    }
    public void CameraReset(Star starlastviewed)
    {
        //make sure proper camera ctronoller is being used
        if (player.GalaxyView && !(CameraController is GVCameraController))
        {
            Debug.Log("switching to GVcamera controller in userinput   galview:" + player.GalaxyView);
            CameraController = gvcameraController;
        }
        else if (!(player.GalaxyView) && !(CameraController is SSCameraController))
        {
            Debug.Log("switching to SScamera controller in userinput     galview:" + player.GalaxyView);
            CameraController = sscameraController;
        }
        if (starlastviewed != null)
        {
            CameraController.ResetCamera(starlastviewed);
        }
        else
        {
            CameraController.ResetCamera();
        }
    }
    private void CheckHit()
    {

        Ray mouseray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(mouseray,out hit))
        {

            if (hit.transform.tag == "galaxyStar")
            {
                UImanager.Select(hit);
                selectOn = true;

                if (Input.GetMouseButtonDown(0))
                {
                    gameManager.DisplaySolarSystem(hit.transform.gameObject);
                    player.StarSystemViewed = gameManager.ObjectToStar(hit.transform.gameObject);

                    Star star1 = gameManager.ObjectToStar(hit.transform.gameObject);
                    Debug.Log(star1.starName + "  number of planets:" + star1.numberOfPlanets + "  number of planets from planetlist:"+ star1.planetList.Count);

                    CameraController.ResetCamera();
                }
            }
         }
        else if(selectOn)
        {
            selectOn = false;
            UImanager.DeSelect();

        }
    }
}
