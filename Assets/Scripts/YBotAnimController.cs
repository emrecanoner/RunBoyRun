using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YBotAnimController : MonoBehaviour
{
    [SerializeField] private Animator yBot;

    public static YBotAnimController Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    public void Run() 
    {
        yBot.SetTrigger("isRun");
    }

    public void Idle()
    {
        yBot.SetTrigger("isIdle");
    }

    public void Jump()
    {
        yBot.SetTrigger("isJump");
    }

    public void Dye()
    {
        yBot.SetTrigger("isDye");
    }

    public void TurnRight()
    {
        yBot.SetTrigger("isTurnRight");
    }
    public void HappyIdle()
    {
        yBot.SetTrigger("isHappyIdle");
    }

}
