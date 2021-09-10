using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.Enemy;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    
    private Renderer _renderer;
    private NavMeshAgent _navMeshAgent;
    private Queue<IEventCommand> _commands;
    private IEventCommand _currentCommand;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.isStopped = false;
        _commands = new Queue<IEventCommand>();
        _renderer = GetComponent<Renderer>();
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
        if (!_commands.Any()) return;
        _currentCommand = _commands.Dequeue();
        _currentCommand.Execute();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.transform.name.Equals(player.name)) return;
        _renderer.material.color = Color.red;
        Destroy(gameObject, 5f);
    }
}