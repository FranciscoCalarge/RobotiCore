using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "PursueAndAttackAction", story: "[Zin] pursues Player", category: "Action", id: "a27489714dbff602e1077fc69b928676")]
public partial class PursueAndAttackAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Zin;
    [SerializeReference] public BlackboardVariable<Animator> LocalAnimator;
    [SerializeReference] public BlackboardVariable<float> attackDistance;

    GameObject self;
    Animator anim;
    GameObject currentTarget;

    protected override Status OnStart()
    {
        self = Zin.Value;
        anim = LocalAnimator.Value;
        currentTarget = MovementScript.Instance.gameObject;

        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (Zin != null && Vector3.Distance(Zin.Value.transform.position, MovementScript.Instance.transform.position) < attackDistance.Value)
        {
            Vector3 targetDirection = Vector3.Normalize(currentTarget.transform.position - self.transform.position)  * Time.deltaTime;
            self.transform.rotation = Quaternion.Lerp(self.transform.rotation, Quaternion.LookRotation(targetDirection), Time.deltaTime * 2);
            anim.SetTrigger("Fire");


            return Status.Running;
        }
        else
        {
            Debug.Log("off range");
        }
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

