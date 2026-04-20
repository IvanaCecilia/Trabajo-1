public interface ITransferible
{
    void Transferir(decimal monto, string cbuDestino);
}
 
abstract class CuentaBancaria:ITransferible
{
    public string CBU {get;}
    public string TipoCuenta {get;}
    public string Titular {get;}
    protected decimal Saldo {get; set;}
    // constructor
    public CuentaBancaria(string cbu, string tipoCuenta, string titular, decimal saldoInicial)
    {
        CBU = cbu;
        TipoCuenta = tipoCuenta;
        Titular = titular?? throw new ArgumentNullException(nameof(titular));
        Saldo = saldoInicial;
    }
    public abstract void Retirar(decimal monto);
    public abstract void Depositar(decimal cantidad);
    // metodo transferir dinero
    public virtual void Transferir(decimal monto, string cbuDestino)
    {
        if (monto > 0 && monto <= Saldo)
        {
            Saldo -= monto;
            Console.WriteLine($"Se han transferido {monto} pesos al CBU {cbuDestino}. Saldo actual: {Saldo} pesos.");
        }
        else
        {
            Console.WriteLine("Monto inválido o saldo insuficiente para transferir.");
        }
    }
} 

class CuentaCorriente : CuentaBancaria, ITransferible{
    public override void Retirar (decimal monto)
    {
        if (monto > 0 && monto <= Saldo)
        {
            Saldo -= monto;
            Console.WriteLine($"Se han retirado {monto} pesos. Saldo actual: {Saldo} pesos.");
        }
        else
        {
            Console.WriteLine("Monto inválido o saldo insuficiente.");
        }

    }
    public override void Depositar(decimal cantidad)
    {
        if (cantidad > 0)
        {
            Saldo += cantidad;
            Console.WriteLine($"Se han depositado {cantidad} pesos. Saldo actual: {Saldo} pesos.");
        }
        else
        {
            Console.WriteLine("La cantidad a depositar debe ser mayor a cero.");
        }
    }
}
class CajaAhorros : CuentaBancaria, ITransferible{
    public virtual void Retirar (decimal monto)
    {
        if (monto > 0 && monto <= Saldo)
        {
            Saldo -= monto;
            Console.WriteLine($"Se han retirado {monto} pesos. Saldo actual: {Saldo} pesos.");
        }
        else
        {
            Console.WriteLine("Monto inválido o saldo insuficiente.");
        }

    }
    public void Depositar(decimal cantidad)
    {
        if (cantidad > 0)
        {
            Saldo += cantidad;
            Console.WriteLine($"Se han depositado {cantidad} pesos. Saldo actual: {Saldo} pesos.");
        }
        else
        {
            Console.WriteLine("La cantidad a depositar debe ser mayor a cero.");
        }
    }
}

class Banco {

}