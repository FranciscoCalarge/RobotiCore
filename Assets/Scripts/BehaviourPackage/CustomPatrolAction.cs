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
            Debug.Log("great success");
            return Status.Success;
        }
        else
        {
            Vector3 targetDirection = Vector3.Normalize(currentTarget.transform.position - self.transform.position) * speed * Time.deltaTime;
            self.transform.position += self.transform.forward*targetDirection.magnitude;
            self.transform.rotation =Quaternion.Lerp(self.transform.rotation, Quaternion.LookRotation(targetDirection),Time.deltaTime*2);
        }

        return Status.Running;
    }

    void UpdateTarget()
    {
        currentTargetindex += Mathf.FloorToInt(UnityEngine.Random.value * 3 - 1);
        if (currentTargetindex < 0)
        {
            currentTargetindex=Waypoints.Value.Count-1;
        }else if (currentTargetindex >= Waypoints.Value.Count)
        {
            currentTargetindex = 0;
        };
        currentTarget = Waypoints.Value[currentTargetindex];
    }

    protected override void OnEnd()
    {
    }
}

