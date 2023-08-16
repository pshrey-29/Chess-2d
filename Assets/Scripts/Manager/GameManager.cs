using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private StateMachine stateMachine;

    private void Start()
    {
        stateMachine = GetComponent<StateMachine>();
    }

    private void Update()
    {
        stateMachine.UpdateState();
    }
}
