﻿using System.Collections;

namespace OpenCalligraphy.Core.GameData.Prototypes
{
    public class Prototype : IEnumerable<PrototypeFieldGroup>
    {
        private readonly List<PrototypeFieldGroup> _fieldGroups = new();

        public PrototypeId DataRef { get; set; }
        public PrototypeId ParentDataRef { get; set; }
        public IReadOnlyList<PrototypeFieldGroup> FieldGroups { get => _fieldGroups; }
        public bool HasInstanceData { get => _fieldGroups.Count > 0; }

        public Prototype()
        {
        }

        public override string ToString()
        {
            if (HasInstanceData == false)
                return ParentDataRef.GetName();

            if (DataRef != PrototypeId.Invalid)
                return DataRef.GetName();

            return DataDirectory.Instance.GetPrototypeRuntimeBinding(ParentDataRef);
        }

        public List<PrototypeFieldGroup>.Enumerator GetEnumerator()
        {
            return _fieldGroups.GetEnumerator();
        }

        IEnumerator<PrototypeFieldGroup> IEnumerable<PrototypeFieldGroup>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Iterates all prototypes in hierarchy from the top parent to this instance.
        /// </summary>
        public IEnumerable<Prototype> IterateHierarchy()
        {
            Stack<Prototype> prototypeStack = new();

            Prototype prototype = this;
            while (prototype != null)
            {
                prototypeStack.Push(prototype);
                prototype = GameDatabase.GetPrototype(prototype.ParentDataRef);
            }

            while (prototypeStack.Count > 0)
                yield return prototypeStack.Pop();
        }

        public void ParseFrom(BinaryReader reader)
        {
            _fieldGroups.Clear();

            PrototypeDataHeader header = new(reader);
            ParentDataRef = header.ReferenceType;
            
            if (header.DataExists == false)
                return;

            int numFieldGroups = reader.ReadUInt16();
            for (int i = 0; i < numFieldGroups; i++)
            {
                BlueprintId declaringBlueprintId = (BlueprintId)reader.ReadUInt64();
                byte blueprintCopyNumber = reader.ReadByte();
                PrototypeFieldGroup fieldGroup = new(declaringBlueprintId, blueprintCopyNumber);

                fieldGroup.ParseFieldsFrom(reader, CalligraphyStructureType.Simple);
                fieldGroup.ParseFieldsFrom(reader, CalligraphyStructureType.List);

                _fieldGroups.Add(fieldGroup);
            }
        }

        /// <summary>
        /// Searches this <see cref="Prototype"/> and its parents for the field with the specified <see cref="StringId"/>.
        /// </summary>
        public T GetField<T>(StringId fieldId) where T: PrototypeField
        {
            // Search this prototype
            foreach (PrototypeFieldGroup fieldGroup in _fieldGroups)
            {
                T field = fieldGroup.GetField<T>(fieldId);
                if (field != null)
                    return field;
            }

            // Search parent if not found
            if (ParentDataRef != PrototypeId.Invalid)
                return ParentDataRef.AsPrototype()?.GetField<T>(fieldId);

            // Not found and no parents to search
            return null;
        }
    }
}
