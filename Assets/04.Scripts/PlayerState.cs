using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public enum State : int
    {
        Idle = 0,
        Move = 1,
        Atk = 2
    }

    public State playerState { get; private set; }
    Animator m_playerAnimator;

    private void Start()
    {
        m_playerAnimator = GetComponent<Animator>();
    }

    public void ChangeState(State state)
    {
        if (playerState == state)
            return;

        playerState = state;
        m_playerAnimator.SetInteger("State", (int)playerState);

        switch (playerState)
        {
            case State.Idle:    
                break;
            case State.Move:
                break;
            case State.Atk:
                break;
        }
    }
}
