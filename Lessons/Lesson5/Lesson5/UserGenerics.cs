// Covariant interface (out) - used for reading/output
public interface IRepository<out T>
{
	T GetById(Guid id);
	IEnumerable<T> GetAll();
}

// Contravariant interface (in) - used for input
public interface ICommandHandler<in T>
{
	void Handle(T command);
}

// Base entity
public class Entity
{
	public Guid Id { get; } = Guid.NewGuid();
}

// Specific entity: User
public class User : Entity
{
	public string Name { get; }

	public User(string name)
	{
		Name = name;
	}
}

// Repository implementation
public class UserRepository : IRepository<User>
{
	private readonly List<User> _users = new();

	public UserRepository()
	{
		_users.Add(new User("Alice"));
		_users.Add(new User("Bob"));
	}

	public User GetById(Guid id) => _users.Find(user => user.Id == id);

	public IEnumerable<User> GetAll() => _users;
}

// Command class
public class UpdateUserNameCommand
{
	public Guid UserId { get; }
	public string NewName { get; }

	public UpdateUserNameCommand(Guid userId, string newName)
	{
		UserId = userId;
		NewName = newName;
	}
}

// Command handler implementation
public class UpdateUserNameHandler : ICommandHandler<UpdateUserNameCommand>
{
	private readonly List<User> _users;

	public UpdateUserNameHandler(List<User> users)
	{
		_users = users;
	}

	public void Handle(UpdateUserNameCommand command)
	{
		var user = _users.Find(u => u.Id == command.UserId);
		if (user != null)
		{
			Console.WriteLine($"User {user.Name} updated to {command.NewName}");
		}
	}
}

// Main program
class UserGenerics
{
	public static void Test()
	{
		IRepository<Entity> repository = new UserRepository(); // Covariance (out)
		var users = repository.GetAll();

		List<User> userList = new List<User>(users as IEnumerable<User>);
		ICommandHandler<UpdateUserNameCommand> handler = new UpdateUserNameHandler(userList); // Contravariance (in)

		foreach (var user in users)
		{
			Console.WriteLine($"User: {(user as User)?.Name}");
		}

		if (userList.Count > 0)
		{
			var command = new UpdateUserNameCommand(userList[0].Id, "Charlie");
			handler.Handle(command);
		}
	}
}
