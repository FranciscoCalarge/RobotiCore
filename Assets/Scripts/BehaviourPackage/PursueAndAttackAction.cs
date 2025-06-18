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
    [SerializeReference] public BlackboardVariable<GameObject> Player;
    [SerializeReference] public BlackboardVariable<Animator> LocalAnimator;
    [SerializeReference] public BlackboardVariable<ZinUnitScript> LocalZinScript;
    [SerializeReference] public BlackboardVariable<float> attackDistance;
    [SerializeReference] public BlackboardVariable<float>defaltShotCD;
    [SerializeReference] public BlackboardVariable<bool>flipForward;

    GameObject self;
    Animator anim;
    GameObject currentTarget;
    ZinUnitScript localEnemyScript;

    float shotCooldown;

    protected override Status OnStart()
    {
        self = Zin.Value;
        anim = LocalAnimator.Value;
        currentTarget = Player.Value.gameObject;
        localEnemyScript = LocalZinScript.Value;

        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        shotCooldown -= Time.deltaTime;
        if (Zin != null && Vector3.Distance(Zin.Value.transform.position, Player.Value.transform.position) < attackDistance.Value)
        {
            float targetOffset = flipForward.Value?-1:1;
            Vector3 targetDirection = Vector3.Normalize(currentTarget.transform.position-self.transform.position+ Vector3.down * 2*targetOffset)  * Time.deltaTime;
            self.transform.rotation = Quaternion.Lerp(self.transform.rotation, Quaternion.LookRotation(targetDirection*targetOffset), Time.deltaTime * 2);
            if (anim != null) {
                anim.SetTrigger("Fire");
            }
            if (localEnemyScript != null) {
                if (shotCooldown < 0) { 
                    localEnemyScript.FireEvent();
                    shotCooldown = defaltShotCD.Value;
                }
            }


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

