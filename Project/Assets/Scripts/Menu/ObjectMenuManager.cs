using UnityEngine;
using UnityEngine.UI;

public class ObjectMenuManager : MonoBehaviour
{
    public SpownObject spownObject;

    public GameObject[] planes;
    public Button[] pageButtons;

    private void Start()
    {
        InitializeButtons();
    }

    private void InitializeButtons()
    {
        // Инициализация массива кнопок
        int totalButtons = 0;
        for (int i = 0; i < planes.Length; i++)
        {
            totalButtons += planes[i].transform.childCount; // Подсчитываем общее количество кнопок
        }

        pageButtons = new Button[totalButtons];

        int buttonIndex = 0;
        // Назначаем каждой кнопке свою функцию при нажатии
        for (int i = 0; i < planes.Length; i++)
        {
            int tmp = 0;
            Transform planeTransform = planes[i].transform;
            for (int j = 0; j < planeTransform.childCount; j++)
            {
                Button button = planeTransform.GetChild(j).GetComponent<Button>();
                if (button != null)
                {
                    pageButtons[buttonIndex] = button;

                    int buttonType = buttonIndex; // Необходимо для передачи значения в замыкание
                    button.onClick.AddListener(() => OnButtonClick(buttonType));

                    buttonIndex++;
                    tmp++;
                }
            }

            Debug.Log("Количество объектов на странице " + i + ": " + tmp);
        }

        Debug.Log("Количество объектов на всех страницах: " + totalButtons);
    }

    public void OnButtonClick(int buttonType)
    {
        // Твой существующий код обработки нажатия кнопки
        Debug.Log("Button Clicked: " + buttonType);
        spownObject.Spawn(buttonType);
    }
}