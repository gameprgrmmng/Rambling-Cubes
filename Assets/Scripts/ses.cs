using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ses : MonoBehaviour
{
    private static ses obje=null;

    void Awake()
    {
        if(obje==null)
        {
            obje=this;
            DontDestroyOnLoad(this);

        }
        else if(this!=null)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
