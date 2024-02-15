using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBall : Ball
{
    [SerializeField] private ParticleSystem explosionPrefab;

    public override void Clicked()
    {
        Instantiate(explosionPrefab, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }
}
