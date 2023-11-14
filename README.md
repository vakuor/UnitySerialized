# UnitySerialized
A way to use a [SerializeField] attribute on interfaces in Unity

This repository contains sample code from my answer on the Unity forum:  
https://forum.unity.com/threads/serialized-interface-fields.1238785/#post-9469838

A copy of the answer is below.

Hey guys,

Since Unity is in no hurry to please us with useful updates.
I can only suggest you to use the following lifehack method for [SerializeField] links to interfaces.

You need to put this class to your scripts folder.
```csharp
[DefaultExecutionOrder(-1000)]
public abstract class ComponentPicker<T> : MonoBehaviour
{
    public T Value { get; private set; }
 
    protected virtual void Awake()
    {
        Value = GetComponent<T>();
    }
}
```

For each interface type you want to serialize you will need to create a separate MonoBehaviour class.

For example you have:

```csharp
public interface IGroundDetector
{
    public bool IsGrounded { get; }
}

public class DistanceGroundDetector : MonoBehaviour, IGroundDetector
{
    [field: SerializeField]
    public bool IsGrounded { get; private set; }

    [field: SerializeField]
    private float _detectionDistance = 0.01f;
 
    private void FixedUpdate()
    {
        IsGrounded = Physics.Raycast(transform.position, Vector3.down, _detectionDistance);
    }
}
```

If you want to reference your IGroundDetector you can simply create a ComponentPicker for that and attach this component to GroundDetector GameObject.

Like that:

```csharp
public class GroundDetectorPicker : ComponentPicker<IGroundDetector>
{}
```

Now you can put a reference to picker component and take a value from that!

Usage example:

```csharp
public class Test : MonoBehaviour
{
    [SerializeField]
    private GroundDetectorPicker _groundDetectorPicker;

    private void Update()
    {
        Debug.Log(_groundDetectorPicker.Value.IsGrounded);
    }
}
```

![image](https://github.com/vakuor/UnitySerialized/assets/19931959/45d8a332-204a-4522-b0d9-ba6db3890eac)
![image](https://github.com/vakuor/UnitySerialized/assets/19931959/207988fe-df07-446a-847a-4b24edb58ec5)
![image](https://github.com/vakuor/UnitySerialized/assets/19931959/d588636e-b9b7-437e-87a5-9cd335904a63)
