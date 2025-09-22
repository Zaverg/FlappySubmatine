using System;

public interface IReleasable
{
    public event Action<IReleasable> Released;
}