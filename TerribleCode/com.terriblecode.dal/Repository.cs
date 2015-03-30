using System.Collections.Generic;

namespace com.terriblecode.dal
{
    public class Repository<T>
        where T : class, IEntity, new()
    {
        public T GetById(int id)
        {
            using (var session = SessionFactoryFactory.Instance.OpenSession())
            {
                return session.Get<T>(id);
            }
        }

        public int Save(T instance)
        {
            using (var session = SessionFactoryFactory.Instance.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Save(instance);

                transaction.Commit();

                return instance.Id;
            }
        }

        public void Update(T instance)
        {
            using (var session = SessionFactoryFactory.Instance.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Update(instance);

                transaction.Commit();
            }
        }

        public IEnumerable<T> List()
        {
            using (var session = SessionFactoryFactory.Instance.OpenSession())
            {
                return session.QueryOver<T>().List<T>();
            }
        }
    }
}