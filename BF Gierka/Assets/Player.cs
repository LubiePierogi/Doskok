using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float V = 0.1f;
    Rigidbody2D rigidbody;

    public void ReadResetKey()
    {
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
    public GameObject preView;
    private float LastPath=0.0f;
    private bool sitting = false;
    private Collider2D myColl;
    public Vector3 futureDir;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        myColl = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ReadResetKey();
       
        if (sitting && Time.time > LastPath + 0.1f)
        {
            LastPath = Time.time;
            //GameObject path = Instantiate(preView, transform.position, transform.rotation);
            //Physics2D.IgnoreCollision(path.GetComponent<Collider2D>(), myColl);
            //path.GetComponent<Rigidbody2D>().AddForce(futureDir*10, ForceMode2D.Impulse);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        rigidbody.velocity = Vector2.zero;
        rigidbody.gravityScale = 0;
        sitting = true;
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        rigidbody.gravityScale = 1;
        sitting = false;
    }
}
