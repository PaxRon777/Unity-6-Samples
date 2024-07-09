using UnityEngine;

//Passing generic types to fields, classes and funtions

public class Generics : MonoBehaviour
{
    void Start()
    {
        MyGenericClass<int, string> myIntInstance = new MyGenericClass<int, string>();
        myIntInstance.value = 100;
        myIntInstance.value2 = " Cats";
        print(myIntInstance.value + myIntInstance.value2);

        MyGenericClass<bool, int> myBoolInstance = new MyGenericClass<bool, int>();
        myBoolInstance.value = true;
        myBoolInstance.value2 = 7;
        print(myBoolInstance.value2 + " is the perfect number? = " + myBoolInstance.value);

        AnyTypeFunction("A String");
        AnyTypeFunction(100);
        AnyTypeFunction(true);
    }

    private void AnyTypeFunction<T>(T value)
    {
        print(value);
    }
}

public class MyGenericClass<T, M>
{
    public T value;
    public M value2;
}
