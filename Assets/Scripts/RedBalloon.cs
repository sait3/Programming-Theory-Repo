using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBalloon : Balloons  // INHERITANCE
{
    public override void TakeDamage()  // POLYMORPHISM
    {
        Manager.Life -= 15;
    }

    private void OnTriggerEnter(Collider other)
    {
        TakeDamage();
        Destroy(gameObject);
    }
}

