using Business.DataModel.RepoFile;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace Business.DataModel
{
    public interface IUnitOfWork : IDisposable
    {
        IUser User { get; }
        IContact Contact { get; }
        IContactRole ContactRole { get; }
        IProduct Product { get; }
        IProductCategory ProductCategory { get; }


        int SaveChanges();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }

    public class UnitOfWork : IUnitOfWork
    {
        #region Private member variables...

        private BusinessDBEntities _context = null;
        private DbContextTransaction _transaction;

        IUser _userRepository;
        IContact _contactRepository;
        IContactRole _contactRole;
        IProduct _product;
        IProductCategory _productCategory;

        #endregion

        public UnitOfWork()
        {
            _context = new BusinessDBEntities();
        }

        #region Public Repository Creation properties...

        public IUser User
        {
            get
            {
                return _userRepository ?? (_userRepository = new RepoUser(_context));
            }
        }

        public IContact Contact
        {
            get
            {
                return _contactRepository ?? (_contactRepository = new RepoContact(_context));
            }
        }

        public IContactRole ContactRole
        {
            get
            {
                return _contactRole ?? (_contactRole = new RepoContactRole(_context));
            }
        }

        public IProduct Product
        {
            get
            {
                return _product ?? (_product = new RepoProduct(_context));
            }
        }

        public IProductCategory ProductCategory
        {
            get
            {
                return _productCategory ?? (_productCategory = new RepoProductCategory(_context));
            }
        }

        #endregion

        #region Public member methods...

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now,
                        eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);

                throw e;
            }

        }

        #endregion

        #region Implementing IDiosposable...

        #region private dispose variable declaration...
        private bool disposed = false;
        #endregion

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _transaction.Commit();
        }

        public void RollbackTransaction()
        {
            _transaction.Rollback();
        }
        #endregion
    }
}