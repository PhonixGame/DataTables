// <auto-generated />
#pragma warning disable CS0105
using DataTables.Tests;
using DataTables.Validation;
using DataTables;
using MessagePack;
using System.Collections.Generic;
using System;

namespace DataTables.Tests.Tables
{
   public sealed partial class UserLevelTable : TableBase<UserLevel>, ITableUniqueValidate
   {
        public Func<UserLevel, int> PrimaryKeySelector => primaryIndexSelector;
        readonly Func<UserLevel, int> primaryIndexSelector;

        readonly UserLevel[] secondaryIndex0;
        readonly Func<UserLevel, int> secondaryIndex0Selector;

        public UserLevelTable(UserLevel[] sortedData)
            : base(sortedData)
        {
            this.primaryIndexSelector = x => x.Level;
            this.secondaryIndex0Selector = x => x.Exp;
            this.secondaryIndex0 = CloneAndSortBy(this.secondaryIndex0Selector, System.Collections.Generic.Comparer<int>.Default);
            OnAfterConstruct();
        }

        partial void OnAfterConstruct();

        public RangeView<UserLevel> SortByExp => new RangeView<UserLevel>(secondaryIndex0, 0, secondaryIndex0.Length - 1, true);

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public UserLevel FindByLevel(int key)
        {
            var lo = 0;
            var hi = data.Length - 1;
            while (lo <= hi)
            {
                var mid = (int)(((uint)hi + (uint)lo) >> 1);
                var selected = data[mid].Level;
                var found = (selected < key) ? -1 : (selected > key) ? 1 : 0;
                if (found == 0) { return data[mid]; }
                if (found < 0) { lo = mid + 1; }
                else { hi = mid - 1; }
            }
            return ThrowKeyNotFound(key);
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public bool TryFindByLevel(int key, out UserLevel result)
        {
            var lo = 0;
            var hi = data.Length - 1;
            while (lo <= hi)
            {
                var mid = (int)(((uint)hi + (uint)lo) >> 1);
                var selected = data[mid].Level;
                var found = (selected < key) ? -1 : (selected > key) ? 1 : 0;
                if (found == 0) { result = data[mid]; return true; }
                if (found < 0) { lo = mid + 1; }
                else { hi = mid - 1; }
            }
            result = default;
            return false;
        }

        public UserLevel FindClosestByLevel(int key, bool selectLower = true)
        {
            return FindUniqueClosestCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<int>.Default, key, selectLower);
        }

        public RangeView<UserLevel> FindRangeByLevel(int min, int max, bool ascendant = true)
        {
            return FindUniqueRangeCore(data, primaryIndexSelector, System.Collections.Generic.Comparer<int>.Default, min, max, ascendant);
        }

        public UserLevel FindByExp(int key)
        {
            return FindUniqueCoreInt(secondaryIndex0, secondaryIndex0Selector, System.Collections.Generic.Comparer<int>.Default, key, true);
        }
        
        public bool TryFindByExp(int key, out UserLevel result)
        {
            return TryFindUniqueCoreInt(secondaryIndex0, secondaryIndex0Selector, System.Collections.Generic.Comparer<int>.Default, key, out result);
        }

        public UserLevel FindClosestByExp(int key, bool selectLower = true)
        {
            return FindUniqueClosestCore(secondaryIndex0, secondaryIndex0Selector, System.Collections.Generic.Comparer<int>.Default, key, selectLower);
        }

        public RangeView<UserLevel> FindRangeByExp(int min, int max, bool ascendant = true)
        {
            return FindUniqueRangeCore(secondaryIndex0, secondaryIndex0Selector, System.Collections.Generic.Comparer<int>.Default, min, max, ascendant);
        }


        void ITableUniqueValidate.ValidateUnique(ValidateResult resultSet)
        {
#if !DISABLE_MASTERMEMORY_VALIDATOR

            ValidateUniqueCore(data, primaryIndexSelector, "Level", resultSet);       
            ValidateUniqueCore(secondaryIndex0, secondaryIndex0Selector, "Exp", resultSet);       

#endif
        }

#if !DISABLE_MASTERMEMORY_METADATABASE

        public static DataTables.Meta.MetaTable CreateMetaTable()
        {
            return new DataTables.Meta.MetaTable(typeof(UserLevel), typeof(UserLevelTable), "UserLevel",
                new DataTables.Meta.MetaProperty[]
                {
                    new DataTables.Meta.MetaProperty(typeof(UserLevel).GetProperty("Level")),
                    new DataTables.Meta.MetaProperty(typeof(UserLevel).GetProperty("Exp")),
                },
                new DataTables.Meta.MetaIndex[]{
                    new DataTables.Meta.MetaIndex(new System.Reflection.PropertyInfo[] {
                        typeof(UserLevel).GetProperty("Level"),
                    }, true, true, System.Collections.Generic.Comparer<int>.Default),
                    new DataTables.Meta.MetaIndex(new System.Reflection.PropertyInfo[] {
                        typeof(UserLevel).GetProperty("Exp"),
                    }, false, true, System.Collections.Generic.Comparer<int>.Default),
                });
        }

#endif
    }
}