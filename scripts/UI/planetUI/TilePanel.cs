using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TilePanel : MonoBehaviour
{

    public Toggle TileToggle;
    //public GameObject thispanel;
    public planetPanel PlanetPanel;
    public GameObject TileHolder;
    public LayoutElement thislayoutelement;
    GridLayoutGroup gridLayoutGroup;

    RectTransform rect;


    private void Awake()
    {
        //thispanel = this.gameObject;
        gridLayoutGroup = GetComponent<GridLayoutGroup>();

    }




    public void setup(Tile[] tilelist)
    {


        int arraywidth = (int)Mathf.Sqrt(tilelist.Length);
        rect = GetComponent<RectTransform>();
        float panelwidth = 60*arraywidth;
        thislayoutelement.minWidth = panelwidth;
        thislayoutelement.minHeight = panelwidth;
        for (int y = 0; y < tilelist.Length/ arraywidth; y++)
        {
            for (int x = 0; x < tilelist.Length/ arraywidth; x++)
            {
                int totpos = y * arraywidth + x;



                Toggle temp;
                temp = Instantiate(TileToggle, TileHolder.transform, false);
                temp.GetComponent<RectTransform>().anchoredPosition = new Vector2(x*(panelwidth/ arraywidth),y* (panelwidth / arraywidth)); 
                temp.GetComponent<TileToggle>().tile = tilelist[totpos];
                temp.GetComponentInChildren<Image>().sprite = tilelist[totpos].building == null ? tilelist[totpos].sprite : tilelist[totpos].building.sprite; //tilelist[i].sprite;
                temp.gameObject.SetActive ( true);
            }
        }
    }

    public void ResetTileToggle(BuildButton bbutton)
    {
        foreach(Transform child in TileHolder.transform)
        {
            if (child.GetComponent<TileToggle>().tile == bbutton.tile)
            {
                child.GetComponentInChildren<Image>().sprite = bbutton.tile.building == null ? bbutton.tile.sprite : bbutton.tile.building.sprite;
            }
        }
    }
    
}
