using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrackerScript : MonoBehaviour
{
    #region Singleton
    public static PlayerTrackerScript instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject player;
}
