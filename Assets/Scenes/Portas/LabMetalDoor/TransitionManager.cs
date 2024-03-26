using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    [SerializeField] private float PreTime;
    [SerializeField] private Animator CameraAnimator;
    [SerializeField] private Animator DoorAnimator;
    [SerializeField] private float AnimationTime;
    private string _sceneToLoad;

    private void Start()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _sceneToLoad = gameManager.nextRoom;
        StartCoroutine(TransitionRoutine());
    }

    IEnumerator TransitionRoutine()
    {
        // Aguarda até que a cena seja carregada
        yield return new WaitForSeconds(PreTime);

        // Toca a primeira animação
        DoorAnimator.SetTrigger("Open");

        // Aguarda até que a primeira animação termine
        yield return new WaitForSeconds(AnimationTime); // Ajuste esse tempo para a duração da sua animação

        // Toca a segunda animação
        CameraAnimator.Play("Walking");
        
        // Carrega a próxima cena
        SceneManager.LoadScene(_sceneToLoad);
    }
}
