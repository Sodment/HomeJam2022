using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SelectTexture : MonoBehaviour
{
    public Texture2D texture;

    public VisualEffect visualEffect;
    // Start is called before the first frame update
    void Start()
    {
        visualEffect = gameObject.GetComponent<VisualEffect>();
        visualEffect.SetTexture("mainTexture", texture);
    }
}
