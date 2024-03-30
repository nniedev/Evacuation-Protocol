using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalDoor : Interaction
{
    public override void Interact()
    {
        if (PlayerPrefs.GetInt("Reator") == 1)
        {
            SceneManager.LoadScene("GoodEnding");
        }
        else
        {
            SceneManager.LoadScene("NormalEnding");
        }
    }
}
