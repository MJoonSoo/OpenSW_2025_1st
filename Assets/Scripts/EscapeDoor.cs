using UnityEngine;
using UnityEngine.SceneManagement; // 씬 이동을 위해 필요

public class EscapeDoorTrigger : MonoBehaviour
{
    public CanvasGroup successGroup; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("탈출 성공!");
            // 방법 1: 씬 전환
            // SceneManager.LoadScene("NextScene");
            ScreenFadeManager.Instance.FadeToSuccessAndExit(successGroup);


            // 방법 2: 게임 종료
            // Application.Quit();

            // 에디터 환경에서는 다음 코드도 추가해줘야 종료됨
#if UNITY_EDITOR
            // UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}