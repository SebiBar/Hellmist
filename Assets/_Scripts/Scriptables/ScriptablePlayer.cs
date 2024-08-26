using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player SO")]
public class ScriptablePlayer : ScriptableUnitBase
{
    public PlayerClass PlayerChosenClass; 
}

public enum PlayerClass
{
    Asura = 0,
    Ankou = 1,
}