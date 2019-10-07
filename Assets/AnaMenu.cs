using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class AnaMenu : MonoBehaviour {

    public Text puanText;
    public Text puan;



    void Start()
    {
        int enYüksekSkor = PlayerPrefs.GetInt("EYPkayit");

        int puangelen = PlayerPrefs.GetInt("Puankayit");

        puanText.text = "Max Skor = " + enYüksekSkor;
        puan.text = "Puan= " + puangelen;


        if (puangelen==2)
        {
            GameObject.FindGameObjectWithTag("Reklamm").GetComponent<Reklam>().reklamıgöster();



        }

    }




    public void OyunaGit()
    {

        SceneManager.LoadScene("SahneFlap");


    }


    public void OyunaCık()
    {
        Application.Quit();

    }
}
