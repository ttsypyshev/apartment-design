using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GeneralManager generalManager;

    public GameObject canvasPrefab;
    public GameObject menuPrefab;
    public float spawnDistance = 0.5f;
    private bool statusSpawn = false;

    public GameObject[] pages;
    public Button[] pageButtons;

    private void Start()
    {
        print(pages.Length);
        // Назначаем каждой кнопке свою функцию при нажатии
        for (int i = 0; i < pageButtons.Length; i++)
        {
            int pageIndex = i; // Необходимо для передачи значения в замыкание
            pageButtons[i].onClick.AddListener(() => OnButtonClick(pageIndex));
            print(pages.Length);
        }

        CanvasDeactivation();
    }

    void Update()
    {
        if (generalManager.menu && !statusSpawn)
        {
            print(pages.Length);
            CanvasActivation();
        }
        else if (!generalManager.menu && statusSpawn)
        {
            CanvasDeactivation();
        }
    }

    void CanvasActivation()
    {
        canvasPrefab.SetActive(true);

        // Получаем текущий взгляд камеры
        Vector3 gazeDirection = Camera.main.transform.forward;

        // Рассчитываем позицию для спауна меню перед камерой
        Vector3 spawnPosition = Camera.main.transform.position + gazeDirection * spawnDistance;

        // Передвегаем canvas в расчитанной позиции
        canvasPrefab.transform.position = spawnPosition;

        // Поворачиваем canvas перпендикулярно взгляду
        canvasPrefab.transform.forward = gazeDirection;

        menuPrefab.SetActive(true);
        statusSpawn = true;
    }

    void CanvasDeactivation()
    {
        canvasPrefab.SetActive(false);
        menuPrefab.SetActive(false);
        statusSpawn = false;
    }

    public void OnButtonClick(int buttonType)
    {
        // Проверка, находится ли buttonType в пределах допустимого диапазона индексов
        if (buttonType >= 0 && buttonType < pages.Length)
        {
            // Деактивировать все страницы, кроме выбранной
            for (int i = 0; i < pages.Length; i++)
            {
                pages[i].SetActive(i == buttonType);
            }
        }
        else
        {
            // Ошибка
            Debug.LogError("Invalid buttonType: " + buttonType + ". Array length: " + pages.Length);
        }
    }
}