namespace DSA_In_CSharp._01.ARRAYS._00._Static_Array;

public class StaticArray<T>
{
    private int _size;
    private int _length;
    private T[] _arr;

    public StaticArray(int size)
    {
        if (size <= 0)
        {
            throw new ArgumentException("Size should be greater than 0");
        }

        _size = size;
        _length = 0;
        _arr = new T[_size];
    }

    public int Length => _length;

    public int Size => _size;

    private bool IsEmpty() => _length == 0;

    private bool IsSizeSpaceAvailable() => _length < _size;

    //Static Array Operations took Big O(1) time complexity

    #region Static Array Operations

    public T GetValue(int index)
    {
        if (index < 0 || index >= _size)
        {
            throw new IndexOutOfRangeException();
        }

        return _arr[index];
    }

    public T SetValue(int index, T value)
    {
        if (index < 0 || index >= _size)
        {
            throw new IndexOutOfRangeException();
        }

        _arr[index] = value;
        return value;
    }

    /// <summary>
    /// Add value to the end of the array
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <exception cref="IndexOutOfRangeException"></exception>
    public T Add(T value)
    {
        if (IsSizeSpaceAvailable() is false) throw new IndexOutOfRangeException("Array is full");
        _arr[_length] = value;
        _length++;
        return value;
    }

    /// <summary>
    /// Delete value from the end of the array
    /// </summary>
    /// <returns></returns>
    /// <exception cref="IndexOutOfRangeException"></exception>
    public T Delete()
    {
        if (IsEmpty() is true) throw new IndexOutOfRangeException("Array is empty");
        T value = _arr[_length - 1];
        _arr[_length - 1] = default(T);
        _length--;
        return value;
    }

    #endregion

    //Dynamic Array Operations took Big O(n) time complexity

    #region Dynamic Array Operations

    /// <summary>
    /// InsertAt value at the given index and shift the rest of the elements to the right
    /// </summary>
    /// <param name="index"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <exception cref="IndexOutOfRangeException"></exception>
    public T InsertAt(int index, T value)
    {
        if (index < 0 || index >= _size)
        {
            throw new IndexOutOfRangeException();
        }

        for (int i = _size - 1; i > index; i--)
        {
            _arr[i] = _arr[i - 1];
        }

        _arr[index] = value;
        _length++;
        return value;
    }

    /// <summary>
    /// DeleteAt value from the given index and shift the rest of the elements to the left
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    /// <exception cref="IndexOutOfRangeException"></exception>
    public T DeleteAt(int index)
    {
        if (index < 0 || index >= _size || IsEmpty())
        {
            throw new IndexOutOfRangeException();
        }

        T value = _arr[index];


        int j = index + 1;
        for (int i = index; j < _length; i++)
        {
            _arr[i] = _arr[j];
        }

        _arr[_length - 1] = default(T);

        return value;
    }

    #endregion
}