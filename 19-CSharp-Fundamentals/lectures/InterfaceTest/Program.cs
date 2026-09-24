interface IRepo
{
    void Add();
    void Get();
}

// You should see a warning because we are missing the Get() - Method.
// class BookRepo : IRepo
// {
//     public void Add()
//     {
//         throw new NotImplementedException();
//     }

// }