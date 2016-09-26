using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
            }
            return instance;
        }
    }

    [HideInInspector]
    public HeroManager heroManager;

    void Awake()
    {
        instance = this;
    }
}
