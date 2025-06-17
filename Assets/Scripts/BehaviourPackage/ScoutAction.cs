using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "ScoutAction", story: "[Zin] Searches for Player", category: "Action", id: "3676c442473c620a240e76326817574e")]
public partial class ScoutAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Zin;
    [SerializeReference] public BlackboardVariable<GameObject> Player;
    [SerializeReference] public BlackboardVariable<float> scoutDistance;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (Zin != null && Vector3.Distance(Zin.Value.transform.position, Player.Value.transform.position) > scoutDistance.Value)
        {
            return Status.Running;
        }

        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

