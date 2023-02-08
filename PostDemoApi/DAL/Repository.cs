using PostDemoApi.Contracts;

namespace PostDemoApi.DAL {
    public class Repository : IRepository
    {
        private readonly DatabaseContext _dbContext;

        public int CreateItem(object item)
        {

            try
            {
                //_dbContext.BeginTransaction();
                //_dbContext.Create(item)
                //_dbContext.EndTransaction();
            }
            catch
            {
                //_dbContext.RollbackTransaction();
            }

            throw new NotImplementedException();


        }

        public object[] GetAll()
        {
            return new object[10];
        }
    }
}
