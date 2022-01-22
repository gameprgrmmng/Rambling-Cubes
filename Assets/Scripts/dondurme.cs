using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dondurme : MonoBehaviour
{
    void Update()
    {
		transform.Rotate(new Vector3(10,20,30)*Time.deltaTime);
        //Oyun nesnesini saniye basina x ekseninde 10,y ekseninde 20 ve z ekseninde 30 derece ile dondurur
    }
}
