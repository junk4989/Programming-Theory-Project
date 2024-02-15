using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBall : Ball  // INHERITANCE
{
    [SerializeField] private ParticleSystem explosionPrefab;

    public override void Clicked() // POLYMORPHISM
    {
        Instantiate(explosionPrefab, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }
}
