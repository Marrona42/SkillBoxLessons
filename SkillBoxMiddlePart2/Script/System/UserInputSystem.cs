using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInputSystem : ComponentSystem
{
    private EntityQuery _inputQuery;

    private InputAction _moveAction;
    private InputAction _shootAction;
    private InputAction _rotateAction;
    private InputAction _dashAction;

    private float2 _moveInput;
    private float2 _rotateInput;
    private float _shootInput;

    protected override void OnCreate()
    {
        _inputQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>());
    }

    protected override void OnStartRunning()
    {
        #region Движение персонажа
        _moveAction = new InputAction("move", binding: "<Gamepad>/rightStick");
        _moveAction.AddCompositeBinding("Dpad")
            .With("Up", "Keyboard>/w")
            .With("Down", "Keyboard>/s")
            .With("Left", "Keyboard>/a")
            .With("Right", "Keyboard>/d");

        _moveAction.performed += context => { _moveInput = context.ReadValue<Vector2>(); };
        _moveAction.started += context => { _moveInput = context.ReadValue<Vector2>(); };
        _moveAction.canceled += context => { _moveInput = context.ReadValue<Vector2>(); };
        _moveAction.Enable();
        #endregion

        #region Поворот персонажа
        _rotateAction = new InputAction("rotate", binding: "<Gamepad>/leftStick");
        _rotateAction.performed += context => { _rotateInput = context.ReadValue<Vector2>(); };
        _rotateAction.started += context => { _rotateInput = context.ReadValue<Vector2>(); };
        _rotateAction.canceled += context => { _rotateInput = context.ReadValue<Vector2>(); };
        _rotateAction.Enable();
        #endregion

        #region Стрельба
        _shootAction = new InputAction("shoot", binding: "<Keyboard>/space");
        _shootAction.performed += context => { _shootInput = 0; };
        _shootAction.started += context => { _shootInput = context.ReadValue<float>(); };
        _shootAction.canceled += context => { _shootInput = context.ReadValue<float>(); };
        _shootAction.Enable();
        #endregion

        #region Рывок
        _dashAction = new InputAction("dash", binding: "<Keyboard>/leftShift");
            
        _dashAction.performed += context => { _shootInput = 0; };
        _dashAction.started += context => { _moveInput = context.ReadValue<float>(); };
        _dashAction.canceled += context => { _moveInput = context.ReadValue<float>(); };
        _dashAction.Enable();
        #endregion
    }

    protected override void OnStopRunning()
    {
        _moveAction.Disable();
        _shootAction.Disable();
        _rotateAction.Disable();
        _dashAction.Disable();
    }

    protected override void OnUpdate()
    {
        Entities.With(_inputQuery).ForEach(
            (Entity entity, ref InputData inputData, ref RotateData rotateData) =>
            {
                inputData.Move = _moveInput;
                inputData.Shoot = _shootInput;
                rotateData.Rotate = _rotateInput;
            });
    }
}
