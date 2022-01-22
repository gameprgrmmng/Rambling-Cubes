using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    void Start()
    {
        //offset=transform.position-player.transform.position;

        if(PlayerPrefs.HasKey("x"))
        {
            Vector3 konum2=new Vector3(
            PlayerPrefs.GetFloat("x"),
            PlayerPrefs.GetFloat("y"),
            PlayerPrefs.GetFloat("z")
            );

            offset=konum2-player.transform.position;
            
        }
        else
        {
            offset=transform.position-player.transform.position;
        }

    
    }

    void LateUpdate()
    {
        transform.position=player.transform.position+offset;
        //updateler tamamlandiktan sonra calisir

        PlayerPrefs.SetFloat("x",transform.position.x);
        PlayerPrefs.SetFloat("y",transform.position.y);
        PlayerPrefs.SetFloat("z",transform.position.z);
    }
}
