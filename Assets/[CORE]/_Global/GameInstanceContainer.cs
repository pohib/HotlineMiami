using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstanceContainer : Singleton<GameInstanceContainer>
{
    public ItemsListConfig itemsListConfig;

    
    void Start()
    {
        DontDestroyOnLoad(this);
    }
}
