using System;
namespace Hillel_Lesson17_HW
{
	public interface IRepository<T>
	{
		T GetByName(string name);

		void Add(T entity);
	}
}

