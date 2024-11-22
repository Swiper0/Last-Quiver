using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Range(-1f, 1f)]
    public float scrollSpeed = 0.5f;
    private float offsetX;
    private float offsetY;
    private Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        offsetX -= (Time.deltaTime * scrollSpeed) / 10f;
        offsetY -= (Time.deltaTime * scrollSpeed) / 10f;

        mat.SetTextureOffset("_MainTex", new Vector2(offsetY, offsetX));
    }
}
