using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    [SerializeField] protected List<Animal> animals = new ();
    [SerializeField] protected List<Transform> DefaultAnimals = new ();
    [SerializeField] protected List<Animal> animalsSortByWeight = new ();
    void Start()
    {
        long startTime = UnixTime.GetUnixTimeMicro();
        Debug.Log("======== startTime: " + startTime);

        this.CreatedRandomAnimal();
        this.GetAnimal();
        this.AnimalToDoSomething();
        this.SortAnimalByWeight();

        long nowTime = UnixTime.GetUnixTimeMicro();
        Debug.Log("======== nowTime: " + nowTime);

        float timeDiff = UnixTime.GetTimeDiffToNow(startTime);
        Debug.Log("======== timeDiff: " + timeDiff);
    }

    //## Lấy animal và sắp xếp, Log ra
    public void GetAnimal()
    {
        foreach (Transform child in transform)
        {
            Animal animal = child.GetComponent<Animal>();
            animals.Add(animal);
        }
    }
    
    public void AnimalToDoSomething()
    {
        foreach(Animal animal in animals)
        {
            string infor = animal.GetInFor();
            Debug.Log(animal.name);
            Debug.Log(infor);
        }
    }

    public void SortAnimalByWeight()
    {
        Debug.Log("====SortAnimalByWeight====");
        this.animalsSortByWeight = new(this.animals);
        for(int x=0; x<this.animalsSortByWeight.Count-1;x++)
        {
            for(int y=x+1;y<this.animalsSortByWeight.Count;y++)
            {
                if(this.animalsSortByWeight[x].GetWeight() > this.animalsSortByWeight[y].GetWeight())
                {
                    Animal temp = this.animalsSortByWeight[y];
                    this.animalsSortByWeight[y] = this.animalsSortByWeight[x];
                    this.animalsSortByWeight[x] = temp;
                }
            }
        }
        foreach(Animal animal in animalsSortByWeight)
        {
            string infor = animal.GetInFor();
            Debug.Log(animal.name);
            Debug.Log(infor);
        }
    }


    //##RanDom vô số animal
    public void CreatedRandomAnimal()
    {
        //Tạo danh sách Transform Default Animals
        this.AddDefaultAnimals();
        int GenerateCount = 20000;
        for(int i=0;i<GenerateCount;i++)
        {
            //Tạo random animals
            int randomIdex = Random.Range(0, this.DefaultAnimals.Count);
            Transform RandomChild = this.DefaultAnimals[randomIdex];
            //Dùng GameObject để khởi tạo animal có thông số của random animals
            Transform NewRandomChild = GameObject.Instantiate(RandomChild);
            NewRandomChild.parent = transform;
        }
    }

    public void AddDefaultAnimals()
    {
        foreach(Transform child in transform)
        {
            this.DefaultAnimals.Add(child);
        }
    }
}
