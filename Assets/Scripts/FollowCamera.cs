using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private SpriteRenderer flip;

    [SerializeField] private float smoothTime = 0.3f;
    private Vector3 offset = new Vector3(0, 0, -10);
    private Vector3 velocity = Vector3.zero;


    void LateUpdate()
    {
        if(target != null)
        {
            float targetXOffset = flip.flipX ? -3f : 3f;

            Vector3 cameraPos = new Vector3(target.position.x + targetXOffset, target.position.y, offset.z);
            transform.position = Vector3.SmoothDamp(transform.position, cameraPos,ref velocity, smoothTime);
        }
    }

}
