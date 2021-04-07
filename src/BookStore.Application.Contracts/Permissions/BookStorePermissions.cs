namespace BookStore.Permissions
{
    public static class BookStorePermissions
    {

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";

        public const string GroupName = "BookStore";

        public static class Books
        {
            public const string Default = GroupName + ".Books";
            public const string Create = Default + ".Create";
            public const string Update = Default+ ".Update";
            public const string Delete = Default + ".Delete";
        }

        public static class Authors
        {
            public const string Default = GroupName + ".Authors";
            public const string Create = Default + ".Create";
            public const string Update = Default+ ".Update";
            public const string Delete = Default + ".Delete";
        }

    }
}