using UnityEngine;

public class GeneralManager : MonoBehaviour
{
    public NotificationManager notificationManager;

    // public GameObject MenuImage;
    public GameObject CenterImage;

    //Category 1
    public bool movement = false; //Передвижение
    public bool isTeleporting = false;
    public bool isMoving = false;
    public bool isHeight = false;

    //Category 2
    public bool edit = false; //Редактирование
    public bool isChoiceObjects = false;
    public bool isMovingObjects = false;
    public bool isSlantObjects = false;

    //Category 3
    public bool menu = false; //Меню предметов

    //Category 4
    public bool setting = false; //Настройки

    private void Start()
    {
        // MenuImage.SetActive(false);
        CenterImage.SetActive(true);
    }

    private void Update()
    {
        if (!edit && !menu && !setting && !movement)
        {
            CenterImage.SetActive(false);
            isTeleporting = false;
            isMoving = false;
            isHeight = false;
            isChoiceObjects = false;
            isMovingObjects = false;
            isSlantObjects = false;
        }

        if (!edit && !menu && !setting && Input.GetKeyDown(KeyCode.Alpha1)) //Передвижение
        {
            print("Вошёл в режим передвижения");
            movement = !movement;
            setting = false;
            menu = false;
            edit = false;

            if (movement)
                notificationManager.inputText = "Вошёл в режим передвижения";
            else
                notificationManager.inputText = "Вышел из режима передвижения";
        }

        if (movement && Input.GetKeyDown(KeyCode.Alpha2)) //Передвижение_телепортирование
        {
            print("Режим телепортирования");
            // MenuImage.SetActive(false);
            CenterImage.SetActive(false);

            isTeleporting = !isTeleporting;
            isMoving = false;
            isHeight = false;

            if (isTeleporting)
                notificationManager.inputText = "Включён режим телепортирования";
            else
                notificationManager.inputText = "Выключен режим телепортирования";
        }

        if (movement && Input.GetKeyDown(KeyCode.Alpha3)) //Передвижение_ходьба
        {
            print("Режим ходьбы");
            // MenuImage.SetActive(false);
            CenterImage.SetActive(false);

            isMoving = !isMoving;
            isTeleporting = false;
            isHeight = false;

            if (isMoving)
                notificationManager.inputText = "Включён режим ходьбы";
            else
                notificationManager.inputText = "Выключен режим ходьбы";
        }

        if (movement && Input.GetKeyDown(KeyCode.Alpha4)) //Передвижение_изменение высоты
        {
            print("Режим изменения высоты");
            // MenuImage.SetActive(false);
            CenterImage.SetActive(false);

            isHeight = !isHeight;
            isTeleporting = false;
            isMoving = false;

            if (isHeight)
                notificationManager.inputText = "Включён режим изменения высоты";
            else
                notificationManager.inputText = "Выключен режим изменения высоты";
        }

        if (!setting && !menu && !movement && Input.GetKeyDown(KeyCode.Alpha2)) //Редактирование
        {
            print("Вошёл в режим редактирования");

            edit = !edit;
            setting = false;
            menu = false;
            movement = false;

            if (edit)
                notificationManager.inputText = "Вошёл в режим редактирования";
            else
                notificationManager.inputText = "Вышел из режима редактирования";
        }

        if (edit && Input.GetKeyDown(KeyCode.Alpha1)) //Редактирование_захват объекта
        {
            print("Режим захвата объекта");
            // MenuImage.SetActive(false);
            CenterImage.SetActive(true);

            isChoiceObjects = !isChoiceObjects;
            isMovingObjects = false;
            isSlantObjects = false;

            if (isChoiceObjects)
                notificationManager.inputText = "Включён режим выбора объекта";
            else
                notificationManager.inputText = "Выключен режим выбора объекта";
        }

        if (edit && Input.GetKeyDown(KeyCode.Alpha3)) //Редактирование_пемещение объекта
        {
            print("Режим пемещения объекта");
            // MenuImage.SetActive(false); ;
            CenterImage.SetActive(true);

            isMovingObjects = !isMovingObjects;
            isChoiceObjects = false;
            isSlantObjects = false;

            if (isMovingObjects)
                notificationManager.inputText = "Включён режим пемещения объекта";
            else
                notificationManager.inputText = "Выключен режим пемещения объекта";
        }

        if (edit && Input.GetKeyDown(KeyCode.Alpha4)) //Редактирование_наклон объекта
        {
            print("Режим наклона объекта");
            // MenuImage.SetActive(false);
            CenterImage.SetActive(true);

            isSlantObjects = !isSlantObjects;
            isMovingObjects = false;
            isChoiceObjects = false;

            if (isSlantObjects)
                notificationManager.inputText = "Включён режим наклона объекта";
            else
                notificationManager.inputText = "Выключен режим наклона объекта";
        }

        if (!edit && !movement && !setting && Input.GetKeyDown(KeyCode.Alpha3)) //Меню предметов
        {
            print("Вошёл в меню предметов");
            menu = !menu;
            if (menu)
                CenterImage.SetActive(true);
            else
                CenterImage.SetActive(false);
        }
    }
}