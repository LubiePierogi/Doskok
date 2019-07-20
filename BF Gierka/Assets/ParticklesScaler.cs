using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticklesScaler : MonoBehaviour
{
    public Transform parent;
    private ParticleSystem particle;
    public ParticleSystem.ShapeModule shape;
    // Start is called before the first frame update
    void Start()
    {
        particle = gameObject.GetComponent<ParticleSystem>();
        Debug.Log(particle);
        shape = particle.shape;
        Debug.Log(shape);
    }

    // Update is called once per frame
    void Update()
    {
        if (parent.localScale != shape.scale ) {
            if (shape.rotation.z==0f)
            {
                shape.scale = new Vector3( parent.localScale.x,1,1);
            }
            else
            {
                shape.scale = new Vector3(parent.localScale.y, 1, 1);
            }
           
        }
    }
}
