using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBalloon : Balloons  // INHERITANCE
{
    public override void TakeDamage()  // POLYMORPHISM
    {
        Manager.Life -= 10;
    }

    private void OnTriggerEnter(Collider other)
    {
        TakeDamage();
        Destroy(gameObject);
    }
}
