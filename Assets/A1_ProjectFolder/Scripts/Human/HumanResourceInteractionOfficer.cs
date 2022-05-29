using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanResourceInteractionOfficer : MonoBehaviour
{
    [SerializeField] private HumanActor HumanActor;
    [SerializeField] private Transform carryPoint1, carryPoint2;
    public List<Transform> resourceList = new List<Transform>();

    public IEnumerator GrabAResource(Transform resource)
    {
        resourceList.Add(resource);

        resource.SetParent((carryPoint1.childCount == 0)? carryPoint1 : carryPoint2);
        
        HumanActor.HumanAnimationOfficer.PlayHoldItem();
        yield return new WaitForSeconds(0.2f);
        HumanActor.HumanAnimationOfficer.PlayLeaveAnItem();
    }
}
