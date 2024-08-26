using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitBase : UnitBase
{
    private void Awake()
    {
        GameManager.OnBeforeStateChanged += OnStateChanged;
    }

    private void OnStateChanged(GameState state)
    {

    }
}
