using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public float velocityX = -0.005f;
    public float velocityY = -0.005f;
    private float curX;
    private float curY;
    void Start()
    {
        curX = GetComponent<Renderer>().material.mainTextureOffset.x;
        curY = GetComponent<Renderer>().material.mainTextureOffset.y;

    }

    // Update is called once per frame
    void Update()
    {
        curX += Time.deltaTime * velocityX;
        curY += Time.deltaTime * velocityY;
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(curX, curY));

    }
}
