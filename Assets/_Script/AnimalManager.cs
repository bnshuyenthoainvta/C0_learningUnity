using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEditor.Rendering;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    [SerializeField] protected List<Transform> defaultAnimals = new ();
    [SerializeField] protected List<Animal> animals = new ();

    public List<Animal> Animals => animals;

    void Start()
    {
        long startTime = UnixTime.GetUnixTimeMicro();
        Debug.Log("======== startTime: " + startTime);

        this.CreatedRandomAnimal();
        this.GetAnimal();
        this.ShowAnimalInfor();

        long nowTime = UnixTime.GetUnixTimeMicro();
        Debug.Log("======== nowTime: " + nowTime);

        float timeDiff = UnixTime.GetTimeDiffToNow(startTime);
        Debug.Log("======== timeDiff: " + timeDiff);
    }

    //Lấy danh sách animals tổng hợp
    protected void GetAnimal()
    {
        animals.Clear();
        foreach(Transform child in transform)
        {
            Animal animal = child.GetComponent<Animal>();
            this.animals.Add(animal);
        }
    }
    
    //In ra thông tin animal
    public void ShowAnimalInfor()
    {
        foreach(Animal animal in animals)
        {
            string animalInfor = animal.GetInFor();
            Debug.Log(animal.name);
            Debug.Log(animalInfor);
        }
    }

    //Tạo random vô số animal
    public void CreatedRandomAnimal()
    {
        //Lấy danh sách animal mặc định
        defaultAnimals.Clear();
        foreach(Transform child in transform)
        {
            this.defaultAnimals.Add(child);
        }
    
        //Số lượng animal random cần tạo ra
        int GenerateCount = 20000;
        for(int i=0;i<GenerateCount;i++)
        {
            //Tạo random animals
            int randomIdex = Random.Range(0, this.defaultAnimals.Count);
            Transform RandomChild = this.defaultAnimals[randomIdex];
            //Dùng GameObject để khởi tạo animal có thông số của random animals và gán vào thành con của transform hiện tại
            Transform NewRandomChild = GameObject.Instantiate(RandomChild, transform);
            Animal animal = NewRandomChild.GetComponent<Animal>();
            animal.GetRandomWeight();
        }
    }
}
