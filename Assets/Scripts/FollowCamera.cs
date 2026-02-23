using System;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private SpriteRenderer flip;

    [SerializeField] private float smoothTime = 0.3f;
    private Vector3 offset = new Vector3(0, 0, -10);
    private Vector3 velocity = Vector3.zero;

    //границы
    private float minX = -5f;
    private float maxX = 10000000f;


    void LateUpdate()
    {
        if (target != null)
        {
            float targetXOffset = flip.flipX ? -3f : 3f;


            //Берем позицию игрока + оступ взависимости от того куда смотрит Player
            Vector3 cameraPos = new Vector3(target.position.x + targetXOffset, target.position.y, offset.z);

            //Ставив ограничения на движения камеры по границам
            float clampedX = Math.Clamp(cameraPos.x, minX, maxX);

            // Финальная позиция
            Vector3 finalPositionWithClamp = new Vector3(clampedX, cameraPos.y, offset.z);

            transform.position = Vector3.SmoothDamp(transform.position, finalPositionWithClamp, ref velocity, smoothTime);
        }
    }

}
