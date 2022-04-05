using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public float backgroundSpeed;
    private Renderer backgroundRenderer;

    // Update is called once per frame
    private void Start()
    {
        GameObject background = GameObject.FindGameObjectWithTag("Background");
        backgroundRenderer = background.GetComponentInChildren<Renderer>();
    }

    void Update()
    {
        backgroundRenderer.material.mainTextureOffset += new Vector2(backgroundSpeed * Time.deltaTime, 0);
    }
}
