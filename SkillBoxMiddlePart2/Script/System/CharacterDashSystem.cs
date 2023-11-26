using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class CharacterDashSystem : ComponentSystem
{
    private EntityQuery _dashQuery;

    protected override void OnCreate()
    {
        _dashQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>(),
            ComponentType.ReadOnly<DashData>(),
            ComponentType.ReadOnly<Transform>());
    }

    protected override void OnUpdate()
    {
        Entities.With(_dashQuery).ForEach(
            (Entity entity, Transform transform, ref InputData input, ref DashData dashData) =>
            {
                var pos = transform.position;
                pos += new Vector3(input.Move.x * dashData.DashSpeed, 0, input.Move.y * dashData.DashSpeed);
                transform.position = pos;
            });
    }
}
