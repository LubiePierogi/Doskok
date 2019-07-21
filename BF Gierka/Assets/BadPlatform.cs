using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadPlatform : MonoBehaviour
{

    private Oscilator oscilator;

    private void Awake()
    {
        oscilator = GetComponent<Oscilator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.Faint();
        }

        oscilator.enabled = false;
    }
}
