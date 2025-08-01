﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seguradora.Domain.Repository;

namespace Seguradora.Infrastructure;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly DbContext _context;
    protected readonly DbSet<T> _dbSet;

    public Repository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T> ObterPorId(Guid id) => await _dbSet.FindAsync(id);

    public async Task<IEnumerable<T>> ListarAsync() => await _dbSet.ToListAsync();

    public async Task CriarAsync(T entity) => await _dbSet.AddAsync(entity);

    public void Atualizar(T entity) => _dbSet.Update(entity);

    public void Apagar(T entity) => _dbSet.Remove(entity);
}
