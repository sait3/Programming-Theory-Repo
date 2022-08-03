using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBalloon : Balloons // INHERITANCE
{
    public override void TakeDamage()  // POLYMORPHISM
    {
        Manager.Life -= 2;
    }

    private void OnTriggerEnter(Collider other)
    {
        TakeDamage();
        Destroy(gameObject);
    }
}
