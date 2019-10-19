using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Normal Client", menuName = "Client/Normal Client")]
public class NormalClients : ScriptableObject
{
    public new string name;
    public string bio;
    public Sprite artwork;
    public List<Trait> traits = new List<Trait>();
}
