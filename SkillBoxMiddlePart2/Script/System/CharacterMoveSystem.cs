using UnityEngine;
using Unity.Entities;

public class CharacterMoveSystem : ComponentSystem
{
    private EntityQuery _moveQuery;

    protected override void OnCreate()
    {
        _moveQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>(),
            ComponentType.ReadOnly<MoveData>(),
            ComponentType.ReadOnly<Transform>());
    }
    protected override void OnUpdate()
    {
        Entities.With(_moveQuery).ForEach(
            (Entity entity, Transform transform, ref InputData inputData, ref MoveData move) =>
         {
             var pos = transform.position;
             pos += new Vector3(inputData.Move.x * move.Speed, 0, inputData.Move.y * move.Speed);
             transform.position = pos;
         });


    }
}
