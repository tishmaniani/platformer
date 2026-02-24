using System;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private PlayerController player;

    [SerializeField] private float smoothTime = 0.3f;
    [SerializeField] private float topOffset = 2f;
    private Vector3 offset = new Vector3(0, 0, -10);
    private Vector3 velocity = Vector3.zero;

    //границы
    private float minX = -5f;
    private float maxX = 10000000f;


    void LateUpdate()
    {
        if (target != null)
        {
            float targetXOffset = player.FacingDirection * 3f;

            //Берем позицию игрока + оступ взависимости от того куда смотрит Player
            Vector3 cameraPos = new Vector3(target.position.x + targetXOffset, target.position.y + topOffset, offset.z);

            //Ставив ограничения на движения камеры по границам
            float clampedX = Math.Clamp(cameraPos.x, minX, maxX);

            float smoothX = Mathf.SmoothDamp(transform.position.x, clampedX, ref velocity.x, smoothTime);

            //Перемещаем камеру за игроком
            transform.position = new Vector3(smoothX, target.position.y, offset.z);
        }
    }

}
