using UnityEngine;

public abstract class AAnimal : ScriptableObject
{
    public string Name;
}

public class Lion : AAnimal
{
    public int NumRoars;
}

public class Elephant : AAnimal
{
    public bool IsScaredOfMice;
}