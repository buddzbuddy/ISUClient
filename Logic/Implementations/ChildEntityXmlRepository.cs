using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Logic.Implementations
{
    public abstract class ChildEntityXmlRepository<T> : XmlRepositoryBase<T>
    {
        private object _currentParentId;
        private object _lastParentId;

        private XElement _parentElement;

        public override XElement ParentElement
        {
            get
            {
                if (_parentElement == null)
                {
                    _parentElement = GetParentElement(_currentParentId);
                    _lastParentId = _currentParentId;
                }
                return _parentElement;
            }
            protected set
            {
                _parentElement = value;
            }
        }

        /// <summary>
        /// Defines wich parent entity is active
        /// when this property changes, the parent element field is nuled, forcing the parent element to be updated
        /// </summary>
        protected object CurrentParentId
        {
            get
            {
                return _currentParentId;
            }
            set
            {
                _currentParentId = value;
                if (value != _lastParentId)
                {
                    _parentElement = null;
                }
            }
        }



        protected ChildEntityXmlRepository(XName entityName) : base(entityName) { }

        protected abstract XElement GetParentElement(object parentId);

        protected abstract object GetParentId(T entity);


        public override IEnumerable<T> GetAll(object parentId)
        {
            CurrentParentId = parentId;
            return ParentElement.Elements(ElementName).Select(Selector);
        }

        public override void Insert(T entity, bool persistir = true)
        {
            CurrentParentId = GetParentId(entity);
            base.Insert(entity, persistir);
        }

        public override void Update(T entity, bool persistir = true)
        {
            CurrentParentId = GetParentId(entity);
            base.Update(entity, persistir);
        }

        public override void Delete(T entity, bool persistir = true)
        {
            CurrentParentId = GetParentId(entity);
            base.Delete(entity, persistir);
        }
    }

}
