using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Interações")]
    [SerializeField] private GameObject textHolder;
    [SerializeField] private TMP_Text text;
    
    private bool inputDetected = false;
    
    void Update()
    {
    }
    
    public void ShowText(string newtext)
    {
        text.text = newtext;
        textHolder.SetActive(true);
        StartCoroutine(WaitForInputCoroutine());
    }
    
    private void SoftPause()
    {
        Time.timeScale = 0;
        WaitForInputCoroutine();
        Time.timeScale = 1;
    }
    
    IEnumerator WaitForInputCoroutine()
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
                textHolder.SetActive(false);
                inputDetected = true;
            }
        }

        // Resetar a flag para permitir que o processo seja executado novamente se necessário
        inputDetected = false;

        // Agora que um input foi detectado, continue com o resto da função
        Debug.Log("Input do jogador detectado!");
    }
}
