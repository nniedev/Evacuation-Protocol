using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Interações")]
    [SerializeField] private GameObject textHolder;
    [SerializeField] private TMP_Text text;
    [SerializeField] private GameObject documentHolder;
    [SerializeField] private TMP_Text documentText;
    
    private bool inputDetected = false;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
    }
    
    public void ShowText(string newtext)
    {
        text.text = newtext;
        textHolder.SetActive(true);
        StartCoroutine(WaitForInputCoroutine(textHolder));
    }

    public void ShowDocument(string newText)
    {
        documentText.text = newText;
        documentHolder.SetActive(true);
        StartCoroutine(WaitForInputCoroutine(documentHolder));
    }
    
    private void SoftPause()
    {
        Time.timeScale = 0;
        Time.timeScale = 1;
    }
    
    IEnumerator WaitForInputCoroutine(GameObject theGameObject)
    {
        Debug.Log("Aguardando entrada do jogador...");

        // Loop até que um input seja detectado
        while (!inputDetected)
        {
            // Espera pelo próximo frame
            yield return null;

            // Verifica se algum input foi detectado
            if (Input.anyKeyDown)
            {
                // Define a flag indicando que um input foi detectado
                theGameObject.SetActive(false);
                inputDetected = true;
            }
        }

        // Resetar a flag para permitir que o processo seja executado novamente se necessário
        inputDetected = false;

        // Agora que um input foi detectado, continue com o resto da função
        Debug.Log("Input do jogador detectado!");
    }
}
