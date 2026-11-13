using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuitManager : MonoBehaviour
{
    public void QuitBtn()
    {
        Application.Quit();
        Debug.Log("Application has Quit");
    }
}
