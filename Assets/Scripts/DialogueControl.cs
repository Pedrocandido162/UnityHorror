using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueControl : MonoBehaviour
{
    [Header("Componentes")]
    public GameObject dialoguebj;
    public Text speechText;
    public Text ActorNameText;
    public Text comandsText;
    public Text comandoObj;

    [Header("Dialogos")]
    public string[] falaPerson;
    public string actorName = "SGT.Candido";
    private int contadorSpeech = 0;
    
    //Scripts
    private ControllerLamps lamps;

    [Header("Munição")]
    public Text Amunnation;
    public int Bullets;
    public int BulletMag;
    public string BulletsText;// Para converter de INT para STRING
    public string BulletMagText;// Para converter de INT para STRING
    [Header("Settings")]
    public float typingspeed;
    private string[] setences;


    private void Start()
    {
        lamps = FindObjectOfType<ControllerLamps>();
        falaPerson = new string[10];
        falaPerson[0] = "Esta tudo escuro aqui...";
        Speech(falaPerson[0], actorName);


        falaPerson[1] = "Comandante na escuta?... Comandante?... Merda!";
        falaPerson[2] = "Minha lanterna não quer ligar...";
        falaPerson[3] = "!!!";
        falaPerson[4] = null;
    }

    private void Update()
    {
        BulletsText = Convert.ToString(Bullets);
        BulletMagText = Convert.ToString(BulletMag);
        Amunnation.text = (BulletsText+"/"+BulletMagText);
        if (Input.GetKeyDown(KeyCode.X) && falaPerson[contadorSpeech] != null)
        {
            contadorSpeech += 1;
            Speech(falaPerson[contadorSpeech], actorName);

            if (contadorSpeech == 2)
            {
                lamps.Onlamp();
            }
            if (contadorSpeech == 3)
            {
                lamps.OffLamp();
            }

        }
    }
    public void Speech(string txt,string actorname)
    {
        dialoguebj.SetActive(true);
        speechText.text = txt;
        ActorNameText.text = actorname;
    }
    public void Comandos(string comands)
    {
        comandsText.text = comands;
    }
    public string ComandosDoor(string comandos)
    {
        comandoObj.text = comandos;
        return comandos;
    }
    public void GetBullets(int Bullets, int BulletsMag)
    {
        this.Bullets= Bullets;
        this.BulletMag= BulletsMag;
      
    }
    public int setBullet()
    {
        return this.Bullets;
    }
    public int setMag()
    {
        return this.BulletMag;
    }

    public string getFala()
    {
        return falaPerson[contadorSpeech];
    }
    
   
}
