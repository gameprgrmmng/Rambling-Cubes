using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class oyun_anascript : MonoBehaviour
{
    //float speed = 9;
    float speed;

    public TextMeshProUGUI seviye;

    public TextMeshProUGUI countText;

    public GameObject Player;
    private Rigidbody rb;

    private int skor;

    private float movementX;
    private float movementY;

    //float time=30;//Oyunun suresi
    
    float time=40;

    int level;
    

    int timeGosterge;
    //sonradan time ı converttoint32 olmasi için gereken yapi
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI winText;

    public GameObject tekrarOyna;//Oyunu tekrar baslatmak icin buton

    void Start()
    {
        rb=GetComponent<Rigidbody>();//playerin rigidbody bilgileri aliniyor
        //skor = 0;
        //SetCountText();
        tekrarOyna.SetActive(false);

        if(PlayerPrefs.HasKey("level"))
        {
            level=PlayerPrefs.GetInt("level");
        }
        else
        {
            level=1;
        }


        if(PlayerPrefs.HasKey("hız"))
        {
            speed=PlayerPrefs.GetFloat("hız");

        }
        else
        {
            speed=9;
        }

        if(PlayerPrefs.HasKey("timeKey"))
        {
            time=PlayerPrefs.GetFloat("timeKey");

        }
        else
        {
            //PlayerPrefs.SetFloat("timeKey",40);
            time=40;
        }

        if(PlayerPrefs.HasKey("skorkey"))
        {
            skor=PlayerPrefs.GetInt("skorkey");
            SetCountText();
        }
        else
        {
            skor=0;
            SetCountText();
        }

        if(PlayerPrefs.HasKey("X"))
        {
            Vector3 yenikonum=new Vector3(
                PlayerPrefs.GetFloat("X"),
                PlayerPrefs.GetFloat("Y"),
                PlayerPrefs.GetFloat("Z")
            );

            Player.transform.position=yenikonum;
        }


        seviye=GameObject.Find("Canvas/seviye").GetComponent<TextMeshProUGUI>();
        seviye.text="Seviye: "+level.ToString();


    }


    void SetCountText()
    {
        countText.text="SKOR: "+skor.ToString();

        //if(countText.text=="SKOR: 5")
        //{
        //    SceneManager.LoadScene(3);
        //}
    }

    private void FixedUpdate()
    {
        float moveHorizontal=Input.GetAxis("Horizontal");
        float moveVertical=Input.GetAxis("Vertical");
        Vector3 movement=new Vector3(moveHorizontal,0.0f,moveVertical);
        rb.AddForce(movement*speed);

        Vector3 konum=Player.transform.position;

        PlayerPrefs.SetFloat("X", konum.x);
        PlayerPrefs.SetFloat("Y", konum.y);
        PlayerPrefs.SetFloat("Z", konum.z);

        time-=Time.deltaTime;
        PlayerPrefs.SetFloat("timeKey",time);
        timeText.text=(Convert.ToInt32(time)).ToString();
        if (time<=0f)
        {
            winText.text="SKORUNUZ "+skor;
            Time.timeScale=0;
            tekrarOyna.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);//objenin aktifligi kalkar
            skor=skor+1;
            PlayerPrefs.SetInt("skorkey",skor);
            SetCountText();
            if(skor==10)
            {
                PlayerPrefs.SetFloat("hız",19);
                PlayerPrefs.SetInt("level",2);
                //SceneManager.LoadScene(3);
                SceneManager.LoadSceneAsync(3);
            }
            //Carpisma sonrasi skoru artırır
        }  
    }

    public void tekrarOynaFunction()
    { 
        RestartMethods();
    }

    public void surekaydetme()
    {
        PlayerPrefs.SetFloat("timeKey",time);

    }

    private void RestartMethods()
    {
        Time.timeScale=1;
        Destroy(GameObject.FindWithTag("PickUp"));
        speed=9;
        skor=0;
        countText.text="SKOR: "+skor.ToString();
        level=1;
        seviye.text="Seviye: "+level.ToString();
        time=40;
        tekrarOyna.SetActive(false);
        winText.text = " ";
        Player.transform.position=new Vector3(0,0.5f,0);
        //Oyunu tekrar baslatir
    }

    public void kayitsilme()
    {
        PlayerPrefs.DeleteAll();
    }

}