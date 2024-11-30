using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeSpeak : MonoBehaviour
{
    public Animator Anim;
    public GameObject Empty; //analog of button

    public Animator TheDarkest;
    public GameObject Dark;

    public Transform FBut;
    public Transform FGreen;
    public Transform Red;
    public GameObject But;

    public Moving player;

    public int isFinish; //0 - no, 1 - wait, 2 - youredead

    [Header("Comp")]
    public GameObject button;
    public Transform BuTr;

    [Header("Dialogs")]
    public HiS d0;
    public NoSouls dN;
    public FirstSouls d1;
    public SecondSouls d2;
    public ThirdSouls d3;
    public ForthSouls d4;
    public FifthSouls d5;
    public SixthSouls d6;
    public SeventhSouls d7;

    public AfterSeventh a7;
    public NoWayHome NWH;

    void Start()
    {
        Empty.SetActive(false);
        FBut.position = Red.position;
        But.SetActive(false);
        isFinish = 0;
        Dark.SetActive(false);
    }


    void Update()
    {
        if (Empty.activeInHierarchy && player.enabled == true && isFinish < 2)
        {
            FBut.position = FGreen.position;
            But.SetActive(true);
        }
        else
        {
            FBut.position = Red.position;
            But.SetActive(false);
        }


        if (Empty.activeInHierarchy && player.enabled == true && isFinish == 2 && Input.GetKeyDown(KeyCode.E))
        {
            NWH.enabled = true;
            NWH.StartDialog();
            Empty.SetActive(false);
            player.enabled = false;

            Dark.SetActive(true);
            TheDarkest.Play("TheDarkest");

            Debug.Log(CanvasAnims.Ep);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Empty.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Empty.SetActive(false);
        }
    }

    public void Dia()
    {
        if (CanvasAnims.Ep > 0 && CanvasAnims.Souls < 7 && isFinish == 0) //No soulse
        {
            dN.enabled = true;
            dN.StartDialog();
            Empty.SetActive(false);
            player.enabled = false;

            Debug.Log(CanvasAnims.Ep);
        }

        if (CanvasAnims.Ep == 0) //Start dialog
        {
            d0.enabled = true;
            d0.StartDialog();
            Empty.SetActive(false);
            player.enabled = false;

            Debug.Log(CanvasAnims.Ep);
        }

        if (CanvasAnims.Ep == 1 && CanvasAnims.Souls == 7) //first time bring souls
        {
            d1.enabled = true;
            d1.StartDialog();
            Empty.SetActive(false);
            player.enabled = false;

            Debug.Log(CanvasAnims.Ep);
        }

        if (CanvasAnims.Ep == 2 && CanvasAnims.Souls == 7) //second time bring souls
        {
            d2.enabled = true;
            d2.StartDialog();
            Empty.SetActive(false);
            player.enabled = false;

            Debug.Log(CanvasAnims.Ep);
        }

        if (CanvasAnims.Ep == 3 && CanvasAnims.Souls == 7) //third time bring souls
        {
            d3.enabled = true;
            d3.StartDialog();
            Empty.SetActive(false);
            player.enabled = false;

            Debug.Log(CanvasAnims.Ep);
        }

        if (CanvasAnims.Ep == 4 && CanvasAnims.Souls == 7) //fourth time bring souls
        {
            d4.enabled = true;
            d4.StartDialog();
            Empty.SetActive(false);
            player.enabled = false;

            Debug.Log(CanvasAnims.Ep);
        }

        if (CanvasAnims.Ep == 5 && CanvasAnims.Souls == 7) //fourth time bring souls
        {
            d5.enabled = true;
            d5.StartDialog();
            Empty.SetActive(false);
            player.enabled = false;

            Debug.Log(CanvasAnims.Ep);
        }
        if (CanvasAnims.Ep == 6 && CanvasAnims.Souls == 7) //fourth time bring souls
        {
            d6.enabled = true;
            d6.StartDialog();
            Empty.SetActive(false);
            player.enabled = false;

            Debug.Log(CanvasAnims.Ep);
        }
        if (CanvasAnims.Ep == 7 && CanvasAnims.Souls == 7) //fourth time bring souls
        {
            d7.enabled = true;
            d7.StartDialog();
            Empty.SetActive(false);
            player.enabled = false;

            Debug.Log(CanvasAnims.Ep);
        }

        if (CanvasAnims.Ep == 8 && isFinish == 1) //fourth time bring souls
        {
            a7.enabled = true;
            a7.StartDialog();
            Empty.SetActive(false);
            player.enabled = false;

            Debug.Log(CanvasAnims.Ep);
        }
    }

    public void Finish()
    {
        CanvasAnims.Ep = 9;
        isFinish = 2;
        Anim.Play("Strange_Die");

        //button.SetActive(false);
        BuTr.position = Red.position;
        player.enabled = true;
    }

}
