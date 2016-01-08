using System;

namespace StudentManagement.DapperRepository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        ///     Gets the context.
        /// </summary>
        IContext Context { get; }

        /// <summary>
        ///     The save changes.
        /// </summary>
        /// <returns>
        ///     The <see cref="int" />.
        /// </returns>
        int SaveChanges();
    }

    public interface IContext
    {
    }
}