using System;
using System.Collections.Generic;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "CustomPatrolAction",description:"Substituto do PatrolAction Node", story: "CustomPatrolAction: [Self] Patrols [Waypoints]", category: "Action", id: "d7e5b3c38fef3c4cc22ad96ff56de0da")]
public partial class CustomPatrolAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<List<GameObject>> Waypoints;
    GameObject currentTarget;
    GameObject self;

    int currentTargetindex=0;

    [SerializeReference] public BlackboardVariable<float> minDistance;
    [SerializeReference] public BlackboardVariable<float> speed;


    protected override Status OnStart()
    {
        currentTarget = Waypoints.Value[currentTargetindex];
        self = Self.Value;
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if(Vector3.Distance(self.transform.position, currentTarget.transform.position) <= minDistance)
        {
            UpdateTarget();
            return Status.Success;
        }
        else
        {
            Vector3 targetDirection = Vector3.Normalize(currentTarget.transform.position - self.transform.position) * speed * Time.deltaTime;
            self.transform.position += self.transform.forward*targetDirection.magnitude;
            self.transform.rotation =Quaternion.Lerp(self.transform.rotation, Quaternion.LookRotation(targetDirection),Time.deltaTime*4);
        }

        return Status.Running;
    }

    void UpdateTarget()
    {
        float rand =UnityEngine.Random.value;
        if (rand<.5f)
        {
            currentTargetindex++;
        }else
        {
            currentTargetindex--;
        }

        currentTargetindex = currentTargetindex<0f?Waypoints.Value.Count-1:currentTargetindex;
        currentTargetindex = currentTargetindex> Waypoints.Value.Count - 1 ?0:currentTargetindex;
        currentTarget = Waypoints.Value[currentTargetindex];
    }

    protected override void OnEnd()
    {
    }
}

