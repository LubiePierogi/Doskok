using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlatformScript : MonoBehaviour
{
    public bool isSelected;
    public Renderer rend;
    public LineRenderer line;

    public bool isGrowing = false;
    private float growStart;
    public Vector3 growDir;
    public float Power = 1.0f;
    private Player player;
    void Start()
    {
        rend = GetComponent<Renderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
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



    public void Grow(Vector3 direction)
    {
        
        transform.localScale += new Vector3(Mathf.Abs(direction.x), Mathf.Abs(direction.y), Mathf.Abs(direction.z) );
        transform.localPosition += 0.5f * direction;

    }

    public void Grow(float amount)
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0);
        dir = dir * amount * Time.deltaTime;
        growDir += dir;
        player.futureDir = (growDir)  * Power;
        line.SetPosition(1, growDir);
        Grow(dir);
    }
    

    void OnMouseEnter()
    {
        isGrowing = true;
        growStart = Time.time;

        growDir = Vector3.zero;
        rend.material.color = Color.red;
        
    }

    void OnMouseExit()
    {
        rend.material.color = Color.white;
        isGrowing = false;
        Collider2D coll = GetComponent<Collider2D>();
        List<Collider2D> result= new List<Collider2D>();
        coll.OverlapCollider(new ContactFilter2D(), result);
        foreach (Collider2D collider2D in result)
        {
            collider2D.GetComponent<Rigidbody2D>().AddForce( (growDir)  * Power, ForceMode2D.Impulse);
        }
    }

    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        if (isGrowing)
        {
            Grow(1f);
        }


    }
}
