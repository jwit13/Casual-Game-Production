using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="Custom Client", menuName ="Client/Custom Client")]
public class CustomClients : ScriptableObject
{
    public new string name;
    public string bio;
    public Sprite artwork;
    public List<Trait> traits = new List<Trait>();
}
