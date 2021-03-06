﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OEP.Core.Data;
using OEP.Core.Data.Repository;
using OEP.Core.DomainModels;
using OEP.Core.Services;

namespace OEP.Services
{
    public class BaseService<TEntity> : IService<TEntity> where TEntity : BaseEntity
    {
        public IUnitOfWork UnitOfWork { get; private set; }

        IUnitOfWork IService.UnitOfWork
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        private readonly IRepository<TEntity> _repository;
        private bool _disposed;

        public BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            
            _repository = UnitOfWork.Repository<TEntity>();
        }

        public List<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public PaginatedList<TEntity> GetAll(int pageIndex, int pageSize)
        {
            return _repository.GetAll(pageIndex, pageSize);
        }

        public PaginatedList<TEntity> GetAll(int pageIndex, int pageSize, Expression<Func<TEntity, object>> keySelector, OrderBy orderBy = OrderBy.Ascending)
        {
            return _repository.GetAll(pageIndex, pageSize, keySelector, orderBy);
        }

        public PaginatedList<TEntity> GetAll(int pageIndex, int pageSize, Expression<Func<TEntity, object>> keySelector, Expression<Func<TEntity, bool>> predicate, OrderBy orderBy, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _repository.GetAll(pageIndex, pageSize, keySelector, predicate, orderBy, includeProperties);
        }

        public TEntity GetById(int id)
        {
            return _repository.GetSingle(id);
        }

        public void Add(TEntity entity)
        {
            _repository.Insert(entity);           
        }


        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }

        public void UnitOfWorkSaveChanges()
        {
            UnitOfWork.SaveChanges();
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<PaginatedList<TEntity>> GetAllAsync(int pageIndex, int pageSize)
        {
            return _repository.GetAllAsync(pageIndex, pageSize);
        }

        public Task<PaginatedList<TEntity>> GetAllAsync(int pageIndex, int pageSize, Expression<Func<TEntity, object>> keySelector, OrderBy orderBy = OrderBy.Ascending)
        {
            return _repository.GetAllAsync(pageIndex, pageSize, keySelector, orderBy);
        }

        public Task<PaginatedList<TEntity>> GetAllAsync(int pageIndex, int pageSize, Expression<Func<TEntity, object>> keySelector, Expression<Func<TEntity, bool>> predicate, OrderBy orderBy, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _repository.GetAllAsync(pageIndex, pageSize, keySelector, predicate, orderBy, includeProperties);
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            return _repository.GetSingleAsync(id);
        }

        public Task AddAsync(TEntity entity)
        {
            _repository.Insert(entity);
            return UnitOfWork.SaveChangesAsync();
        }

        public Task UpdateAsync(TEntity entity)
        {
            _repository.Update(entity);
            return UnitOfWork.SaveChangesAsync();
        }

        public Task DeleteAsync(TEntity entity)
        {
            _repository.Delete(entity);
            return UnitOfWork.SaveChangesAsync();
        }

        public Task<List<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.FindByAsync(predicate);
        }

        public List<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.FindBy(predicate);
        }

        public Task<TEntity> GetSingleIncludingAsync(int id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _repository.GetSingleIncludingAsync(id, includeProperties);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                UnitOfWork.Dispose();
            }
            _disposed = true;
        }

        List<TEntity> IService<TEntity>.GetAll()
        {
            return _repository.GetAll();
        }

        PaginatedList<TEntity> IService<TEntity>.GetAll(int pageIndex, int pageSize)
        {
            return _repository.GetAll(pageIndex,pageSize);
        }

        PaginatedList<TEntity> IService<TEntity>.GetAll(int pageIndex, int pageSize, Expression<Func<TEntity, object>> keySelector, OrderBy orderBy)
        {
            return _repository.GetAll(pageIndex,pageSize,keySelector,orderBy);
        }

        PaginatedList<TEntity> IService<TEntity>.GetAll(int pageIndex, int pageSize, Expression<Func<TEntity, object>> keySelector, Expression<Func<TEntity, bool>> predicate, OrderBy orderBy, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _repository.GetAll(pageIndex, pageSize, keySelector, predicate, orderBy,includeProperties);
        }

       
    }
}
