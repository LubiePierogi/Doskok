using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Player : MonoBehaviour
{
    public float V = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo = new RaycastHit();
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.transform.position, Vector2.zero);
        if (hit)
        {
            
                GameObject target = hit.transform.gameObject;
            Debug.Log(target);
            PlatformScript tscript = target.GetComponent<PlatformScript>();
                if (tscript)
            {
                //tscript.Grow(V);

            }
           
        }
    }
}
