using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWarManager : MonoBehaviour
{
    public static UIWarManager instance;
    public UIWarFriendlyRoom FriendlyRoomManager;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

}
