namespace MotorolaExam.EntitiesDb.DAL.UnitOfWork
{
   public interface IUnitOfWork
   {
      Task<int> CompleteUnitOfWorkAsync();
   }
}