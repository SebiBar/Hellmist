using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player SO")]
public class ScriptablePlayer : ScriptableUnitBase
{
    public PlayerClassType playerClassType; 
}

public enum PlayerClassType
{
    Asura = 0,
    Ankou = 1,
}