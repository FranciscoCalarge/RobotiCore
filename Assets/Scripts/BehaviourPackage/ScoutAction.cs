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

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (Zin != null && Vector3.Distance(Zin.Value.transform.position, MovementScript.Instance.transform.position) > 10f)
        {
            return Status.Running;
        }

        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

