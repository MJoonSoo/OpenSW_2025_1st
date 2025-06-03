using UnityEngine;

public class player_movement : MonoBehaviour
{
    private CharacterController m_controller;
    public float m_speed = 0.7f;
    public Vector3 startPosition = new Vector3(10f, 0.1f, -70f);

    private void Awake()
    {
        m_controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        // 게임 시작 시 시작 위치로 고정
        transform.position = startPosition;

    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 move_dir = (horizontal * transform.right) + (vertical * transform.forward);

        m_controller.Move(move_dir * m_speed);
    }

    public void ResetToStart()
    {
        Debug.Log("플레이어 위치 초기화");
        m_controller.enabled = false; // 위치 변경 전에 비활성화
        transform.position = startPosition;
        m_controller.enabled = true;
    }
}
