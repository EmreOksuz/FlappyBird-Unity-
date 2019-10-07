using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Kontrol : MonoBehaviour {

    // Use this for initialization

    public Sprite[] KusSprite;
    bool ilerigerikontrol = true;
   SpriteRenderer spriteRenderer;
    int kusSayac = 0;
    float kusAniZaman = 0;
    Rigidbody2D fizik;
    int Puan = 0;
    public Text puanText;
    bool OyunBitti = true;
    OyunKontrol oyunKont;
    AudioSource []sesler;
    int EnyüksekPuan=0;
    
    void Start () {

        spriteRenderer = GetComponent<SpriteRenderer>();
        fizik = GetComponent<Rigidbody2D>();
        oyunKont = GameObject.FindGameObjectWithTag("OK").GetComponent<OyunKontrol>();
        sesler = GetComponents<AudioSource>();
        EnyüksekPuan = PlayerPrefs.GetInt("EYPkayit");  

    }


    void Update()
    {
       
        if (Input.GetMouseButtonDown(0)&& OyunBitti)
        {
            fizik.velocity = new Vector2(0, 0); //hız 0 sonra kuvvet uyguladık.
            fizik.AddForce(new Vector2(0,150));
            sesler[0].Play();



        }
        if (fizik.velocity.y > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 35);

        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, -35);


        }


        animasyon();
        

            
        
    }

    void animasyon()
    {

        kusAniZaman += Time.deltaTime;
        if (kusAniZaman>0.2f)
        {
            kusAniZaman = 0;

            if (ilerigerikontrol)
            {
                spriteRenderer.sprite = KusSprite[kusSayac];
                kusSayac++;
                if (kusSayac == KusSprite.Length)
                {
                    kusSayac--;
                    ilerigerikontrol = false;

                }

            }
            else
            {
                kusSayac--;
                spriteRenderer.sprite = KusSprite[kusSayac];
                if (kusSayac == 0)
                {
                    kusSayac++;
                    ilerigerikontrol = true;

                }
            }
        }

       






    }
   
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "puan")
        {
            Puan++;
            puanText.text = "Puan=" + Puan;
            sesler[1].Play();

        }

        if (col.gameObject.tag == "engel")
        {

            OyunBitti = false;

            sesler[2].Play();

            oyunKont.oyunbitti();
            GetComponent<CircleCollider2D>().enabled=false;
            if (Puan > EnyüksekPuan)
            {
                EnyüksekPuan = Puan;
                PlayerPrefs.SetInt("EYPkayit",EnyüksekPuan);  //kaydediyor.

            }
            Invoke("anaMenuyeDon",1.5f);
        }
    }
    void anaMenuyeDon()
    {
        PlayerPrefs.SetInt("Puankayit",Puan);
        SceneManager.LoadScene("AnaMenu");
        


    }



}
