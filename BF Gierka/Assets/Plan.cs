using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plan : MonoBehaviour
{
    public bool isSelected;

    public float GetBorder(int direction)
    {
        float ret = 0.0f;
        Vector2 place = transform.localPosition;
        Vector2 scale = transform.localScale;
        switch (direction)
        {
            case 0:
                ret = place.x + scale.x;
                break;
            case 1:
                ret = place.y + scale.y;
                break;
            case 2:
                ret = place.x - scale.x;
                break;
            case 3:
                ret = place.y - scale.y;
                break;
        }
        return ret;
    }

    public void Grow(float amount, int direction)
    {
        // direction:
        // 0 right
        // 1 up
        // 2 left
        // 3 down
        Vector3 addVec = Vector3.zero;
        switch (direction)
        {
            case 0:
                addVec = new Vector3(amount, 0.0f, 0.0f);
                break;
            case 1:
                addVec = new Vector3(0.0f, amount, 0.0f);
                break;
            case 2:
                addVec = new Vector3(-amount, 0.0f, 0.0f);
                break;
            case 3:
                addVec = new Vector3(0.0f, -amount, 0.0f);
                break;
        }
        transform.localScale = Vector3.Scale(Vector3.one + addVec, transform.localScale);
        transform.localPosition += addVec;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Grow(0.8f * Time.deltaTime, 1);
        /*
        if (isSelected)
        {
            GetComponent<SpriteRenderer>.
        }*/
    }
}
