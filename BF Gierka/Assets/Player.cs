using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float V = 0.1f;
    public int styki = 0;
    public float Power = 1.0f;
    public float amount = 3.0f;
    public List<int> kolizje;
    Rigidbody2D rb;
    public Sprite deadSprite;
    public bool defeated = false;
    public GameObject preView;
    public Vector3 futureDir;
    private float LastPath=0.0f;
    private bool sitting = false;
    private LineRenderer line;
    private Collider2D myColl;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        myColl = gameObject.GetComponent<Collider2D>();
        line = gameObject.GetComponent<LineRenderer>();
    }
    public void Faint()
    {
        defeated = true;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        if (deadSprite != null)
            GetComponent<SpriteRenderer>().sprite = deadSprite;
    }

    public void ReadResetKey()
    {
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        ReadResetKey();
        
        if (sitting && Time.time > LastPath + 0.1f)
        {
            LastPath = Time.time;
            line.enabled = true;
            line.SetPosition(0, transform.position);
            line.SetPosition(1, transform.position+ futureDir);
            //GameObject path = Instantiate(preView, transform.position, transform.rotation);
            //Physics2D.IgnoreCollision(path.GetComponent<Collider2D>(), myColl);
            //path.GetComponent<Rigidbody2D>().AddForce(futureDir*10, ForceMode2D.Impulse);
        }
        
        if (styki >= 1 && Input.GetMouseButtonDown(1))
        {
            rb.velocity = Vector2.zero;
        }
        if (styki >= 1 && Input.GetMouseButton(1))
        {
            // int ruchH = Input.GetAxisRaw("Horizontal");
            // int ruchV = Input.GetAxisRaw("Vertical");
            Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            dir = dir * amount * Time.deltaTime;
            rb.AddForce((dir) * Power, ForceMode2D.Impulse);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        Debug.Log(collision.gameObject.tag == "Bouncy");
        if (collision.gameObject.tag == "Bouncy")
        {
            return;
        }
        else
        {
            Debug.Log("wnetrze else");
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0;
            sitting = true;
            styki++;
            kolizje.Add(collision.gameObject.GetInstanceID());
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        line.enabled = false;
        Debug.Log(collision.gameObject.tag);
        Debug.Log(collision.gameObject.tag == "Bouncy");
        if (collision.gameObject.tag == "Bouncy")
        {
            return;
        }
        else
        {
            --styki;
            kolizje.Remove(collision.gameObject.GetInstanceID());
            if (styki == 0)
                rb.gravityScale = 1;
            rb.gravityScale = 1;
            sitting = false;
        }
    }
}