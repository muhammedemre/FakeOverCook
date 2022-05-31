using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanResourceInteractionOfficer : MonoBehaviour
{
    [SerializeField] private HumanActor humanActor;
    [SerializeField] private Transform carryPoint1, carryPoint2, carryPoint3;
    public List<Transform> resourceList = new List<Transform>();
    public Transform carryingPlate;

    public IEnumerator GrabAResource(Transform resource)
    {
    
        resourceList.Add(resource);

        resource.SetParent((carryPoint1.childCount == 0)? carryPoint1 : carryPoint2);
        resource.localPosition = Vector3.zero;
    
        humanActor.HumanAnimationOfficer.PlayHoldItem();
        yield return new WaitForSeconds(0.2f);
        humanActor.HumanAnimationOfficer.PlayLeaveAnItem();
        
    }

    public IEnumerator GrabAPlate(Transform resource)
    {
        carryingPlate = resource;
        carryingPlate.SetParent(carryPoint3);
        carryingPlate.localPosition = Vector3.zero;
        humanActor.HumanAnimationOfficer.PlayHoldItem();
        yield return new WaitForSeconds(1f);
    }

    public Transform LeaveAnItem()
    {
        // StartCoroutine(ChooseTheItem());
        // return itemToLeave;
        return ChooseItemDirect();
    }

    Transform ChooseItemDirect()
    {
        if (carryingPlate != null)
        {
            StartCoroutine(LeaveAnimations(true));
            return carryingPlate;
        }
        else if (resourceList.Count > 0)
        {
            StartCoroutine(LeaveAnimations(false));
            Transform tempResource = resourceList[0];
            resourceList.RemoveAt(0);
            return tempResource;
        }

        return null;
    }

    IEnumerator LeaveAnimations(bool isPlate)
    {
        if (isPlate)
        {
            humanActor.HumanAnimationOfficer.PlayLeaveAnItem(); 
        }
        else
        {
            humanActor.HumanAnimationOfficer.PlayHoldItem();
            yield return new WaitForSeconds(0.3f);
            humanActor.HumanAnimationOfficer.PlayLeaveAnItem();
        }
    }
    

}
