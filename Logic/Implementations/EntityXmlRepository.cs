﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Logic.Implementations
{
    public abstract class EntityXmlRepository<T> : XmlRepositoryBase<T>
    {
        #region cache control

        private XElement _parentElement;
        private XName xName;

        protected EntityXmlRepository(XName entityName)
            : base(entityName)
        {
        }

        public override XElement ParentElement
        {
            get
            {
                // returns in memory element or get it from file
                return _parentElement ?? (_parentElement = GetParentElement());
            }
            protected set
            {
                _parentElement = value;
            }
        }

        /// <summary>
        /// Gets the parent element for this node type
        /// </summary>
        protected abstract XElement GetParentElement();
        #endregion
    }
}
