using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraivityBall : MonoBehaviour
{

    private float baseScaleX = 1;
    private float baseScaleY = 1;
    private bool isGrowing = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrowing)
        {
            Grow();
        }
    }

    private void Grow()
    {
        var compVector = new Vector2(0, 0);
        baseScaleX += 0.05F;
        baseScaleY += 0.05F;
        transform.localScale = new Vector3(baseScaleX, baseScaleY, 1);
    }

    void OnMouseEnter()
    {
        isGrowing = true;

    }
    void OnMouseExit()
    {
        isGrowing = false;
    }
}
