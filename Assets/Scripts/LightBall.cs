using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBall : Ball // INHERITANCE
{

    private Color m_Color = Color.white;
    private Color m_EmissionColor = Color.red;

    public Color color // ENCAPSULATION
    {
        get { return m_Color; } 
        private set { m_Color = value; }
    }

    public Color emissionColor // ENCAPSULATION
    {
        get { return m_EmissionColor; }
        private set { m_EmissionColor = value; } 
    }

    private float intensity = 3.0f;
    private Material material;

    public override void Clicked() // POLYMORPHISM
    {
        StartCoroutine(Lightning());
    }

    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        material = mr.materials[0];

        material.SetColor("_EmissionColor", Color.black);
        DynamicGI.SetEmissive(GetComponent<Renderer>(), Color.black);
    }

    IEnumerator Lightning()
    {
        Color finalColor = m_EmissionColor * Mathf.LinearToGammaSpace(intensity);
        material.SetColor("_EmissionColor", m_EmissionColor * intensity);
        DynamicGI.SetEmissive(GetComponent<Renderer>(), finalColor);

        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
