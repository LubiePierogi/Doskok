using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muzyczka : MonoBehaviour
{
    static public Muzyczka instance = null;
    static public List<Muzyczka> toDelete = new List<Muzyczka>();
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            toDelete.Add(this);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (this == instance)
            while(toDelete.Count > 0)
            {
                var haha = toDelete[0];
                toDelete.Remove(haha);
                Destroy(haha.gameObject);
            }
    }
}
