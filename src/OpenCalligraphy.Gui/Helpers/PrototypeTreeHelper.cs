﻿using OpenCalligraphy.Core.GameData;
using OpenCalligraphy.Core.GameData.Prototypes;
using OpenCalligraphy.Core.GameData.Prototypes.FieldTypes;
using OpenCalligraphy.Core.Locales;
using OpenCalligraphy.Gui.Models;

namespace OpenCalligraphy.Gui.Helpers
{
    [Flags]
    public enum PrototypeTreeHelperFlags
    {
        None                        = 0,
        UseEvalExpressionStrings    = 1 << 0,
        EmbedEmptyRHStructs         = 1 << 1,
    }

    /// <summary>
    /// Helper functions for displaying <see cref="Prototype"/> data in a <see cref="TreeView"/>.
    /// </summary>
    internal static class PrototypeTreeHelper
    {
        #region Build

        public static void SetPrototype(TreeNode root, Prototype prototype, string name, PrototypeTreeHelperFlags flags)
        {
            root.Text = name;

            // If requested, represent eval prototypes by their expression strings
            if (flags.HasFlag(PrototypeTreeHelperFlags.UseEvalExpressionStrings))
            {
                string expressionString = EvalExpressionStringBuilder.TryBuildExpressionString(prototype);
                if (expressionString != string.Empty)
                {
                    TreeNode child = root.Nodes.Add(expressionString);
                    child.Tag = new PrimitiveValueTreeNodeTag(expressionString);
                    return;
                }
            }

            // If this is an empty RHStruct, treat it as a data ref
            if (prototype.DataRef == PrototypeId.Invalid && prototype.FieldGroups.Count == 0 && prototype.ParentDataRef != PrototypeId.Invalid)
            {
                root.Tag = new DataRefTreeNodeTag(prototype.ParentDataRef);
                if (flags.HasFlag(PrototypeTreeHelperFlags.EmbedEmptyRHStructs) == false)
                    return;
            }

            // Load the default data from the top parent and apply overrides from all of its children
            Dictionary<FieldGroupKey, TreeNode> fieldGroupNodes = new();
            Dictionary<FieldKey, TreeNode> fieldNodes = new();

            foreach (Prototype currentPrototype in prototype.IterateHierarchy())
            {
                // Highlight fields overriden by the last child (the prototype we want to inspecting)
                bool highlightFields = currentPrototype == prototype && currentPrototype.ParentDataRef != PrototypeId.Invalid;

                foreach (PrototypeFieldGroup fieldGroup in currentPrototype.OrderBy(fieldGroup => fieldGroup.DeclaringBlueprintId.GetName()))
                {
                    TreeNode fieldGroupNode = GetOrCreateNode(new FieldGroupKey(fieldGroup), root, fieldGroupNodes);
                    fieldGroupNode.Text = fieldGroup.ToString();

                    List<PrototypeField> fieldList = [.. fieldGroup.SimpleFields, .. fieldGroup.ListFields];
                    fieldList.Sort((a, b) => a.FieldId.GetName().CompareTo(b.FieldId.GetName()));

                    foreach (PrototypeField field in fieldList)
                    {
                        TreeNode fieldNode = GetOrCreateNode(new FieldKey(fieldGroup, field), fieldGroupNode, fieldNodes);
                        SetField(fieldNode, field, highlightFields, flags);
                    }
                }
            }

            // Expand prototype field groups by default
            foreach (TreeNode rootChild in root.Nodes)
                rootChild.Expand();
        }

        private static TreeNode GetOrCreateNode<TKey>(TKey key, TreeNode parent, Dictionary<TKey, TreeNode> nodeDict)
        {
            if (nodeDict.TryGetValue(key, out TreeNode node) == false)
            {
                node = parent.Nodes.Add(string.Empty);
                nodeDict.Add(key, node);
            }

            return node;
        }

        private static void SetField(TreeNode node, PrototypeField field, bool highlight, PrototypeTreeHelperFlags flags)
        {
            if (field.StructureType == CalligraphyStructureType.Simple)
                SetSimpleField(node, field, flags);
            else if (field.StructureType == CalligraphyStructureType.List)
                SetListField(node, field, flags);

            if (highlight)
                node.NodeFont = new(node.TreeView.Font, FontStyle.Bold);
        }

        private static void SetSimpleField(TreeNode node, PrototypeField field, PrototypeTreeHelperFlags flags)
        {
            switch (field)
            {
                case PrototypeAssetField assetField:
                    node.Tag = new DataRefTreeNodeTag(assetField.Value);
                    break;

                case PrototypeBooleanField booleanField:
                    node.Tag = new PrimitiveValueTreeNodeTag(booleanField.Value);
                    break;

                case PrototypeCurveField curveField:
                    node.Tag = new DataRefTreeNodeTag(curveField.Value);
                    break;

                case PrototypeDoubleField doubleField:
                    node.Tag = new PrimitiveValueTreeNodeTag(doubleField.Value);
                    break;

                case PrototypeLongField longField:
                    node.Tag = new PrimitiveValueTreeNodeTag(longField.Value);
                    break;

                case PrototypePrototypeField prototypeField:
                    node.Tag = new DataRefTreeNodeTag(prototypeField.Value);
                    break;

                case PrototypeRHStructField rhStructField:
                    node.Nodes.Clear();

                    string value = field.ToString();
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        // Fall back to field data if the prototype is absolutely empty (not even a parent reference)
                        PrototypeId subtype = (PrototypeId)field.GetBlueprintMember().Subtype;
                        value = $"null ({DataDirectory.Instance.GetPrototypeRuntimeBinding(subtype)})";
                    }

                    SetPrototype(node, rhStructField.Value, $"{field.FieldId.GetName()}: {value}", flags);
                    return;

                case PrototypeStringField stringField:
                    node.Tag = new PrimitiveValueTreeNodeTag(stringField.Value);

                    node.Nodes.Clear();
                    string localeString = LocaleManager.Instance.CurrentLocale.GetLocaleString(stringField.Value);
                    if (string.IsNullOrWhiteSpace(localeString) == false)
                    {
                        TreeNode textNode = node.Nodes.Add(localeString);
                        textNode.Tag = new PrimitiveValueTreeNodeTag(localeString);
                        node.Expand();
                    }

                    break;

                case PrototypeTypeField typeField:
                    node.Tag = new DataRefTreeNodeTag(typeField.Value);
                    break;
            }

