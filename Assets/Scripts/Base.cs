using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public BaseType baseType;


    public void SendParticles(Vector3 target)
    {
        Component[] particles = gameObject.GetComponentsInChildren(typeof(Particle));
        Debug.Log(particles.Length);
        foreach (Component p in particles)
        {
            Debug.Log(p.gameObject.name);
            LeanTween.move(p.gameObject, target, 3.0f).setOnComplete(() => Destroy(p.gameObject));
        }
    }
}
