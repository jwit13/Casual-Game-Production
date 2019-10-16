using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Random Client", menuName = "Client/Random Client")]
public class Clients : ScriptableObject
{
    public new string name;
    public string bio;
    public Sprite artwork;
    public List<Trait> traits = new List<Trait>();
}
