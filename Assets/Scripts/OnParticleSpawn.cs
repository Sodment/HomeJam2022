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
                    break;
                }
            case BaseType.enemyBase:
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = partcileSprites["enemyParticle"];
                    break;
                }
        }
    }
}
