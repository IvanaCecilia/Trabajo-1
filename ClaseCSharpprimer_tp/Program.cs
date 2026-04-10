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
}

class CajaAhorros : Cuenta, ITransferible{
    void Retirar()
    {
        Console.WriteLine("ahorros");
    }
}

class Banco {

}