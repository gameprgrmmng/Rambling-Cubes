using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kupolusturma : MonoBehaviour
{
    public GameObject willSpawnCubes;
    int x;
    Vector3 cubePosition=new Vector3(-35f,0f,-2.30f);


    void Start()
    {  
    }

    void Update()
    {
           if(Time.time>x)
        {
            x+=2;
            Instantiate(willSpawnCubes,new Vector3(Random.Range(9.6f,-9.6f),0.5f,Random.Range(9.6f,-9.6f)),Quaternion.identity);
            //verilen aralikta yaratilan kuplerin rastgele siralanmasini sagliyor
            //0.5f=yuksekligi belirtir
            //Quaternion.identity ile rotasyon korunur
        }
    }
}