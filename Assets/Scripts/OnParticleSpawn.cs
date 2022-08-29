using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public struct NamedImage
{
    public string name;
    public Sprite sprite;
}

public class OnParticleSpawn : MonoBehaviour
{
    public Base parent;
    public float outerRadius;
    public float innerRadius;
    public Dictionary<string, Sprite> partcileSprites = new Dictionary<string, Sprite>();
    public List<NamedImage> particlesSprites = new List<NamedImage>();

    void Awake()
    {
        foreach (NamedImage ni in particlesSprites)
        {
            partcileSprites[ni.name] = ni.sprite;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        parent = gameObject.transform.parent.GetComponent<Base>();
        switch (parent.baseType)
        {
            case BaseType.allyBase:
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = partcileSprites["allyParticle"];
                    gameObject.GetComponent<Particle>().particleType = ParticleType.allyParticle;
                    break;
                }
            case BaseType.enemyBase:
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = partcileSprites["enemyParticle"];
                    gameObject.GetComponent<Particle>().particleType = ParticleType.enemyParticle;
                    break;
                }
        }
        LeanTween.move(gameObject, RandomPointInAnnulus(innerRadius, outerRadius), 2.0f).setEaseOutElastic();
    }

    public Vector3 RandomPointInAnnulus(float minRadius, float maxRadius)
    {

        var randomDirection = (UnityEngine.Random.insideUnitCircle * transform.position).normalized;

        var randomDistance = UnityEngine.Random.Range(minRadius, maxRadius);

        var point = transform.position + new Vector3(randomDirection.x, randomDirection.y, 0.0f) * randomDistance;

        return point;
    }

}
