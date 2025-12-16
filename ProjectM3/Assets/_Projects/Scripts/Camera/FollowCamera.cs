using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform Target;
    Vector3 newPosition;

    private void LateUpdate()
    {
        if (Target != null)
        {
            newPosition = new Vector3(Target.transform.position.x, Target.transform.position.y, transform.position.z);
            transform.position = newPosition;
        }

    }
}
