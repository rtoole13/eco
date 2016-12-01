using UnityEngine;
using System;
using System.Collections;

public abstract class Role
{

    public virtual void checkStock()
    {
        throw new NotImplementedException();
    }

    public virtual void performProduction()
    {
        throw new NotImplementedException();
    }
}
