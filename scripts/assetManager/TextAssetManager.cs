using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TextAssetManager
{

    


    public static List<string> TextToList(TextAsset textfile)
    {
        List<string> namelist = textfile.text.Split("\n"[0]).ToList<string>();
        return namelist;
    }


}
