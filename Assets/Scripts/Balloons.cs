using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloons : MonoBehaviour
{
    public static Balloons instance;
    private string balloonColor;

    public string BaloonColor
    {
        get
        {
            return balloonColor;
        }
        set
        {
            this.balloonColor = value;
        }
    }
    public virtual void TakeDamage()   // POLYMORPHISM
    {
        Manager.Life -= 5;
    }

    

}
