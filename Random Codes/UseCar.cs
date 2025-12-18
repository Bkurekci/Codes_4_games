using UnityEngine;

public class UseCar : MonoBehaviour
{
    public Car car;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        car.printDaGoods();
    //    Car myCar = new Car(100f, "Porsche");
    //    Debug.LogFormat("Ur new car's speed is {0} \n Brand is {1}\nAnd Color is {2}", myCar.carSpeed, myCar.brandName, myCar.colorName);
    //    myCar.carSpeed = 250f;
    //    Debug.Log($"Now it's speed has changed {myCar.carSpeed}");
    //    Debug.Log("Is this working? " + myCar);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
