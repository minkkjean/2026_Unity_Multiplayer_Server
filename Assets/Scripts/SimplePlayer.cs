using UnityEngine;
using Fusion;

public class SimplePlayer : NetworkBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotateSpeed = 10f; // 캐릭터 회전 속도

    public override void FixedUpdateNetwork()
    {
        if (GetInput<FusionBootstrap.NetworkInputData>(out var inputData))
        {
            Vector3 move = new Vector3(inputData.move.x, 0f, inputData.move.y);

            if (move.sqrMagnitude > 1f)
                move.Normalize();

            transform.position += move * moveSpeed * Runner.DeltaTime;

            // 회전 로직 (빨간색 박스 영역)
            if (move.sqrMagnitude > 0.001f)
            {
                // 이동 방향을 바라보는 목표 회전값 계산
                Quaternion targetRotation = Quaternion.LookRotation(move, Vector3.up);

                // Slerp를 사용하여 현재 회전에서 목표 회전까지 부드럽게 보간
                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    targetRotation,
                    rotateSpeed * Runner.DeltaTime
                );
            }
        }
    }
}