﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using sones.GraphQL.Result;


namespace sones.Plugins.GraphDS.IOInterface.XML_IO.Result
{
    /// <summary>
    /// This class creates an vertex view.
    /// </summary>
    public class VertexView : IVertexView
    {
        #region Data

        /// <summary>
        /// The list with the result properties.
        /// </summary>
        private readonly IDictionary<String, Object>     _propertyList;

        /// <summary>
        /// The list with result edges.
        /// </summary>
        private readonly IDictionary<String, IEdgeView>  _edgeList;
        
        #endregion
        
        #region Constructor

        /// <summary>
        /// The vertex view constructor.
        /// </summary>
        /// <param name="myPropertyList">The property list.</param>
        /// <param name="myEdges">The edge list.</param>
        public VertexView(IDictionary<String, Object> myPropertyList, IDictionary<String, IEdgeView> myEdges)
        {
            _propertyList       = myPropertyList;
            _edgeList           = myEdges;
        }

        #endregion

        #region IVertexView
        
        public bool HasEdge(string myEdgePropertyName)
        {
            return _edgeList.ContainsKey(myEdgePropertyName);
        }

        public IEnumerable<Tuple<string, IEdgeView>> GetAllEdges()
        {
            return _edgeList.Select(item => new Tuple<String, IEdgeView>(item.Key, item.Value));
        }

        public IEnumerable<Tuple<string, IHyperEdgeView>> GetAllHyperEdges()
        {
            return _edgeList.Where(item => item.Value is IHyperEdgeView).Select(item => new Tuple<String, IHyperEdgeView>(item.Key, (IHyperEdgeView)item.Value));
        }

        public IEnumerable<Tuple<string, ISingleEdgeView>> GetAllSingleEdges()
        {
            return _edgeList.Where(item => item.Value is ISingleEdgeView).Select(item => new Tuple<String, ISingleEdgeView>(item.Key, (ISingleEdgeView) item.Value));
        }

        public IEdgeView GetEdge(string myEdgePropertyName)
        {
            IEdgeView outValue;

            if (_edgeList.TryGetValue(myEdgePropertyName, out outValue))
            {
                return outValue;
            }
            else
            {
                return null;
            }
        }

        public IHyperEdgeView GetHyperEdge(string myEdgePropertyName)
        {
            return
                (IHyperEdgeView) _edgeList.Where(
                    item => item.Key == myEdgePropertyName && item.Value is IHyperEdgeView).
                                     FirstOrDefault().Value;

        }

        public ISingleEdgeView GetSingleEdge(string myEdgePropertyName)
        {
            return (ISingleEdgeView)_edgeList.Where(item => item.Key == myEdgePropertyName && item.Value is ISingleEdgeView).FirstOrDefault().Value;
        }

        public Stream GetBinaryProperty(string myPropertyName)
        {
            return GetProperty<Stream>(myPropertyName);
        }

        public IEnumerable<Tuple<string, Stream>> GetAllBinaryProperties()
        {
            return _propertyList.Where(item => item.Value is Stream).Select(item => new Tuple<String, Stream>(item.Key, (Stream) item.Value));
        }

        public T GetProperty<T>(string myPropertyName)
        {
            Object outValue;

            if (_propertyList.TryGetValue(myPropertyName, out outValue))
            {
                return (T)outValue;
            }

            return default(T);
        }

        public bool HasProperty(string myPropertyName)
        {
            return _propertyList.ContainsKey(myPropertyName);
        }

        public int GetCountOfProperties()
        {
            return _propertyList.Count;
        }

        public IEnumerable<Tuple<string, object>> GetAllProperties()
        {
            return _propertyList.Select(item => new Tuple<string, object>(item.Key, item.Value));
        }

        public string GetPropertyAsString(string myPropertyName)
        {
            Object outValue;

            if (_propertyList.TryGetValue(myPropertyName, out outValue))
            {
                return outValue.ToString();
            }
            else
            {
                return String.Empty;
            }
        }

        public IEnumerable<IVertexView> GetAllNeighbours(string myEdgePropertyName)
        {
            IEdgeView outValue;

            if (_edgeList.TryGetValue(myEdgePropertyName, out outValue))
            {
                return outValue.GetTargetVertices();
            }
            else
            {
                return new List<IVertexView>();
            }
        }

        #endregion
        
    }
}