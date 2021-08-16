using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    public float scrollSpeed = 0.3f;
    private MeshRenderer meshRenderer;
    private string mainTexture = "_MainTex";

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        Vector2 offset = meshRenderer.sharedMaterial.GetTextureOffset(mainTexture);
        offset.y += Time.deltaTime * scrollSpeed;

        meshRenderer.sharedMaterial.SetTextureOffset(mainTexture, offset);
    }
}
