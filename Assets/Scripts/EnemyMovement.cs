using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.Enemy;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;

    private NavMeshAgent _navMeshAgent;
    private Queue<IEventCommand> _commands;
    private IEventCommand _currentCommand;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.isStopped = false;
        _commands = new Queue<IEventCommand>();
    }

    private void Update()
    {
        SetupCommand();
        ExecuteNextCommand();
    }

    private void SetupCommand()
    {
        if (_currentCommand != null && !_currentCommand.IsFinished()) return;

        var command = new MoveEnemyCommand(player, _navMeshAgent);
        _currentCommand ??= command;
        
        _commands.Enqueue(command);
    }

    private void ExecuteNextCommand()
    {
        if (!_commands.Any())
            return;
        _currentCommand = _commands.Dequeue();
        _currentCommand.Execute();
    }
}