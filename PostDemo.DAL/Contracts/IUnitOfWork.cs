namespace PostDemo.Contracts {
    public interface IUnitOfWork {
        IPackageRepository Packages { get; }

        IClientRepository Clients { get; }

        Task CompleteAsync();
    }
}
