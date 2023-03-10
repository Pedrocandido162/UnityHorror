using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using Unity.Mathematics;

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
    private string actorName = "SGT.Candido";
    private int contadorSpeech = 0;

    [Header("Barra Vida")]
    public Image image;
    private float vida = 20;
    public float vidaMax = 20;
    public float Vida { get { return vida; } set { vida = Mathf.Clamp(value, 0, vidaMax); } }
    //Scripts
    private ControllerLamps lamps;

    [SerializeField] GameObject Pause;
    [SerializeField] Text textMorreu;
    bool PauseDetector= false;

    [Header("Munição")]
    public Text Amunnation;
    public int Bullets;
    public int BulletMag;
    public string BulletsText;// Para converter de INT para STRING
    public string BulletMagText;// Para converter de INT para STRING
    [Header("Settings")]
    public float typingspeed;
    private string[] setences;


    private void Awake()
    {
        Cursor.visible = false;
        Time.timeScale = 1;
        
    }
    private void Start()
    {
        Monster_scavenger.OnDeath += Death;
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
        image.fillAmount = Vida / vidaMax;
        if (Vida <= 0)
        {
            Death("Player");
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !PauseDetector)
            {
                PauseGame();
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && PauseDetector)
            {
                OffPause();
            }
        }
        if (!PauseDetector)
        {
            Cursor.visible = false;
        }
        BulletsText = Convert.ToString(Bullets);
        BulletMagText = Convert.ToString(BulletMag);
        Amunnation.text = (BulletsText+"/"+BulletMagText);
        if (Input.GetKeyDown(KeyCode.Return) && falaPerson[contadorSpeech] != null)
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
    public void VillainAttack(float danoRecebido)
    {
        Vida -= danoRecebido;
    }
    private void PauseGame()
    {
        Time.timeScale = 0;
        Cursor.visible = true; 
        Pause.SetActive(true);
        PauseDetector = true;
    }
    private void OffPause()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        Pause.SetActive(false);
        PauseDetector= false;
    }
    private void Death(string Quem)
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        Pause.SetActive(true);
        switch (Quem)
        {
            case "Player":
                textMorreu.text = "Você Morreu!!";
                break;
            case "Vilao":
                textMorreu.text = "Você ganhou!!";
                break;
        }
        
    
    }
  

    [Obsolete]
    public void ButtonRestart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
   public void ButtonSair()
    {
        Application.Quit(); 
    }


}
