using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FajnaCamera : MonoBehaviour
{
    public Rigidbody2D player;
    public Menu ui;

    public float velocityWeight = 2.0f;
    public float velocitySpeed = 0.02f;
    public float farSpeed = 0.18f;
    public float followSpeed = 0.3f;
    public float defaultSize = 8.0f;
    [Header("Background")]
    public GameObject bg;
    public Vector2 defBg = Vector2.zero;
    public Vector2 bgSpeed = 0.06f * Vector2.one;
    public Sprite[] bgList;
    public SpriteRenderer bgImage;
    public SpriteRenderer futureBg;
    public int curBg;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        bgImage.sprite = bgList[curBg];
        futureBg.sprite = bgList[curBg + 1];
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
           // GetComponent<Camera>().orthographicSize = defaultSize * (1.0f + farSpeed * mult);

            if (bg != null)
            {
                bg.transform.localPosition = defBg + finalCam * (Vector2.one - bgSpeed);
            }

        }

    }

    public void ChangeBackGround()
    {
        curBg = curBg + 1;
        bgImage.sprite = bgList[curBg];
        futureBg.sprite = bgList[curBg + 1];
    }

    private void Update()
    {
        if (player != null)
        {
            var hit = Physics2D.CircleCastAll(player.transform.localPosition, 0.1f, Vector3.one, 0.0f);
            foreach(var xd in hit)
            {
                if(xd.collider.GetComponent<Win>())
                {
                    ui.NextLevel();
                }
            }
        }
    }
}
