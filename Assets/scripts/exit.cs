using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit : MonoBehaviour
{
   public void exitApplication()
    {
        Application.Quit();
        Debug.Log("application closed");
    }
}
