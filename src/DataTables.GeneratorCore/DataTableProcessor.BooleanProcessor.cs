//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using System.IO;

namespace DataTables.GeneratorCore
{
    public sealed partial class DataTableProcessor
    {
        private sealed class BooleanProcessor : GenericDataProcessor<bool>
        {
            public override bool IsSystem
            {
                get
                {
                    return true;
                }
            }

            public override string LanguageKeyword
            {
                get
                {
                    return "bool";
                }
            }

            public override string[] GetTypeStrings()
            {
                return new string[]
                {
                    "bool",
                    "boolean",
                    "system.boolean"
                };
            }

            public override bool Parse(string value)
            {
                if (string.IsNullOrEmpty(value))
                {
                    return false;
                }

                if (value == "0" || string.Compare(value, "n", true) == 0 || string.Compare(value, "no", true) == 0)
                {
                    return false;
                }

                if (value == "1" || string.Compare(value, "y", true) == 0 || string.Compare(value, "yes", true) == 0)
                {
                    return true;
                }

                return bool.Parse(value.ToLowerInvariant());
            }

            public override string GenerateDeserializeCode(GenerationContext context, string typeName, string propertyName, int depth)
            {
                return $"{propertyName} = reader.ReadBoolean();";
            }

            public override void WriteToStream(BinaryWriter binaryWriter, string value)
            {
                binaryWriter.Write(Parse(value));
            }
        }
    }
}
