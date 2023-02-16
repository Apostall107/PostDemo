namespace PostDemoApi.Contracts {
    public interface IUnitOfWork {
        IPackageRepository Packages { get; }

        IClientRepository Clients { get; }

        Task CompleteAsync();
    }
}
