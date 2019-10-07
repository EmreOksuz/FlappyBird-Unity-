using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunKontrol : MonoBehaviour {
    public GameObject gok1;
    public GameObject gok2;
    public GameObject engel;
    public int kaçAdetE;
    GameObject []Engeller;
    Rigidbody2D fizik1;
    Rigidbody2D fizik2;
    float EngelDeZaman = 0;
    float uzlk=0;
    public float APHız = -1.5f;
    int sayac = 0;
    bool Btş=true;
    void Start () {
        fizik1 = gok1.GetComponent<Rigidbody2D>();
        fizik2 = gok2.GetComponent<Rigidbody2D>();
        fizik1.velocity = new Vector2(-APHız, 0);
        fizik2.velocity = new Vector2(-APHız, 0);

        uzlk = gok1.GetComponent<BoxCollider2D>().size.x;
        Engeller = new GameObject[kaçAdetE];
        for(int i=0;i< Engeller.Length; i++)
        {

            Engeller[i] = Instantiate(engel,new Vector2(-20,-20),Quaternion.identity);
            Rigidbody2D fizikE=Engeller[i].AddComponent<Rigidbody2D>();
            fizikE.gravityScale = 0;
            fizikE.velocity = new Vector2(-APHız, 0);


        }


    }
	
	void Update () {

        if (Btş)
        {

            if (gok1.transform.position.x <= -uzlk)
            {

                gok1.transform.position += new Vector3(uzlk * 2, 0);

            }
            if (gok2.transform.position.x <= -uzlk)
            {

                gok2.transform.position += new Vector3(uzlk * 2, 0);

            }




            EngelDeZaman += Time.deltaTime;
            if (EngelDeZaman > 1.7f)
            {
                EngelDeZaman = 0;
                float Yekseni = Random.Range(-0.7f, 1.1f);
                Engeller[sayac].transform.position = new Vector3(12, Yekseni);
                sayac++;
                if (sayac >= Engeller.Length)
                {
                    sayac = 0;

                }



            }






        }
    }

    public void oyunbitti()
    {
        for(int i = 0; i < Engeller.Length; i++)
        {
            Engeller[i].GetComponent<Rigidbody2D>().velocity =Vector2.zero;
            fizik1.velocity = Vector2.zero;
            fizik2.velocity = Vector2.zero;
        }

        Btş = false;


    }
}
