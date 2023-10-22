using UnityEngine;

public class GeneralManager : MonoBehaviour
{
    public GameObject MenuImage;
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
        MenuImage.SetActive(false);
        CenterImage.SetActive(false);
    }

    private void Update()
    {
        if (!setting && !menu && !movement && !edit)
        {
            MenuImage.SetActive(false);
            CenterImage.SetActive(false);
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
        }

        if (movement && Input.GetKeyDown(KeyCode.I)) //Передвижение_телепортирование
        {
            print("Режим телепортирования");
            MenuImage.SetActive(false);
            CenterImage.SetActive(false);
            isTeleporting = !isTeleporting;
            isMoving = false;
            isHeight = false;
        }

        if (movement && Input.GetKeyDown(KeyCode.O)) //Передвижение_ходьба
        {
            print("Режим ходьбы");
            CenterImage.SetActive(true);
            MenuImage.SetActive(false);
            isMoving = !isMoving;
            isTeleporting = false;
            isHeight = false;
        }

        if (movement && Input.GetKeyDown(KeyCode.P)) //Передвижение_изменение высоты
        {
            print("Режим изменения высоты");
            CenterImage.SetActive(true);
            MenuImage.SetActive(false);
            isHeight = !isHeight;
            isTeleporting = false;
            isMoving = false;
        }

        if (!setting && !menu && !movement && Input.GetKeyDown(KeyCode.Alpha2)) //Редактирование
        {
            print("Вошёл в режим редактирования"); 
            edit = !edit;
            setting = false;
            menu = false;
            movement = false;

        }

        if (edit && Input.GetKeyDown(KeyCode.I)) //Редактирование_захват объекта
        {
            print("Режим захвата объекта");
            CenterImage.SetActive(true);
            MenuImage.SetActive(false);
            isChoiceObjects = !isChoiceObjects;
            isMovingObjects = false;
            isSlantObjects = false;
        }

        if ( edit && Input.GetKeyDown(KeyCode.O)) //Редактирование_пемещение объекта
        {
            print("Режим пемещения объекта");
            MenuImage.SetActive(false); ;
            CenterImage.SetActive(false);
            isMovingObjects = !isMovingObjects;
            isChoiceObjects = false;
            isSlantObjects = false;
        }

        if (edit && Input.GetKeyDown(KeyCode.P)) //Редактирование_наклон объекта
        {
            print("Режим наклона объекта");
            MenuImage.SetActive(false);
            CenterImage.SetActive(false);
            isSlantObjects = !isSlantObjects;
            isMovingObjects = false;
            isChoiceObjects = false;
        }

        if (!edit && !movement && !setting && Input.GetKeyDown(KeyCode.Alpha3)) //Меню предметов
        {
            print("Вошёл в меню предметов");
            MenuImage.SetActive(true);
            CenterImage.SetActive(true);
            menu = !menu;

        }

        if (!edit && !menu && !movement && Input.GetKeyDown(KeyCode.Alpha4)) //Настройки
        {
            print("Вошёл в режим настроек");
            setting = !setting;
        }
    }
}      