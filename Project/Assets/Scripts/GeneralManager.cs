using UnityEngine;
using UnityEngine.UI;

public class GeneralManager : MonoBehaviour
{
    public GameObject MenuImage;
    public GameObject CenterImage;
    public GameObject notificftion;
    public Text notificftionText;
    public int button = 0;

    public float time = 0;
    public string[] text = new string[22] { "Вошёл в режим передвижения", "Вышел из режима передвижения", "Включён режим телепортирования", "Выключен режим телепортирования", "Включён режим ходьбы", "Выключен режим ходьбы", "Включён режим изменения высоты", "Выключен режим изменения высоты",
        "Вошёл в режим редактирования", "Вышел из режима редактирования", "Включён режим выбора объекта", "Выключен режим выбора объекта", "Включён режим пемещения объекта", "Выключен режим пемещения объекта", "Включён режим наклона объекта", "Выключен режим наклона объекта",
        "Вошёл в меню предметов","Вышел из меню предметов", "Вошёл в настройки","Вышел из настроек", "Объект выбран","Объект удалён"};

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
        MenuImage.SetActive(false);
        CenterImage.SetActive(false);
        notificftion.SetActive(false);
    }

    private void Update()
    {
        if (!edit && !menu && !setting && !movement)
        {
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
            isMoving = false;
            isTeleporting = false;
            isHeight = false;
            time = 3;
            if(movement)
                notificftionText.text = text[0];
            else
                notificftionText.text = text[1];
        }

        if (movement && Input.GetKeyDown(KeyCode.Alpha2)) //Передвижение_телепортирование
        {
            print("Режим телепортирования");
            MenuImage.SetActive(false);
            CenterImage.SetActive(false);
            isTeleporting = !isTeleporting;
            isMoving = false;
            isHeight = false;
            time = 3;
            if (isTeleporting)
                notificftionText.text = text[2];
            else
                notificftionText.text = text[3];
        }

        if (movement && Input.GetKeyDown(KeyCode.Alpha3)) //Передвижение_ходьба
        {
            print("Режим ходьбы");
            CenterImage.SetActive(true);
            MenuImage.SetActive(false);
            isMoving = !isMoving;
            isTeleporting = false;
            isHeight = false;
            time = 3;
            if (isMoving)
                notificftionText.text = text[4];
            else
                notificftionText.text = text[5];
        }

        if (movement && Input.GetKeyDown(KeyCode.Alpha4)) //Передвижение_изменение высоты
        {
            print("Режим изменения высоты");
            CenterImage.SetActive(true);
            MenuImage.SetActive(false);
            isHeight = !isHeight;
            isTeleporting = false;
            isMoving = false;
            time = 3;
            if (isHeight)
                notificftionText.text = text[6];
            else
                notificftionText.text = text[7];
        }

        if (!setting && !menu && !movement && Input.GetKeyDown(KeyCode.Alpha2)) //Редактирование
        {
            print("Вошёл в режим редактирования"); 
            edit = !edit;
            setting = false;
            menu = false;
            movement = false;
            time = 3;
            if (edit)
                notificftionText.text = text[8];
            else
                notificftionText.text = text[9];
        }

        if (edit && Input.GetKeyDown(KeyCode.Alpha1)) //Редактирование_захват объекта
        {
            print("Режим захвата объекта");
            CenterImage.SetActive(true);
            MenuImage.SetActive(false);
            isChoiceObjects = !isChoiceObjects;
            isMovingObjects = false;
            isSlantObjects = false;
            time = 3;
            if (isChoiceObjects)
                notificftionText.text = text[10];
            else
                notificftionText.text = text[11];
        }

        if ( edit && Input.GetKeyDown(KeyCode.Alpha3)) //Редактирование_пемещение объекта
        {
            print("Режим пемещения объекта");
            MenuImage.SetActive(false); ;
            CenterImage.SetActive(false);
            isMovingObjects = !isMovingObjects;
            isChoiceObjects = false;
            isSlantObjects = false;
            time = 3;
            if (isMovingObjects)
                notificftionText.text = text[12];
            else
                notificftionText.text = text[13];
        }

        if (edit && Input.GetKeyDown(KeyCode.Alpha4)) //Редактирование_наклон объекта
        {
            print("Режим наклона объекта");
            MenuImage.SetActive(false);
            CenterImage.SetActive(false);
            isSlantObjects = !isSlantObjects;
            isMovingObjects = false;
            isChoiceObjects = false;
            time = 3;
            if (isSlantObjects)
                notificftionText.text = text[14];
            else
                notificftionText.text = text[15];
        }

        if (!edit && !movement && !setting && Input.GetKeyDown(KeyCode.Alpha3)) //Меню предметов
        {
            print("Вошёл в меню предметов");
            menu = !menu;
            if(menu)
            {
                time = 0;
                MenuImage.SetActive(true);
                CenterImage.SetActive(true);
            }
            else
            {
                MenuImage.SetActive(false);
                CenterImage.SetActive(false);
            }
        }

        if (time > 0)
        {
            notificftion.SetActive(true);
            time -= Time.deltaTime;
        }
        else
            notificftion.SetActive(false);
    }
}      