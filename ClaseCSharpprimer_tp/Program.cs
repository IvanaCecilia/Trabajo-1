// fin main
public interface ITransferible
{
    public void Retirar();
}
abstract class Cuenta : ITransferible
{
    public void Retirar()
    {
        Console.WriteLine("cuenta");
    }
}

class CuentaCorriente : Cuenta, ITransferible{
    void Retirar()
    {
        Console.WriteLine("corriente");
    }
    public void Transferir()
    {
        Console.WriteLine("transferir");
    }
    public void Depositar()
    {
        Console.WriteLine("depositar");
    
    }

}
class CajaAhorros : Cuenta, ITransferible{
    void Retirar()
    {
        Console.WriteLine("ahorros");
    }
}

class Banco {
    void Transferir(ITransferible cuenta)
    {
        cuenta.Retirar();
    }
}