//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

namespace DataTables.GeneratorCore
{
    public sealed partial class DataTableProcessor
    {
        public abstract class GenericDataProcessor<T> : DataProcessor
        {
            public override System.Type Type
            {
                get
                {
                    return typeof(T);
                }
            }

            public abstract T Parse(string value);
        }
    }
}
