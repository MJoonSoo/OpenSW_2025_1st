using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFadeManager : MonoBehaviour
{
    public Image blackOverlay;
    public float fadeDuration = 0.5f;

    public static ScreenFadeManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void FadeAndResetPlayer(Transform player, Vector3 startPos)
    {
        StartCoroutine(FadeRoutine(player, startPos));
    }

    private IEnumerator FadeRoutine(Transform player, Vector3 startPos)
    {
        // Fade In (검은 화면)
        yield return StartCoroutine(FadeToAlpha(1f));

        // 위치 이동
        CharacterController cc = player.GetComponent<CharacterController>();
        if (cc != null)
        {
            cc.enabled = false;
            player.position = startPos;
            cc.enabled = true;
        }
        else
        {
            player.position = startPos;
        }

        // Fade Out (화면 복구)
        yield return StartCoroutine(FadeToAlpha(0f));
    }

    private IEnumerator FadeToAlpha(float targetAlpha)
    {
        Color color = blackOverlay.color;
        float startAlpha = color.a;
        float timer = 0f;

        while (timer < fadeDuration)
        {
            float t = timer / fadeDuration;
            color.a = Mathf.Lerp(startAlpha, targetAlpha, t);
            blackOverlay.color = color;
            timer += Time.deltaTime;
            yield return null;
        }

        color.a = targetAlpha;
        blackOverlay.color = color;
    }
}
