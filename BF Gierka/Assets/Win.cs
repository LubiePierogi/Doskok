using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Win : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI winText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.otherCollider.tag == "Player")
        {
            winText.gameObject.SetActive(true);
        }
    }
}
