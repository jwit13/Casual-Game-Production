using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Traits", menuName = "Client/Trait")]
public class Trait : ScriptableObject
{
    //Set up traits.
    public new string name;
    public Color traitColor = new Color();
    
}
