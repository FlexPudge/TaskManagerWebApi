namespace TaskManagerWebApi.Interface
{
     interface IRepository <T> : IDisposable
    {
        List<T> GetList(); // получение всех объектов
        T GetByID(int id); // получение одного объекта по id
        void Create(T item); // создание объекта
        void Update(T item); // обновление объекта
        void Delete(int id); // удаление объекта по id
        void Save();
    }
}
