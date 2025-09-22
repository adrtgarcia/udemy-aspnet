using IntroEFCore;
using IntroEFCore.Entidades;
using System.Linq;

Console.WriteLine("\nOperações CRUD");
AppDbContext db = new();

Console.WriteLine("\nC - create\n");

Console.WriteLine("add: maria, 23/09/2004");
Cliente c = new() { Nome = "maria", DataNascimento = new DateTime(2004, 9, 23) };
db.Cliente.Add(c);

Console.WriteLine("add: joão, 09/03/2009");
c = new() { Nome = "joão", DataNascimento = new DateTime(2009, 3, 9) };
db.Cliente.Add(c);

Console.WriteLine("add: ana, 22/09/2025");
c = new() { Nome = "ana", DataNascimento = new DateTime(2025, 9, 22) };
db.Cliente.Add(c);

db.SaveChanges();

Console.WriteLine("\nR - read\n");

var listaClientes = db.Cliente.ToList();
foreach(var cliente in listaClientes) /* poderia também aplicar filtros com linq */
    Console.WriteLine(
        $"id: {cliente.Id}" +
        $"\t\tnome: {cliente.Nome}" +
        $"\t\tdata de nascimento: {cliente.DataNascimento.ToShortDateString()}"
    );

Console.WriteLine("\nU - update\n");

var clienteAtt = listaClientes.Where(c => c.Nome.Contains('a')).FirstOrDefault();
if (clienteAtt != null)
{
    Console.WriteLine("cliente encontrado:");
    Console.WriteLine(
        $"id: {clienteAtt.Id}" +
        $"\t\tnome: {clienteAtt.Nome}" +
        $"\t\tdata de nascimento: {clienteAtt.DataNascimento.ToShortDateString()}"
    );

    Console.WriteLine("nome = josé");
    clienteAtt.Nome = "josé";
    
    db.Entry<Cliente>(clienteAtt);
    db.SaveChanges();

    Console.WriteLine("\nlista de clientes:");
    foreach (var cliente in listaClientes)
        Console.WriteLine(
            $"id: {cliente.Id}" +
            $"\t\tnome: {cliente.Nome}" +
            $"\t\tdata de nascimento: {cliente.DataNascimento.ToShortDateString()}"
        );
}
else
    Console.WriteLine("cliente não encontrado");

Console.WriteLine("\nD - delete\n");

var clienteDel = listaClientes.Where(c => c.DataNascimento.Year == 2009).LastOrDefault();
if (clienteDel != null)
{
    Console.WriteLine("cliente encontrado:");
    Console.WriteLine(
        $"id: {clienteDel.Id}" +
        $"\t\tnome: {clienteDel.Nome}" +
        $"\t\tdata de nascimento: {clienteDel.DataNascimento.ToShortDateString()}"
    );
        
    db.Attach(clienteDel);
    db.Remove(clienteDel);
    db.SaveChanges();

    Console.WriteLine("\nlista de clientes:");
    foreach (var cliente in listaClientes)
        Console.WriteLine(
            $"id: {cliente.Id}" +
            $"\t\tnome: {cliente.Nome}" +
            $"\t\tdata de nascimento: {cliente.DataNascimento.ToShortDateString()}"
        );
}
else
    Console.WriteLine("cliente não encontrado");
