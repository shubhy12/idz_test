using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UP : Move
{

    public override void Execute()
    {
        DrawLine(0, -1);
    }


}
