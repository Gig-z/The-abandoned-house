using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FirstSouls : MonoBehaviour
{
    public TextMeshProUGUI textHolder;
    public string[] sentences;
    public int index;
    public float typeSpeed = 0.04f;
    public Moving player;
    public GameObject Pala;

    public PanelLoc Palala;

    private void Start()
    {
        Pala.SetActive(false);
    }

    public void StartDialog()
    {
        StartCoroutine(Type());
    }

    void Update()
    {
        if (textHolder.text == sentences[index])
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                NextSentence();
            }
        }

    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textHolder.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    public void NextSentence()
    {
        if (index < sentences.Length - 1)
        {
            index++;
            textHolder.text = "";
            StartCoroutine(Type());
            player.enabled = false;
        }
        else
        {
            textHolder.text = "";
            index = 0;
            //player.enabled = true;
            this.enabled = false;

            CanvasAnims.Ep = 2;
            CanvasAnims.Souls = 0;
            Pala.SetActive(true);
        }
    }
}
