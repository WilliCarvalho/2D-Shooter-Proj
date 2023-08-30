using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    

}
