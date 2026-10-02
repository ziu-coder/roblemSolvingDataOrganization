namespace ProblemSolving.Part2;

public record Contact(string Name, string Phone, string Email);

public class ContactManager
{
    private readonly Dictionary<string, Contact> contacts =
        new(StringComparer.OrdinalIgnoreCase);

    public int Count => contacts.Count;

    public void Add(Contact contact)
    {
        ArgumentNullException.ThrowIfNull(contact);
        if (string.IsNullOrWhiteSpace(contact.Name))
            throw new ArgumentException("Tên không được để trống.");
        if (!contacts.TryAdd(contact.Name, contact))
            throw new InvalidOperationException("Liên lạc đã tồn tại.");
    }

    public Contact? Find(string name) =>
        contacts.TryGetValue(name, out var contact) ? contact : null;

    public bool Remove(string name) => contacts.Remove(name);

    public void Update(string name, string phone, string email)
    {
        if (!contacts.TryGetValue(name, out var old))
            throw new KeyNotFoundException("Không tìm thấy liên lạc.");
        contacts[name] = old with { Phone = phone, Email = email };
    }
}
