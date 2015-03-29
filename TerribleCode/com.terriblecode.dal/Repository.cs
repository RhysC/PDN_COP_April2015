namespace com.terriblecode.dal
{
    public class Repository<T>
        where T : new()
    {
        public T GetById(int id)
        {
            return new T();
        }

        public void Update(T instance)
        { }
    }
}