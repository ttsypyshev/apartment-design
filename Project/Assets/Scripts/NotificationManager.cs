using UnityEngine;
using UnityEngine.UI;

public class NotificationManager : MonoBehaviour
{
    public string inputText = "";

    public GameObject canvasPrefab;
    public GameObject notificationPrefab;
    private float spawnDistance = 0.5f;

    private float time;
    private Text notificationText;

    private void Start()
    {
        notificationText = notificationPrefab.GetComponentInChildren<Text>();
        time = 0f;
    }

    void Update()
    {
        if (inputText != "")
        {
            notificationText.text = inputText;
            inputText = "";
            time = 3f;
        }

        if (time > 0)
        {
            notificationPrefab.SetActive(true);
            canvasPrefab.SetActive(true);
            CanvasMovement();
            time -= Time.deltaTime;
        }
        else
        {
            notificationPrefab.SetActive(false);
            canvasPrefab.SetActive(false);
        }
    }

    void CanvasMovement()
    {
        // Получаем текущий взгляд камеры
        Vector3 gazeDirection = Camera.main.transform.forward;

        // Рассчитываем позицию для спауна меню перед камерой
        Vector3 spawnPosition = Camera.main.transform.position + gazeDirection * spawnDistance;

        // Плавно передвигаем canvas в расчитанной позиции
        canvasPrefab.transform.position =
            Vector3.Lerp(canvasPrefab.transform.position, spawnPosition, Time.deltaTime * 5f);

        // Поворачиваем canvas перпендикулярно взгляду
        canvasPrefab.transform.forward = gazeDirection;
    }
}