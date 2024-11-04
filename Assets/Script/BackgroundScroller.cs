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

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        // Menghitung offset untuk X dan Y
        offsetX -= (Time.deltaTime * scrollSpeed) / 10f; // Offset horizontal
        offsetY -= (Time.deltaTime * scrollSpeed) / 10f; // Offset vertikal (negatif untuk arah bawah)

        // Mengatur offset pada material
        mat.SetTextureOffset("_MainTex", new Vector2(offsetY, offsetX));
    }
}
