using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leafesScaler : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform parent;
    private SpriteRenderer sprite;
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(1 / parent.localScale.x, 1 / parent.localScale.y, 1 / parent.localScale.z);
        sprite.size = parent.localScale;
    }
}
