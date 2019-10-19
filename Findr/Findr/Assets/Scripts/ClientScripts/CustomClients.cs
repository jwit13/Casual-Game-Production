using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName ="Custom Client", menuName ="Client/Custom Client")]
public class CustomClients : ScriptableObject
{    
    public new string name;
    public string bio;
    public Sprite artwork;
    public List<ScriptableObject> likedTraits = new List<ScriptableObject>();
    public List<ScriptableObject> dislikedTraits = new List<ScriptableObject>();

}
