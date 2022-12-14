// <auto-generated />
#pragma warning disable CS0105
using ConsoleApp.Tables;
using ConsoleApp;
using MasterMemory.Validation;
using MasterMemory;
using MessagePack;
using System.Buffers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq.Expressions;
using System.Linq;
using System.Reflection;
using System.Text;
using System;

namespace ConsoleApp.Tables
{
   public sealed partial class MonsterTable : TableBase<Monster>, ITableUniqueValidate
   {
        public Func<Monster, int> PrimaryKeySelector => primaryIndexSelector;
        readonly Func<Monster, int> primaryIndexSelector;


        public MonsterTable(Monster[] sortedData)
            : base(sortedData)
        {
            this.primaryIndexSelector = x => x.MonsterId;
            OnAfterConstruct();
        }

        partial void OnAfterConstruct();


        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public Monster FindByMonsterId(int key)
        {
            var lo = 0;
            var hi = data.Length - 1;
            while (lo <= hi)
            {
                var mid = (int)(((uint)hi + (uint)lo) >> 1);
                var selected = data[mid].MonsterId;
                var found = (selected < key) ? -1 : (selected > key) ? 1 : 0;
                if (found == 0) { return data[mid]; }
                if (found < 0) { lo = mid + 1; }
                else { hi = mid - 1; }
            }
            return ThrowKeyNotFound(key);
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public bool TryFindByMonsterId(int key, out Monster result)
        {
            var lo = 0;
            var hi = data.Length - 1;
            while (lo <= hi)
            {
                var mid = (int)(((uint)hi + (uint)lo) >> 1);
                var selected = data[mid].MonsterId;
                var found = (selected < key) ? -1 : (selected > key) ? 1 : 0;
                if (found == 0) { result = data[mid]; return true; }
                if (found < 0) { lo = mid + 1; }
                else { hi = mid - 1; }
            }
            result = default;
            return false;
        }

        public Monster FindClosestByMonsterId(int key, bool selectLower = true)
        {
            return FindUniqueClosestCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<int>.Default, key, selectLower);
        }

        public RangeView<Monster> FindRangeByMonsterId(int min, int max, bool ascendant = true)
        {
            return FindUniqueRangeCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<int>.Default, min, max, ascendant);
        }


        void ITableUniqueValidate.ValidateUnique(ValidateResult resultSet)
        {
#if !DISABLE_MASTERMEMORY_VALIDATOR

            ValidateUniqueCore(data, primaryIndexSelector, "MonsterId", resultSet);       

#endif
        }

#if !DISABLE_MASTERMEMORY_METADATABASE

        public static MasterMemory.Meta.MetaTable CreateMetaTable()
        {
            return new MasterMemory.Meta.MetaTable(typeof(Monster), typeof(MonsterTable), "monster",
                new MasterMemory.Meta.MetaProperty[]
                {
                    new MasterMemory.Meta.MetaProperty(typeof(Monster).GetProperty("MonsterId")),
                    new MasterMemory.Meta.MetaProperty(typeof(Monster).GetProperty("Name")),
                    new MasterMemory.Meta.MetaProperty(typeof(Monster).GetProperty("MaxHp")),
                },
                new MasterMemory.Meta.MetaIndex[]{
                    new MasterMemory.Meta.MetaIndex(new System.Reflection.PropertyInfo[] {
                        typeof(Monster).GetProperty("MonsterId"),
                    }, true, true, System.Collections.Generic.Comparer<int>.Default),
                });
        }

#endif
    }
}