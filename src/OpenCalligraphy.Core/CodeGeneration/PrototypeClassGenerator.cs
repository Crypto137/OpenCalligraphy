using OpenCalligraphy.Core.GameData;
using OpenCalligraphy.Core.Logging;

namespace OpenCalligraphy.Core.CodeGeneration
{
    public static class PrototypeClassGenerator
    {
        private static readonly Logger Logger = LogManager.CreateLogger();

        public static void Generate(string outputPath)
        {
            // Generate prototype classes
            Dictionary<string, GeneratedPrototypeClass> prototypeClassDict = new();

            foreach (Blueprint blueprint in DataDirectory.Instance.IterateBlueprints())
            {
                string runtimeBinding = blueprint.RuntimeBinding;

                if (prototypeClassDict.TryGetValue(runtimeBinding, out GeneratedPrototypeClass prototypeClass) == false)
                {
                    prototypeClass = new(runtimeBinding);
                    prototypeClassDict.Add(runtimeBinding, prototypeClass);
                }

                foreach (BlueprintReference blueprintRef in blueprint.Parents)
                    prototypeClass.AddParent(blueprintRef.BlueprintId);

                foreach (BlueprintMember member in blueprint.Members)
                    prototypeClass.AddField(member.FieldName, member.BaseType, member.StructureType, member.Subtype);
            }

            Logger.Info($"Found {prototypeClassDict.Count} unique runtime bindings");

            // Write the results
            string directory = Path.GetDirectoryName(outputPath);
            if (Directory.Exists(directory) == false)
                Directory.CreateDirectory(directory);

            using (StreamWriter writer = new(outputPath))
            {
                // Sort classes for consistent output between versions so that we can more easily compare
                foreach (GeneratedPrototypeClass prototypeClass in prototypeClassDict.Values.OrderBy(prototypeClass => prototypeClass.Name))
                    writer.WriteLine(prototypeClass.GenerateCode());
            }
        }
    }
}
