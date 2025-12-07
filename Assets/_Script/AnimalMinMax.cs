using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMinMax : MonoBehaviour
{
    [SerializeField] protected AnimalSorting animalSorting;
    [SerializeField] protected Animal animalMin;
    [SerializeField] protected Animal animalMax;
    void Start()
    {
        //Kiểm tra việc gán script AnimalManager vào script hiện tại trước khi chạy
        if (animalSorting == null)
        {
            this.animalSorting = GetComponent<AnimalSorting>();
        }

        //In ra thông tin min và max weight animal
        Invoke("GetMinWeightAnimal", 15f);
        Invoke("GetMaxWeightAnimal", 20f);
    }

    private void Reset()
    {
        this.animalSorting = GetComponent<AnimalSorting>();
    }

    protected void GetMinWeightAnimal()
    {
        Debug.Log("====================================================================================");
        this.animalMin = this.animalSorting.AnimalManagers.Animals[0];
    }

    protected void GetMaxWeightAnimal()
    {
        Debug.Log("====================================================================================");
        this.animalMax = this.animalSorting.AnimalManagers.Animals[this.animalSorting.AnimalManagers.Animals.Count-1];
    }
}
