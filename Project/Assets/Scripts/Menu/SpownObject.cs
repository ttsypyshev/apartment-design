using System;
using UnityEngine;

public class SpownObject : MonoBehaviour
{
    public ChoiceObjects choiceObjects;
    
    public GameObject parentObject;
    public GameObject[] childObjects;

    private float spawnDistance = 3f;
    private int objectCount = 0;

    private void Start()
    {
        if (parentObject != null)
        {
            // Получаем все дочерние объекты рекурсивно
            Transform[] childTransforms = parentObject.GetComponentsInChildren<Transform>(true);

            // Создаем массив GameObject для хранения результатов
            childObjects = new GameObject[childTransforms.Length - 1];

            // Пропускаем первый элемент, так как это сам родительский объект
            for (int i = 1; i < childTransforms.Length; i++)
            {
                childObjects[i - 1] = childTransforms[i].gameObject;
            }

            // Делаем что-то с полученными объектами, например, выводим их количество
            Debug.Log("Количество дочерних объектов: " + childObjects.Length);
        }
    }

    public void Spawn(int numberObject)
    {
        // Получаем текущий взгляд камеры
        Vector3 gazeDirection = Camera.main.transform.forward;

        // Рассчитываем позицию для спауна меню перед камерой
        Vector3 spawnPosition = Camera.main.transform.position + gazeDirection * spawnDistance;

        // Спавним объект перед камерой с уникальным названием
        GameObject newObject = Instantiate(childObjects[numberObject], spawnPosition, Quaternion.identity);
        newObject.name = childObjects[numberObject].name + "_" + numberObject.ToString() + "_" + objectCount.ToString();
        newObject.tag = "draggable";
        choiceObjects.body = newObject;
        objectCount++;
    }
}