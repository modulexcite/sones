﻿using System;

namespace sones.GraphDB.TypeSystem
{
    /// <summary>
    /// An interface that represents a property definition on a vertex type definition.
    /// </summary>
    public interface IPropertyDefinition : IAttributeDefinition
    {
        /// <summary>
        /// Gets whether this property is mandatory.
        /// </summary>
        Boolean IsMandatory { get; }

        /// <summary>
        /// Gets the type of the property. This is always a c# value type or a user defined.
        /// </summary>
        Type BaseType { get; }
    }
}