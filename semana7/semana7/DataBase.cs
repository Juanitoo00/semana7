using System;
using SQLite;
namespace semana7
{
	public interface DataBase
	{
		SQLiteAsyncConnection GetConnection();

	}
}

