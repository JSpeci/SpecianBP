using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecianBP.DataProtection
{
    public class Grants
    {
        public static class Global
        {
            private const string GrantTypePrefix = nameof(Global);

            public static class User
            {
                private const string GrantTypePrefix = nameof(Global);
                public static readonly IGrant Admin = new UserGrant($"{GrantTypePrefix}.{nameof(Admin)}", () => All.Where(x => x != Admin).ToList());
                public static readonly IGrant Import = new UserGrant($"{GrantTypePrefix}.{nameof(Import)}");
            }
        }

        public static class Action
        {
            private const string GrantTypePrefix = nameof(Action);

            public static class User
            {
                private static readonly string Prefix = $"{GrantTypePrefix}.{nameof(User)}";
                public static readonly IGrant List = new UserGrant($"{Prefix}.{nameof(List)}");
                public static readonly IGrant Edit = new UserGrant($"{Prefix}.{nameof(Edit)}");
            }
        }

        public static class Data
        {
            private const string GrantTypePrefix = nameof(Data);

            public static class User
            {
                private static readonly string Prefix = $"{GrantTypePrefix}.{nameof(User)}";
                public static readonly IGrant Get = new UserGrant($"{Prefix}.{nameof(Get)}");
                public static readonly IGrant Edit = new UserGrant($"{Prefix}.{nameof(Edit)}");
                public static readonly IGrant Remove = new UserGrant($"{Prefix}.{nameof(Remove)}");
            }
            public static class UserUserRole
            {
                private static readonly string Prefix = $"{GrantTypePrefix}.{nameof(UserUserRole)}";
                public static readonly IGrant Get = new UserGrant($"{Prefix}.{nameof(Get)}");
                public static readonly IGrant Edit = new UserGrant($"{Prefix}.{nameof(Edit)}");
                public static readonly IGrant Remove = new UserGrant($"{Prefix}.{nameof(Remove)}");
            }
            public static class UserRole
            {
                private static readonly string Prefix = $"{GrantTypePrefix}.{nameof(UserRole)}";
                public static readonly IGrant Get = new UserGrant($"{Prefix}.{nameof(Get)}");
                public static readonly IGrant Edit = new UserGrant($"{Prefix}.{nameof(Edit)}");
                public static readonly IGrant Remove = new UserGrant($"{Prefix}.{nameof(Remove)}");
            }
            public static class Values
            {
                private static readonly string Prefix = $"{GrantTypePrefix}.{nameof(UserRole)}";
                public static readonly IGrant Get = new UserGrant($"{Prefix}.{nameof(Get)}");
                public static readonly IGrant Edit = new UserGrant($"{Prefix}.{nameof(Edit)}");
                public static readonly IGrant Remove = new UserGrant($"{Prefix}.{nameof(Remove)}");
            }
        }

        public static IEnumerable<IGrant> All => _grantsFlat.Values;
        private static readonly Dictionary<string, IGrant> _grantsFlat = DataProtectionUtils.GetAllGrantsFlat<Grants>();
        private static readonly Dictionary<string, IGrant> GrantsFlat = DataProtectionUtils.GetAllGrantsFlat<Grants>();

        public static IEnumerable<IGrant> GetGrants(IEnumerable<string> grantsIds)
        {
            return grantsIds.Select(GetGrant).Where(x => x != null).Distinct().ToList();
        }

        public static IGrant GetGrant(string grantId)
        {
            if (!GrantsFlat.ContainsKey(grantId))
            {
                return null;
            }
            var grant = GrantsFlat[grantId];
            return grant;
        }

    }
}
