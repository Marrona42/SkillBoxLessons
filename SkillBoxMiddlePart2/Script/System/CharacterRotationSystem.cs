using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public class CharacterRotationSystem : ComponentSystem
{
    private EntityQuery _rotateQuery;

    /// <summary>
    /// Коммент для проверки работы Гита
    /// </summary>

    protected override void OnCreate()
    {
            _rotateQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>(),
            ComponentType.ReadOnly<RotateData>(),
            ComponentType.ReadOnly<Transform>());
    }
    protected override void OnUpdate()
    {
        Entities.With(_rotateQuery).ForEach(
            (Entity entity, Transform transform, ref RotateData rotateData) =>
            {
                Vector3 relativePos = new Vector3(rotateData.Rotate.x, 0f, rotateData.Rotate.y);
                Quaternion targetRot = Quaternion.LookRotation(relativePos);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.DeltaTime * 5f);
            });
    }
}
