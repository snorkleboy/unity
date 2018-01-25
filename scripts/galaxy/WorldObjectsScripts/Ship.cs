using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship
{
    public string name  { get; set; }
    public int shield   { get; set; }
    public int health   { get; set; }
    public int hull     { get; set; }

    public int maxshield    { get;protected set; }
    public int maxhealth    { get;protected set; }
    public int maxhull      { get;protected set; }

}
