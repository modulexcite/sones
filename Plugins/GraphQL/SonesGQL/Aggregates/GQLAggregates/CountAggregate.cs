﻿using System;
using System.Collections.Generic;
using System.Linq;
using ISonesGQLFunction.Structure;
using sones.GraphDB.TypeSystem;
using sones.Library.VersionedPluginManager;

namespace sones.Plugins.SonesGQL.Aggregates
{
    /// <summary>
    /// The Aggregate Count
    /// </summary>
    public sealed class CountAggregate :IGQLAggregate
    {
        #region constructor

        /// <summary>
        /// Creates a new count aggregate
        /// </summary>
        public CountAggregate()
        {
 
        }

        #endregion

        #region IGQLAggregate Members

        /// <summary>
        /// Calculates the count
        /// </summary>
        public FuncParameter Aggregate(IEnumerable<IComparable> myValues, IPropertyDefinition myPropertyDefinition)
        {
            return new FuncParameter(myValues.Count(), myPropertyDefinition);
        }

        #endregion

        #region IPluginable Members

        public string PluginName
        {
            get { return "COUNT"; }
        }

        public Dictionary<string, Type> SetableParameters
        {
            get { return new Dictionary<string,Type>(); }
        }

        public IPluginable InitializePlugin(Dictionary<string, object> myParameters = null)
        {
            return new CountAggregate();
        }

        #endregion
    }
}