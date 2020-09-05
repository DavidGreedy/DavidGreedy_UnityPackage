using UnityEngine;

public abstract class SingletonComponent<T> : SingletonComponent where T : MonoBehaviour
{
    public static T Instance { get; private set; } = default;

    public override void Setup()
    {
        if (Instance != this)
        {
            Instance = this as T;
        }
    }

    public override void Clear()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}

public abstract class SingletonComponent : MonoBehaviour
{
    public abstract void Setup();
    public abstract void Clear();

    protected virtual void Awake()
    {
        Setup();
    }

    protected virtual void OnDestroy()
    {
        Clear();
    }
}