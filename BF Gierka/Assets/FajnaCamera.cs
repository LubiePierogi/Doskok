using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FajnaCamera : MonoBehaviour
{
    public Rigidbody2D player;
    public Menu ui;

    public float velocityWeight = 2.0f;
    public float velocitySpeed = 0.02f;
    public float farSpeed = 0.18f;
    public float followSpeed = 0.3f;
    public float defaultSize = 8.0f;

    public GameObject bg;
    public Vector2 defBg = Vector2.zero;
    public Vector2 bgSpeed = 0.1f * Vector2.one;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {
            Vector2 oldCam = transform.localPosition;
            Vector2 playerVelocity = player.GetComponent<Rigidbody2D>().velocity;
            float v = playerVelocity.magnitude;
            float mult = velocitySpeed * v;
            mult = mult / (mult * mult + 1.0f);
            Vector2 destCam = (Vector2)player.transform.localPosition + velocityWeight * mult * playerVelocity.normalized;
            float followAmount = followSpeed * Time.deltaTime;
            Vector2 finalCam = followSpeed * destCam + (1.0f - followSpeed) * oldCam;
            transform.localPosition = new Vector3(finalCam.x, finalCam.y, transform.localPosition.z);
            GetComponent<Camera>().orthographicSize = defaultSize * (1.0f + farSpeed * mult);

            if (bg != null)
            {
                bg.transform.localPosition = defBg + finalCam * (Vector2.one - bgSpeed);
            }

        }

    }

    private void Update()
    {
        if (player != null)
        {
            Debug.Log("xd");
            var hit = Physics2D.CircleCastAll(player.transform.localPosition, 0.1f, Vector3.one, 0.0f);
            foreach(var xd in hit)
            {
                Debug.Log("xdxd");
                if(xd.collider.GetComponent<Win>())
                {
                    ui.NextLevel();
                }
            }
        }
    }
}
