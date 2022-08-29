using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParticle : MonoBehaviour
{
    public float spawnTimer;
    public GameObject particlePrefab;
    public short particleLimit = 40;
    private short aliveParticles = 0;
    float timer = 0.0f;
    void Update()
    {
        if (timer >= spawnTimer && aliveParticles < particleLimit)
        {
            Instantiate(particlePrefab, transform.position, Quaternion.identity, gameObject.transform);
            timer = 0.0f;
            aliveParticles += 1;
        }
        timer += Time.deltaTime;
    }
}
