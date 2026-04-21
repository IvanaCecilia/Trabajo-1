public interface ITransferible
{
    void Transferir(decimal monto, string cbuDestino);
}
 
abstract class CuentaBancaria:ITransferible
{
    protected int CBU {get;}
    public string TipoCuenta {get;}
    public string Titular {get;}
    protected decimal saldo {get; set;}
    // constructor
    public CuentaBancaria( string tipoCuenta, string titular)
    {
        CBU =+1;
        TipoCuenta = tipoCuenta;
        Titular = titular?? throw new ArgumentNullException(nameof(titular));
        saldo = 0;
    }
    public abstract void Retirar(decimal monto);
    public abstract void Depositar(decimal cantidad);
    // metodo transferir dinero
    public virtual void Transferir(decimal monto, string cbuDestino)
    {
        if (monto > 0 && monto <= saldo)
        {
            saldo -= monto;
            Console.WriteLine($"Se han transferido {monto} pesos al CBU {cbuDestino}. Saldo actual: {saldo} pesos.");
        }
        else
        {
            Console.WriteLine("Monto inválido o saldo insuficiente para transferir.");
        }
    }
} 

class CuentaCorriente : CuentaBancaria{
    public CuentaCorriente(string cbu, string titular) : base("Cuenta Corriente", titular)
    {
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
class CajaAhorros : CuentaBancaria{
    public CajaAhorros(string cbu, string titular) : base("Caja de Ahorros", titular)
    {
    }
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

}