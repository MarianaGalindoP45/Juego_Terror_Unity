using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Perdiste : MonoBehaviour
{

    public void Reiniciar ()
    {
        SceneManager.LoadScene(1);
    }

    public void Salir ()
    {
        SceneManager.LoadScene(0);
    }
}
