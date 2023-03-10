using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.PlayerLoop;
using UnityEngine.Timeline;
using UnityEngine.VFX;

public class ControlleCamera : MonoBehaviour
{
    private Vector3 entradasJogador;
    private Vector3 comparador = new Vector3(0, 0, 0);
    private CharacterController characterController;
    public float velocidadeJogador = 4f;
    public Transform myCamera;
    float contador;
    public float intervalo;
    private ControllerLamps lamps;
    public GameObject lanterna;
    private string pegarL = "Pressione (E) para pegar.";
    bool pertoPorta;

    AudioSource audio;
    [SerializeField]AudioClip Monster;
    [SerializeField] GameObject TimeBarre;

    private bool estaNoChao;
    [SerializeField] private Transform veficadorChao;
    [SerializeField] private LayerMask cenarioMask;
    [SerializeField] private float alturaDoSalto = 1f;
    private float gravidade = -9.81f;
    private float velocidadeVertical;
    
    [SerializeField] GameObject barreira;

    private PlayableDirector playTimeline;
    CinemachineVirtualCamera cinemachine;

    public delegate void step();
    public static event step OnStep, OnTimeline;

    [Header("Dialogue")]
    public string speechtext;
    private DialogueControl dc;



    [Header("Objetos")]
    [SerializeField] Transform shotgun;
    public string[] Tags;
    public GameObject ObjSegurando;
    [Space(20)]
    public float DistanciaMax;
    public bool Segurando;
    public GameObject Local;
    public LayerMask Layoso;
    

    private void Awake()
    {
        
        characterController = GetComponent<CharacterController>();
        dc = FindObjectOfType<DialogueControl>();
        lamps = FindObjectOfType<ControllerLamps>();
        playTimeline= GetComponent<PlayableDirector>();
        cinemachine = GetComponent<CinemachineVirtualCamera>();
        audio = GetComponent<AudioSource>();
        
        
      
    }

    void Update()
    {
        speechtext = dc.getFala();
        if (speechtext == null)
        {
            Move();
        }
        PegarItens();

    }
    
    void PegarItens() // metodo para pegar a lanterna
    {

        
        if (Segurando == false)
        {
            RaycastHit Hit = new RaycastHit();
            if (Physics.Raycast(shotgun.transform.position, shotgun.transform.forward, out Hit, DistanciaMax, Layoso, QueryTriggerInteraction.Ignore))
            {
                Debug.DrawLine(transform.position, Hit.point, Color.green);

                ObjSegurando = Hit.transform.gameObject;
               
                for (int x = 0; x < Tags.Length; x++)
                {
                    
                    if (Hit.transform.gameObject.CompareTag("Objeto"))
                    {
                        dc.Comandos(pegarL);
                        if (Input.GetKeyDown(KeyCode.E)) // tambem pode ser um botão do teclado...
                        {
                            
                            Segurando = true;
                            ObjSegurando = Hit.transform.gameObject;

                            if (ObjSegurando.GetComponent<Rigidbody>())
                            {
                                Destroy(ObjSegurando);
                                Destroy(barreira);
                                onLanterna();
                            }

                            return;
                        }
                    }
                    else
                    {
                        dc.Comandos("");
                    }


                }
            }
            

        }
    }
    public bool SetpertoPorta(bool pertoPorta)
    {
        this.pertoPorta=pertoPorta;
        return this.pertoPorta;
    }

    void onLanterna()
    {
        lanterna.SetActive(true);
        dc.Comandos(null);
    }

    void offLanterna()
    {
        lanterna.SetActive(false);
    }
    void Move() //metodo para a movimentação do player
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            velocidadeJogador = 4;
            intervalo = 0.6f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            velocidadeJogador = 2f;
            intervalo = 1.2f;
        }
        if (myCamera.transform.rotation.x > 0)
        {
            transform.eulerAngles = new Vector3(0, myCamera.eulerAngles.y,
        myCamera.transform.eulerAngles.z);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, myCamera.eulerAngles.y,
            myCamera.transform.eulerAngles.z);
        }
        entradasJogador = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        entradasJogador = transform.TransformDirection(entradasJogador);
        characterController.Move(entradasJogador * Time.deltaTime * velocidadeJogador);

        if (!entradasJogador.Equals(comparador))
        {
            contador += Time.deltaTime;
            if (contador >= intervalo)
            {
                if (OnStep != null)
                {
                    OnStep();
                }
                contador = 0;
            }
        }

        estaNoChao = Physics.CheckSphere(veficadorChao.position, 0.3f, cenarioMask);
        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao)
        {
            velocidadeVertical = Mathf.Sqrt(alturaDoSalto * -2f * gravidade);
        }
        if (estaNoChao && velocidadeVertical < 0)
        {
            velocidadeVertical = -1f;
        }
        velocidadeVertical += gravidade * Time.deltaTime;
        characterController.Move(new Vector3(0, velocidadeVertical, 0) * Time.deltaTime);
    }

        public void CallMonster()
    {
        audio.clip = Monster;
        audio.Play();
        TimeBarre.SetActive(true);
        if (OnTimeline != null)
        {
            OnTimeline();
        }
       
    }


}