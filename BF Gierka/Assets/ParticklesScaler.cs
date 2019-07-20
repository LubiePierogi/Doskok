using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticklesScaler : MonoBehaviour
{
    public Transform parent;
    private PlatformScript platform;
    private ParticleSystem particle;
    private ParticleSystem.ShapeModule shape;
    private ParticleSystem.EmissionModule emission;
    public float amount = 1f;
    public AnimationCurve amountOverTime;
    public bool LeafsPartickles = false;
    // Start is called before the first frame update
    void Start()
    {
        particle = gameObject.GetComponent<ParticleSystem>();
        platform = parent.gameObject.GetComponent<PlatformScript>();
        shape = particle.shape;
        emission = particle.emission;
    }

    // Update is called once per frame
    void Update()
    {
        if (LeafsPartickles)
        {
            if (parent.localScale != shape.scale)
            {
                if (shape.rotation.z == 0f)
                {

                    shape.scale = new Vector3(parent.localScale.x, 1, 1);
                }
                else
                {
                    shape.scale = new Vector3(parent.localScale.y, 1, 1);
                }
                emission.rateOverTime = new ParticleSystem.MinMaxCurve(amount * shape.scale.x, amountOverTime);
            }
        }
        else
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
            emission.rateOverTime = new ParticleSystem.MinMaxCurve(amount*shape.scale.x, amountOverTime);
        }
        if(!particle.isPlaying && platform.isGrowing)
        {
            particle.Play();
        }
        if (particle.isPlaying && !platform.isGrowing)
        {
            particle.Stop();
        }
        }
    }
}
