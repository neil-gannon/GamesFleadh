using UnityEngine;
using System.Collections;

public class AttachCamera : MonoBehaviour
{
    public string ObjectToAttachTo = "player";
    private Transform targetTransform;
    public float ZDistance = 10;
    public float YDistance = 5;
    public float XDistance = 0;

    void Start()
    {
        var result = GameObject.Find(ObjectToAttachTo);
        
        if (result != null)
            targetTransform = result.transform;
    }

    void Update()
    {
        if (targetTransform != null)
        {
            transform.transform.position = new Vector3(
                targetTransform.position.x - XDistance, 
                targetTransform.position.y - YDistance, 
                targetTransform.position.z - ZDistance);
        }
    }
}
