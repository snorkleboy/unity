using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    private TextMesh NamePlate;
    public GameObject timetext;
    public GameObject SelectionIcon;


    // Use this for initialization

    private void Awake()
    {
        CreateSelectionIcon();
        NamePlate = CreateNamePlate();
        
    }

    public TextMesh CreateNamePlate()
    {

        TextMesh text = new GameObject("name plate").AddComponent<TextMesh>();
        text.transform.SetParent(this.transform);
        text.anchor = TextAnchor.MiddleCenter;
        text.alignment = TextAlignment.Center;
        text.color = Color.cyan;
        text.fontSize = 10;
        return text;
    }
    public void AffixNameplate(GameObject starobj)
    {



        NamePlate.name=(starobj.name + "name plate");
        NamePlate.transform.position = starobj.transform.position;
        NamePlate.text = starobj.name;
        NamePlate.transform.Translate(new Vector3(0, -1.5f, 0));
        NamePlate.transform.forward=(Camera.main.transform.forward);
        NamePlate.gameObject.SetActive(true);

    }
    public void CreateNamePlate(GameObject starobj)
    {
        
        TextMesh text = new GameObject(starobj.name +"name plate").AddComponent<TextMesh>();
        //NamePlates.Add(text.gameObject);
        text.transform.SetParent(starobj.transform);
        text.text = starobj.name;
        text.transform.localPosition = new Vector3(0, -2f, 0);
        text.anchor = TextAnchor.MiddleCenter;
        text.alignment = TextAlignment.Center;
        text.color = Color.cyan;
        text.fontSize = 20;

        
    }

    public void CreateSelectionIcon()
    {
        SelectionIcon = GameObject.Instantiate(SelectionIcon);
        SelectionIcon.transform.localScale *= 2;
        SelectionIcon.SetActive(false);
    }
    public void MoveSelectionIcon(RaycastHit hitObj)
    {
        SelectionIcon.SetActive(true);
        SelectionIcon.transform.position = hitObj.transform.position;
    }
    public void DeSelect()
    {
        SelectionIcon.SetActive(false);
        NamePlate.transform.gameObject.SetActive(false);
    }
    public void Select(RaycastHit hit)
    {
        MoveSelectionIcon(hit);
        AffixNameplate(hit.transform.gameObject);
    }


}


