using SpecianBP.DataProtection;
using SpecianBP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecianBP.Db
{
    public class TestData
    {
        public class Users
        {
            public static User JanSpecian = new User
            {
                Id = Guid.Parse("18F93F80-A5DD-42EF-8325-B4057AC7A959"),
                DisplayName = "Jan Specian",
                UserName = "specian.j",
                IdentityId = "0a45a9b4-da28-4acf-850d-aa5b80710b24",
            };
            public static User LauraNorman = new User
            {
                Id = Guid.Parse("76C186D9-9B98-49F5-9690-FBCBAC73EE67"),
                DisplayName = "Laura Norman",
                UserName = "Norman"
            };
            public static User AlexanderCarson = new User
            {
                DisplayName = "Carson Alexander",
                UserName = "Alexander"
            };
            public static User ResourceEditor = new User
            {
                //test user
                DisplayName = "editor",
                UserName = "editor",
                IdentityId = "88ab7bed-51f1-4d21-acd9-2dc192f1f459" //pwd trumpetka
            };
            public static User PavelVasek = new User
            {
                DisplayName = "Pavel Vasek",
                UserName = "vasek.p",
                IdentityId = "1fcc25dc-046f-480b-88b7-a61a8551138d"
            };
        }

        public class UserRoles
        {
            public static UserRole Admin = new UserRole
            {
                Id = new Guid("13207BD5-E0B2-4F73-9535-F0E11788F09C"),
                Name = "Admin",
                GrantsSerialized = Grants.Global.User.Admin.Id
            };

            public static UserRole Editor = new UserRole
            {
                Id = new Guid("03EF54DF-8E0A-4C63-9441-E8755C85DCF0"),
                Name = "Editor",
                GrantsSerialized = TestData.ConcatStringsHelper(new string[]
                {
                    Grants.Data.User.Get.Id,
                })
            };
            public static UserRole Lister = new UserRole
            {
                Id = new Guid("9df04ee4-15ad-4b1f-a8d3-13071739d2c7"),
                Name = "Lister",
                GrantsSerialized = TestData.ConcatStringsHelper(new string[]
                {
                    Grants.Data.User.Get.Id, Grants.Data.Values.Get.Id,
                })
            };
        }

        //comma separated strings in one string
        private static string ConcatStringsHelper(String[] strings)
        {
            StringBuilder sb = new StringBuilder();
            foreach (String s in strings)
            {
                sb.Append(s);
                sb.Append(",");
            }
            return sb.ToString();
        }

        private static string ConcatStringsHelper(IEnumerable<IGrant> grants)
        {
            StringBuilder sb = new StringBuilder();
            foreach (IGrant s in grants)
            {
                sb.Append(s.Id);
                sb.Append(",");
            }
            return sb.ToString();
        }

        public class UserUserRoles
        {
            public static UserUserRole JanSpecianAdminRole = new UserUserRole
            {
                User = Users.JanSpecian,
                UserRole = UserRoles.Admin
            };
            public static UserUserRole LauraNormanAdminRole = new UserUserRole
            {
                User = Users.LauraNorman,
                UserRole = UserRoles.Lister
            };
            public static UserUserRole PavelVasekRole = new UserUserRole
            {
                User = Users.PavelVasek,
                UserRole = UserRoles.Lister
            };
            public static UserUserRole ResourceEditorRoleEditor = new UserUserRole
            {
                User = Users.ResourceEditor,
                UserRole = UserRoles.Editor
            };
        }
    }
}
