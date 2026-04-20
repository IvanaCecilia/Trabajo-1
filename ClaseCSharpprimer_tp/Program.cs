public interface ITransferible
{
    void Transferir(decimal monto, string cbuDestino);
}
 
abstract class CuentaBancaria:Itransferible
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
    //metodo depositar dinero
    public void Depositar(decimal cantidad)
    {
        if (cantidad > 0)
        {
            Saldo += cantidad;
            Console.WriteLine($"Se han depositado {cantidad} pesos. Saldo actual: {Saldo} pesos.");
        }
        // metodo retirar dinero
        public virtual void Retirar (decimal monto)
    {
        return Saldo -= monto;
        Console.WriteLine($"Se han retirado {monto} pesos. Saldo actual: {Saldo} pesos.");  

    }
    // metodo transferir dinero
    public virtual void (decimal monto, string cbuDestino)
    
    
    } 
} 

class CuentaCorriente : CuentaBancaria, ITransferible{
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

}