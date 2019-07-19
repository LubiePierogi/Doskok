using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlatformScript : MonoBehaviour
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

    public bool isGrowing = false;
    private float growStart;

    public float Power = 1.0f;

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
        transform.localScale += new Vector3(Mathf.Abs(addVec.x), Mathf.Abs(addVec.y), Mathf.Abs(addVec.z));
        transform.localPosition += 0.5f * addVec;

    }

    public void Grow(float amount)
    {
        if (Input.GetKey(KeyCode.W))
        {
            Grow(amount, 1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Grow(amount, 2);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Grow(amount, 3);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Grow(amount, 0);
        }
    }

    void OnMouseEnter()
    {
        isGrowing = true;
        growStart = Time.time;
    }

    void OnMouseExit()
    {
        isGrowing = false;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Rigidbody2D rgbd2d = GetComponent<Rigidbody2D>();
        rgbd2d.AddRelativeForce((transform.position - player.transform.position) * (Time.time - growStart) * Power);
        Debug.Log( (transform.position - player.transform.position) * (Time.time - growStart) * -Power);
    }

    // Start is called before the first frame update
    void Start()

    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrowing)
        {
            Grow(0.1f);
        }


    }
}
