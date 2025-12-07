using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSorting : MonoBehaviour
{
    [SerializeField] protected AnimalManager animalManager;
    public AnimalManager AnimalManagers => animalManager;

    void Start()
    {
        //Kiểm tra việc gán script AnimalManager vào script hiện tại trước khi chạy
        if (animalManager == null)
        {
            this.animalManager = GetComponent<AnimalManager>();
        }

        //Sắp xếp lại và in ra thông tin các animal
        Invoke("sortAnimalByWeight", 10f);
    }

    private void Reset()
    {
        this.animalManager = GetComponent<AnimalManager>();
    }
    protected void sortAnimalByWeight ()
    {
        Debug.Log("====================================================================================");
        Debug.Log("=======SortingAnimal========");
        this.animalManager.Animals.Sort((a,b) => a.GetWeight().CompareTo(b.GetWeight()));

        foreach(Animal animal in this.animalManager.Animals)
        {
            string animalInfor = animal.GetInFor();
            Debug.Log(animal.name);
            Debug.Log(animalInfor);
        }
    }
}
