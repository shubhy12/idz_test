using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UP : Move
{
    public int abc;

    public override void Execute()
    {
        DrawLine(0, -1);
    }


}

[Serializable]
public class upTest
{
    public int a;
}
