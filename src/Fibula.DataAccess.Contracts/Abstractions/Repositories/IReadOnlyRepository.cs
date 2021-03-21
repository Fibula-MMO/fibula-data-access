﻿// -----------------------------------------------------------------
// <copyright file="IReadOnlyRepository.cs" company="2Dudes">
// Copyright (c) | Jose L. Nunez de Caceres et al.
// https://linkedin.com/in/nunezdecaceres
//
// All Rights Reserved.
//
// Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>
// -----------------------------------------------------------------

namespace Fibula.Data.Contracts.Abstractions.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Fibula.Definitions.Data.Entities;

    /// <summary>
    /// Interface for a generic, read-only entity repository.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    public interface IReadOnlyRepository<TEntity>
        where TEntity : BaseEntity
    {
        /// <summary>
        /// Gets all the entities from the set in the context.
        /// </summary>
        /// <param name="includeProperties">Optional. Any additional properties to include.</param>
        /// <returns>The collection of entities retrieved.</returns>
        Task<IEnumerable<TEntity>> GetAll(params string[] includeProperties);

        /// <summary>
        /// Finds all entities that match a predicate.
        /// </summary>
        /// <param name="predicate">The predicate to use for matching.</param>
        /// <param name="includeProperties">Optional. Any additional properties to include.</param>
        /// <returns>The entities that matched the predicate.</returns>
        IEnumerable<TEntity> FindMany(Expression<Func<TEntity, bool>> predicate, params string[] includeProperties);

        /// <summary>
        /// Finds an entity in the set within the context that satisfies an expression.
        /// If more than one entity satisfies the expression, one is picked up in an unknown criteria.
        /// </summary>
        /// <param name="predicate">The expression to satisfy.</param>
        /// <param name="includeProperties">Optional. Any additional properties to include.</param>
        /// <returns>The entity found.</returns>
        TEntity FindOne(Expression<Func<TEntity, bool>> predicate, params string[] includeProperties);
    }
}
