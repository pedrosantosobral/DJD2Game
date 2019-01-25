using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Dialogue type.
/// </summary>
[System.Serializable]
public class Dialogue {

    [TextArea(5,10)]
    //array of dialogue sentenses
    public string[] sentenses;
    //NPC Name
    public string name;
}s
