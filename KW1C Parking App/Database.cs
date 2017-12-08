using System;
using SQLite;

public class Class1
{
	public Class1()
	{
        public interface ISQLite
    {
        //alleen deze method is specifiek per platform
        SQLiteConnection GetConnection();
    }
}
}
