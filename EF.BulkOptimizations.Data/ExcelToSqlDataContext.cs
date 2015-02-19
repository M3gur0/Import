namespace EF.BulkOptimizations.Data
{
    using EF.BulkOptimizations.Business.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Linq.Expressions;

    public class ExcelToSqlDataContext : DbContext
    {
        #region < Properties >

        public DbSet<Status> StatusSet { get; set; }

        public DbSet<Variety> VarietySet { get; set; }

        private ObjectContext ObjectContext
        {
            get { return (this as IObjectContextAdapter).ObjectContext; }
        }

        /// <summary>
        /// Gets or Sets the command timeout.
        /// </summary>
        public int? CommandTimeout
        {
            get { return this.ObjectContext.CommandTimeout; }
            set { this.ObjectContext.CommandTimeout = value; }
        }

        #endregion < Properties >

        #region < Constructors >

        public ExcelToSqlDataContext()
            : base("ExcelToSql")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.AutoDetectChangesEnabled = true;
        }

        #endregion < Constructors >

        #region < Methods >

        /// <summary>
        /// Cancel changes in DataContext.
        /// </summary>
        public void Cancel()
        {
            foreach (DbEntityEntry entry in this.ChangeTracker.Entries().Where(entry => entry.State != EntityState.Unchanged))
            {
                entry.State = EntityState.Unchanged;
            }
        }

        /// <summary>
        /// Add an entity to DataContext.
        /// </summary>
        /// <param name="item">Entity to add.</param>
        public void Insert(IEntity item)
        {
            this.Set(item.GetType()).Add(item);
        }

        /// <summary>
        /// Remove an entity from DataContext.
        /// </summary>
        /// <param name="item">Entity to remove.</param>
        public void Delete(IEntity item)
        {
            this.Set(item.GetType()).Remove(item);
        }

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>
        /// The number of objects written to the underlying database.
        /// </returns>
        public int Save()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                       .SelectMany(x => x.ValidationErrors)
                       .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }

        }

        #endregion < Methods >
    }
}