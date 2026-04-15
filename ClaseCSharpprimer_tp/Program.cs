// fin main
public interface ITransferible
{
    public void Retirar();
}
abstract class Cuenta : ITransferible
{
    int id=1;
    protected Cuenta()
    {
        id=+1;
    }
    public void Retirar()
    {
        Console.WriteLine("cuenta");
    }
}

class CuentaCorriente : Cuenta, ITransferible{
    decimal saldo=0;
    string nombre;
    CuentaCorriente(string Nombre)
    {
        nombre = Nombre;
    }
    void Retirar(decimal retiro)
    {
        if (retiro <= saldo)
        {
            saldo-=retiro;
            Console.WriteLine("Saldo restante: "+saldo);
        }
        else Console.WriteLine("Monto insuficiente");
    }
    public void Transferir()
    {
        Console.WriteLine("transferir");
    }
    public void Depositar(decimal Deposito)
    {
        if (Deposito >0)
        {
            saldo+=Deposito;
            Console.WriteLine("Saldo restante: "+saldo);
        }
        else Console.WriteLine("Monto invalido");
    }
}

class CajaAhorros : Cuenta, ITransferible{
    decimal saldo=0;
    void Retirar(decimal retiro)
    {
        if (retiro <= saldo)
        {
            saldo-=retiro;
            Console.WriteLine("Saldo restante: "+saldo);
        }
        else Console.WriteLine("Monto insuficiente");
    }
    public void Transferir()
    {
        Console.WriteLine("transferir");
    }
    public void Depositar(decimal Deposito)
    {
        if (Deposito >0)
        {
            saldo+=Deposito;
            Console.WriteLine("Saldo restante: "+saldo);
        }
        else Console.WriteLine("Monto invalido");
    }
}

class Banco {
    void Transferir(ITransferible cuenta)
    {
    }
}