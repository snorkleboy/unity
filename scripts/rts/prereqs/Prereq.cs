using System.Collections;
using System.Collections.Generic;

public abstract class Prereq {

    //the implimentation of this abstract method holds the logic to say if a condition is met depening on data from whatimsearching.

    //abstract sub classes of this impliments generic condition_met, type checks it, and then calls an abtract nongeneric condition_met(type)
    //for example it checks for tile then calls condition_met(tile)
    //sub class of that impliments condition_met(type) and a constructor subsubclass(othertype) that initializes the condition that is searched for in type 
    public abstract bool condition_met<whatIMsearching>(whatIMsearching ab);

}
