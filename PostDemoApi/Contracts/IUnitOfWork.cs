namespace PostDemoApi.Contracts {
    public interface IUnitOfWork {
        IPackageRepository Packages { get; }

        Task CompleteAsync();
    }
}
