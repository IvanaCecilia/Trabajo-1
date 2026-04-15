// fin main
public interface ITransferible
{
    public void Retirar(decimal retiro);
}
abstract class Cuenta : ITransferible
{
    int id=1;
    protected Cuenta()
    {
        id=+1;
    }
    public abstract void Retirar(decimal retiro);
    public abstract void Depositar(decimal deposito);
}

class CuentaCorriente : Cuenta, ITransferible{
    decimal saldo=0;
    public string nombre;
    public CuentaCorriente(string Nombre)
    {
        nombre = Nombre;
    }
    public override void Retirar(decimal retiro)
    {
        if ((saldo -retiro)< -10000)
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
    public override void Depositar(decimal Deposito)
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
    public override void Retirar(decimal retiro)
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
    public override void Depositar(decimal Deposito)
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