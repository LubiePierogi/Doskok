using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlatformScript : MonoBehaviour
{
    public bool isSelected;
    public Renderer rend;
    
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

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
    private Vector3 growScale;
    public float Power = 1.0f;

    public void Grow(Vector3 direction)
    {
        
        transform.localScale += new Vector3(Mathf.Abs(direction.x), Mathf.Abs(direction.y), Mathf.Abs(direction.z));
        transform.localPosition += 0.5f * direction;

    }

    public void Grow(float amount)
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0);
        Grow(amount*dir);
    }
    

    void OnMouseEnter()
    {
        isGrowing = true;
        growStart = Time.time;
<<<<<<< HEAD
        growScale = transform.localScale;
=======
        rend.material.color = Color.red;
        
>>>>>>> c094f25c1b9ddaaee4eb440f8b707dd5402a74d8
    }

    void OnMouseExit()
    {
        rend.material.color = Color.white;
        isGrowing = false;
<<<<<<< HEAD
        Collider2D coll = GetComponent<Collider2D>();
        List<Collider2D> result= new List<Collider2D>();
        coll.OverlapCollider(new ContactFilter2D(), result);
        foreach (Collider2D collider2D in result)
        {
            collider2D.GetComponent<Rigidbody2D>().AddForce( (growScale-transform.localScale) *(Time.time-growStart) * -Power, ForceMode2D.Impulse);
        }
>>>>>>> c094f25c1b9ddaaee4eb440f8b707dd5402a74d8
    }

    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        if (isGrowing)
        {
            Grow(0.1f);
        }


    }
}
