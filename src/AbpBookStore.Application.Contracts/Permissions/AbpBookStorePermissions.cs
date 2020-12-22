namespace AbpBookStore.Permissions
{
    public static class AbpBookStorePermissions
    {
        // public const string GroupName = "AbpBookStore";

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";

        public const string GroupName = "BookStore";

        public static class Book
        {
            public const string Default = GroupName + ".Book";
            public const string Create = Default + ".Create";
            public const string Update = Default+ ".Update";
            public const string Delete = Default + ".Delete";
        }

        public static class Author
        {
            public const string Default = GroupName + ".Author";
            public const string Create = Default + ".Create";
            public const string Update = Default+ ".Update";
            public const string Delete = Default + ".Delete";
        }
    }
}