using UnityEngine;
[System.Serializable]
public class Car
{
    public float speed;
    //protected string color;
    [SerializeField]private string brand;
    public string color;

    public float carSpeed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value; 
        }
    }

    //public string brandName {get; private set;}
    public string Brand {get; set; } = "Bentley";//getter/setter
    public string colorName
    {
        get
        {
            return color;
        }
        set
        {
            this.color = value;
        }
    }
    
    public Car(){Debug.Log("Is this even working?");}
    public Car(float speed = 50f, string brand = "BMW", string color = "blue")
    {
        this.speed = speed;
        this.Brand = brand;
        this.color = color;
        Debug.Log("main constructor");
    }

    public Car(float speed) : this(speed, "BMW", "blue"){}
    public Car(float speed, string brand) : this(speed, brand, "blue"){Debug.Log("2 parameters constructor");}//constructor chaining

    public void printDaGoods()
    {
        Debug.LogFormat("Car's speed: {0}\nCar's brand: {1}\nCar's color: {2}",
                             speed, Brand, color);
    }
}