            // This is set for everything but RHStructs
            node.Text = $"{field.FieldId.GetName()}: {field}";
        }

        private static void SetListField(TreeNode node, PrototypeField field, PrototypeTreeHelperFlags flags)
        {
            node.Nodes.Clear();
            node.Text = $"{field.FieldId.GetName()}: {field}";

            switch (field)
            {
                case PrototypeAssetListField assetListField:
                    for (int i = 0; i < assetListField.Count; i++)
                    {
                        TreeNode child = node.Nodes.Add(string.Empty);
                        AssetId assetId = assetListField[i];
                        child.Text = $"[{i}] {assetId.GetName()} ({assetId})";
                        child.Tag = new DataRefTreeNodeTag(assetId);
                    }
                    break;

                case PrototypePrototypeListField prototypeListField:
                    for (int i = 0; i < prototypeListField.Count; i++)
                    {
                        TreeNode child = node.Nodes.Add(string.Empty);
                        PrototypeId prototypeId = prototypeListField[i];
                        child.Text = $"[{i}] {prototypeId.GetName()} ({prototypeId})";
                        child.Tag = new DataRefTreeNodeTag(prototypeId);
                    }
                    break;

                case PrototypeRHStructListField rhStructListField:
                    for (int i = 0; i < rhStructListField.Count; i++)
                    {
                        Prototype rhStruct = rhStructListField[i];
                        TreeNode child = node.Nodes.Add(string.Empty);
                        SetPrototype(child, rhStruct, $"[{i}] {rhStruct}", flags);
                    }
                    break;

                case PrototypeTypeListField typeListField:
                    for (int i = 0; i < typeListField.Values.Count; i++)
                    {
                        TreeNode child = node.Nodes.Add(string.Empty);
                        AssetTypeId assetTypeId = typeListField[i];
                        child.Text = $"[{i}] {assetTypeId.GetName()} ({assetTypeId})";
                        child.Tag = new DataRefTreeNodeTag(assetTypeId);
                    }
                    break;

                default:
                    node.Text = "UNSUPPORTED LIST FIELD";
                    break;
            }
        }

        private readonly struct FieldGroupKey(PrototypeFieldGroup fieldGroup)
        {
            public readonly BlueprintId DeclaringBlueprintId = fieldGroup.DeclaringBlueprintId;
            public readonly byte BlueprintCopyNumber = fieldGroup.BlueprintCopyNumber;
        }

        private readonly struct FieldKey(PrototypeFieldGroup fieldGroup, PrototypeField field)
        {
            public readonly FieldGroupKey FieldGroupKey = new(fieldGroup);
            public readonly StringId FieldId = field.FieldId;
        }

        #endregion

        #region Search

        public static void SearchTreeView(TreeView treeView, string pattern, List<TreeNode> outNodeList)
        {
            ArgumentNullException.ThrowIfNull(treeView);
            ArgumentNullException.ThrowIfNull(outNodeList);

            if (treeView.Nodes.Count == 0)
                return;

            if (string.IsNullOrEmpty(pattern))
                return;

            TreeNode root = treeView.Nodes[0];
            SearchTreeViewHelper(root, pattern, outNodeList);
        }

        private static void SearchTreeViewHelper(TreeNode node, string pattern, List<TreeNode> outNodeList)
        {
            if (node.Text.Contains(pattern, StringComparison.OrdinalIgnoreCase))
                outNodeList.Add(node);

            foreach (TreeNode child in node.Nodes)
                SearchTreeViewHelper(child, pattern, outNodeList);
        }

        public static void ColorAndExpandTreeNode(TreeNode treeNode, Color color)
        {
            treeNode.BackColor = color;
            treeNode.Expand();

            TreeNode parent = treeNode.Parent;
            if (parent != null && parent != treeNode.TreeView.Nodes[0])
                ColorAndExpandTreeNode(parent, color);
        }

        public static void ClearTreeViewBackColor(TreeView treeView)
        {
            ArgumentNullException.ThrowIfNull(treeView);

            if (treeView.Nodes.Count == 0)
                return;

            ClearTreeViewBackColorHelper(treeView.Nodes[0]);
        }

        private static void ClearTreeViewBackColorHelper(TreeNode treeNode)
        {
            treeNode.BackColor = Color.Empty;

            foreach (TreeNode child in treeNode.Nodes)
                ClearTreeViewBackColorHelper(child);
        }

        #endregion
    }
}
