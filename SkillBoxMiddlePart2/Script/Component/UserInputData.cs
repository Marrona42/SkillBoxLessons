using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using Unity.Entities;

public class UserInputData : MonoBehaviour, IConvertGameObjectToEntity
{
    public float speed;

    public MonoBehaviour _ShootAction;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new InputData());
        dstManager.AddComponentData(entity, new RotateData());
        dstManager.AddComponentData(entity, new DashData
        {
            DashSpeed = speed / 5
        });

        dstManager.AddComponentData(entity, new MoveData
        {
            Speed = speed / 100
        });

        if (_ShootAction != null && _ShootAction is IAbility ability)
        {
            dstManager.AddComponentData(entity, new ShootData());
        }
    }
}

public struct InputData : IComponentData
{
    public float2 Move;
    public float Shoot;
}

public struct MoveData : IComponentData
{
    public float Speed;
}

public struct ShootData : IComponentData
{

}

public struct RotateData : IComponentData
{
    public float2 Rotate;
}

public struct DashData : IComponentData
{
    public float DashSpeed;
}